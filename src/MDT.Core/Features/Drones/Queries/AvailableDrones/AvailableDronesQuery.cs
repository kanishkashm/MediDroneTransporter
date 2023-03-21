using MDT.Core.Enums;
using MDT.Core.Features.Drones.ViewModel;
using MediatR;

namespace MDT.Core.Features.Drones.Queries.AvailableDrones
{
    public class AvailableDronesQuery : IRequest<List<DroneVm>>
    {
        public StatusEnum DroneStatus { get; set; }
        public AvailableDronesQuery(StatusEnum droneStatus)
        {
            DroneStatus = droneStatus;
        }
    }
}
