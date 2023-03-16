namespace MDT.Core.Entities
{
    public class Medication : BaseEntity
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Code { get; set; }
        public string ImagePath { get; set; }
    }
}
