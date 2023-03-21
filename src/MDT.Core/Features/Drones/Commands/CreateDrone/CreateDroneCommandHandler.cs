using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Exceptions;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.Drones.Commands.CreateDrone
{
    public class CreateDroneCommandHandler : IRequestHandler<CreateDroneCommand, Drone>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDroneCommandHandler> _logger;

        public CreateDroneCommandHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper,
                ILogger<CreateDroneCommandHandler> logger
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Drone> Handle(CreateDroneCommand request, CancellationToken cancellationToken)
        {
            var savedDrones = (await _droneRepository.GetAsync(x => x.SerialNumber == request.SerialNumber)).FirstOrDefault();
            if ( savedDrones != null )
            {
                _logger.LogError($"Drne already registered with serial number {request.SerialNumber}.");
                throw new ResourceAlreadyExistsException(nameof(Drone), request.SerialNumber);
            }
            savedDrones = new Drone();
            _mapper.Map(request, savedDrones, typeof(CreateDroneCommand), typeof(Drone));

            await _droneRepository.AddAsync(savedDrones);

            _logger.LogInformation($"Drone {savedDrones.SerialNumber} is successfully created.");

            return savedDrones;
        }
    }
}
