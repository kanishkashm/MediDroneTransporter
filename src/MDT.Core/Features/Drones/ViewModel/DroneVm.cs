using MDT.Core.Enums;

namespace MDT.Core.Features.Drones.ViewModel
{
    public class DroneVm
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public ModelEnum Model { get; set; }
        public decimal WeightLimit { get; set; }
        public decimal BatteryCapacity { get; set; }
        public StatusEnum State { get; set; }
    }
}
