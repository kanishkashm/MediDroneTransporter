using MDT.Core.Enums;

namespace MDT.Core.Entities
{
    public class Drone : BaseEntity
    {
        public string SerialNumber { get; set; }
        public ModelEnum Model { get; set; }
        public decimal Weight { get; set; }
        public decimal BatteryCapacity { get; set; }
        public StatusEnum State { get; set; }
    }
}
