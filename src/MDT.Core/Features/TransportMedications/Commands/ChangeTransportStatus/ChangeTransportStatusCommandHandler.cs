using MDT.Core.Entities;
using MDT.Core.Enums;
using MDT.Core.Exceptions;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.TransportMedications.Commands.ChangeTransportStatus
{
    public class ChangeTransportStatusCommandHandler : IRequestHandler<ChangeTransportStatusCommand>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IDeliveryDetailsRepository _deliveryDetailsRepository;
        private readonly ILogger<ChangeTransportStatusCommandHandler> _logger;

        public ChangeTransportStatusCommandHandler
            (
                IDroneRepository droneRepository,
                IDeliveryDetailsRepository deliveryDetailsRepository,
                ILogger<ChangeTransportStatusCommandHandler> logger
            )
        {
            _droneRepository = droneRepository;
            _deliveryDetailsRepository = deliveryDetailsRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(ChangeTransportStatusCommand request, CancellationToken cancellationToken)
        {
            var transportDetails = await _deliveryDetailsRepository.GetByIdAsync(request.TransportId);

            if (transportDetails == null)
            {
                _logger.LogError("Delivery details not exist on database.");
                throw new NotFoundException(nameof(DeliveryDetails), request.TransportId);
            }
            if(transportDetails.DroneStatus == StatusEnum.RETURNING)
            {
                _logger.LogError("Status can't be changed");
                throw new Exception("Status can't be changed");
            }

            var drone = await _droneRepository.GetByIdAsync(transportDetails.DroneId);
            if(drone == null)
            {
                _logger.LogError("Drone not exist on database.");
                throw new NotFoundException(nameof(Drone), transportDetails.DroneId);
            }

            drone.State = request.DroneStatus;
            transportDetails.DroneStatus = request.DroneStatus;
            if(request.DroneStatus == StatusEnum.RETURNING)
            {
                transportDetails.DateTimeEnded = DateTime.UtcNow;
            }

            await _droneRepository.UpdateAsync(drone);
            await _deliveryDetailsRepository.UpdateAsync(transportDetails);

            return Unit.Value;
        }
    }
}
