namespace API.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Commission Commission { get; set; }

        public List<Property> Properties { get; set; }
        public List<Area> Areas { get; set; }
    }
}
