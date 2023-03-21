using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Exceptions;
using MDT.Core.Features.Drones.Commands.CreateDrone;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.Drones.Commands.UpdateDroneStatus
{
    public class UpdateDroneStatusCommandHandler : IRequestHandler<UpdateDroneStatusCommand, DroneVm>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDroneStatusCommandHandler> _logger;

        public UpdateDroneStatusCommandHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper,
                ILogger<UpdateDroneStatusCommandHandler> logger
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DroneVm> Handle(UpdateDroneStatusCommand request, CancellationToken cancellationToken)
        {
            var droneDetails = await _droneRepository.GetByIdAsync(request.DroneId);
            if (droneDetails == null)
            {
                _logger.LogError("Drone not exist on database.");
                throw new NotFoundException(nameof(Drone), request.DroneId);
            }
            droneDetails.State = request.DroneStatus;
            await _droneRepository.UpdateAsync(droneDetails);
            return _mapper.Map<DroneVm>(droneDetails);
        }
    }
}
