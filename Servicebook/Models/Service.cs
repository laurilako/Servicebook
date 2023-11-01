using System.Text.Json.Serialization;

namespace Servicebook.Models
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Cost { get; set; } = 0;
        [JsonIgnore]
        public Vehicle Vehicle { get; set; } = new Vehicle();
    }
}
