using System.Text.Json.Serialization;

namespace Servicebook.Models
{
    public class Vehicle
    {
        public int Id { get; set; } 
        public string Brand { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public string Color { get; set; } = string.Empty;
        public List<Service> Services { get; set; } = new List<Service>();
    }
}
