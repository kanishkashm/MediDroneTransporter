using MDT.Core.Features.Drones.ViewModel;
using MediatR;

namespace MDT.Core.Features.Drones.Queries.GetDrone
{
    public class GetDroneQuery : IRequest<DroneVm>
    {
        public string SerialNumber { get; set; }

        public GetDroneQuery(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}
