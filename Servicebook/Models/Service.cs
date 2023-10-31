namespace Servicebook.Models
{
    public class Service
    {
        public int Id { get; set; } 
        public int VehicleId { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Cost { get; set; } = 0;
    }
}
