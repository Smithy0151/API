using System.Text.Json.Serialization;

namespace API.Models
{
    public class Commission
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int AgentId { get; set; }

        //That should just be called Agent
        [JsonIgnore]
        public Agent AgentName { get; set; }
    }
}
