using AutoMapper;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Interfaces;
using MediatR;

namespace MDT.Core.Features.Drones.Queries.AvailableDrones
{
    public class AvailableDronesQueryHandler : IRequestHandler<AvailableDronesQuery, List<DroneVm>>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public AvailableDronesQueryHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
        }

        public async Task<List<DroneVm>> Handle(AvailableDronesQuery request, CancellationToken cancellationToken)
        {
            var droneList = await _droneRepository.GetAsync(x => x.State == request.DroneStatus);
            return _mapper.Map<List<DroneVm>>(droneList);
        }
    }
}
