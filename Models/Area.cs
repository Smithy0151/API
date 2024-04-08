using System.Text.Json.Serialization;

namespace API.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [JsonIgnore]
        public List<Agent> Agents { get; set; }
    }
}
