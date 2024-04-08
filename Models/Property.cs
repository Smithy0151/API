using System.Text.Json.Serialization;

namespace API.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int AgentId { get; set; }
        [JsonIgnore]
        public Agent Agent { get; set; }
    }
}
