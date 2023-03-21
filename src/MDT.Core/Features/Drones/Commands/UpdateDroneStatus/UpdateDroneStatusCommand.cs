using MDT.Core.Enums;
using MDT.Core.Features.Drones.ViewModel;
using MediatR;

namespace MDT.Core.Features.Drones.Commands.UpdateDroneStatus
{
    public class UpdateDroneStatusCommand : IRequest<DroneVm>
    {
        public int DroneId { get; set; }
        public StatusEnum DroneStatus { get; set; }
    }
}
