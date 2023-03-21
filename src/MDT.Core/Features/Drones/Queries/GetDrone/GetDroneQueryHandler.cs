using AutoMapper;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Interfaces;
using MediatR;

namespace MDT.Core.Features.Drones.Queries.GetDrone
{
    public class GetDroneQueryHandler : IRequestHandler<GetDroneQuery, DroneVm>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public GetDroneQueryHandler
            (
                IDroneRepository droneRepository,
                IMapper mapper
            )
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
        }

        public async Task<DroneVm> Handle(GetDroneQuery request, CancellationToken cancellationToken)
        {
            var drone = (await _droneRepository.GetAsync(x => x.SerialNumber == request.SerialNumber)).FirstOrDefault();
            return _mapper.Map<DroneVm>(drone);
        }
    }
}
