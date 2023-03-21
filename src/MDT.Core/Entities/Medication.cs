using System.ComponentModel.DataAnnotations.Schema;

namespace MDT.Core.Entities
{
    [Table("Medication")]
    public class Medication : EntityBase
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Code { get; set; }
        public string ImagePath { get; set; }
        public int DeliveryDetailsId { get; set; }
        public DeliveryDetails DeliveryDetails { get; set; }
    }
}
