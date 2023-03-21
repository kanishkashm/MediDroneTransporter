using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Exceptions;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.Drones.Commands.MakeDroneAvailable
{
    public class MakeDroneAvailableCommandHandler : IRequestHandler<MakeDroneAvailableCommand, DroneVm>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MakeDroneAvailableCommandHandler> _logger;

        public MakeDroneAvailableCommandHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper,
                ILogger<MakeDroneAvailableCommandHandler> logger
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<DroneVm> Handle(MakeDroneAvailableCommand request, CancellationToken cancellationToken)
        {
            var drone = await _droneRepository.GetByIdAsync(request.DroneId);
            if (drone == null)
            {
                _logger.LogError("Drone not exist on database.");
                throw new NotFoundException(nameof(Drone), request.DroneId);
            }
            if(drone.State != Enums.StatusEnum.RETURNING)
            {
                _logger.LogError("Drone is loaded, can't do this operation.");
                throw new Exception("Drone is loaded, can't do this operation.");
            }
            drone.State = Enums.StatusEnum.IDLE;
            await _droneRepository.UpdateAsync(drone);
            return _mapper.Map<DroneVm>(drone);
        }
    }
}
