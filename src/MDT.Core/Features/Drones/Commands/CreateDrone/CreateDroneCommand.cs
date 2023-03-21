using MDT.Core.Entities;
using MDT.Core.Enums;
using MediatR;

namespace MDT.Core.Features.Drones.Commands.CreateDrone
{
    public class CreateDroneCommand : IRequest<Drone>
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public ModelEnum Model { get; set; }
        public decimal WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }
        public StatusEnum State { get; set; }
    }
}
