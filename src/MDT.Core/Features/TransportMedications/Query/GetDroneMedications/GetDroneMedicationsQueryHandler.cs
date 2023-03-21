using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Exceptions;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Features.TransportMedications.Commands.LoadMedication;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.TransportMedications.Query.GetDroneMedications
{
    public class GetDroneMedicationsQueryHandler : IRequestHandler<GetDroneMedicationsQuery, List<MedicationVm>>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IDeliveryDetailsRepository _deliveryDetailsRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly ILogger<GetDroneMedicationsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetDroneMedicationsQueryHandler
            (
                IDroneRepository droneRepository,
                IDeliveryDetailsRepository deliveryDetailsRepository,
                IMedicationRepository medicationRepository,
                ILogger<GetDroneMedicationsQueryHandler> logger,
                IMapper mapper
            )
        {
            _droneRepository = droneRepository;
            _deliveryDetailsRepository = deliveryDetailsRepository;
            _medicationRepository = medicationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<MedicationVm>> Handle(GetDroneMedicationsQuery request, CancellationToken cancellationToken)
        {
            var drone = (await _droneRepository.GetAsync(x => x.SerialNumber == request.SerialNumber)).FirstOrDefault();
            if (drone == null)
            {
                _logger.LogError("Drone not exist on database.");
                throw new NotFoundException(nameof(Drone), request.SerialNumber);
            }
            if(drone.State == Enums.StatusEnum.IDLE || 
                drone.State == Enums.StatusEnum.RETURNING)
            {
                _logger.LogError("Drone is not loaded.");
                return null;
            }
            var deliveryDetails = (await _deliveryDetailsRepository.GetAsync(x => x.DroneId == drone.Id &&
                (x.DroneStatus != Enums.StatusEnum.IDLE &&
                x.DroneStatus != Enums.StatusEnum.RETURNING))).FirstOrDefault();
            if (deliveryDetails == null)
            {
                _logger.LogError("Delivery details not exist on database.");
                throw new NotFoundException(nameof(DeliveryDetails), drone.Id);
            }
            var medications = await _medicationRepository.GetAsync(x => x.DeliveryDetailsId == deliveryDetails.Id);
            return _mapper.Map<List<MedicationVm>>(medications);
        }
    }
}
