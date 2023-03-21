using AutoMapper;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Interfaces;
using MediatR;

namespace MDT.Core.Features.Drones.Queries.GetDroneList
{
    public class GetDronesListQueryHandler : IRequestHandler<GetDronesListQuery, List<DroneVm>>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public GetDronesListQueryHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
        }

        public async Task<List<DroneVm>> Handle(GetDronesListQuery request, CancellationToken cancellationToken)
        {
            var droneList = (await _droneRepository.GetAllAsync());
            return _mapper.Map<List<DroneVm>>(droneList);
        }
    }
}
