using MDT.Core.Features.Drones.ViewModel;
using MediatR;

namespace MDT.Core.Features.Drones.Commands.MakeDroneAvailable
{
    public class MakeDroneAvailableCommand : IRequest<DroneVm>
    {
        public int DroneId { get; set; }
    }
}
