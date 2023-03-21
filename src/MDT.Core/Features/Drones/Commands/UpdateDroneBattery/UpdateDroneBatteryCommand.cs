using MDT.Core.Features.Drones.ViewModel;
using MediatR;

namespace MDT.Core.Features.Drones.Commands.UpdateDrone
{
    public class UpdateDroneBatteryCommand : IRequest<DroneVm>
    {
        public int DroneId { get; set; }
        public int BatteryLevel { get; set; }
    }
}
