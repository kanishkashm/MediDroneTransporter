using MDT.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT.Core.Entities
{
    [Table("DeliveryDetails")]
    public class DeliveryDetails : EntityBase
    {
        public int DroneId { get; set; }
        public virtual Drone Drone { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public DateTime DateTimeEnded { get; set; }
        public StatusEnum DroneStatus { get; set; }
    }
}
