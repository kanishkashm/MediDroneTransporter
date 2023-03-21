using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Exceptions;
using MDT.Core.Features.Drones.Commands.UpdateDrone;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.Drones.Commands.UpdateDroneBattery
{
    public class UpdateDroneBatteryCommandHandler : IRequestHandler<UpdateDroneBatteryCommand, DroneVm>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDroneBatteryCommandHandler> _logger;

        public UpdateDroneBatteryCommandHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper,
                ILogger<UpdateDroneBatteryCommandHandler> logger
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DroneVm> Handle(UpdateDroneBatteryCommand request, CancellationToken cancellationToken)
        {
            var droneDetails = await _droneRepository.GetByIdAsync(request.DroneId);
            if (droneDetails == null)
            {
                _logger.LogError("Drone not exist on database.");
                throw new NotFoundException(nameof(Drone), request.DroneId);
            }
            droneDetails.BatteryCapacity = request.BatteryLevel;
            await _droneRepository.UpdateAsync(droneDetails);
            return _mapper.Map<DroneVm>(droneDetails);
        }
    }
}
