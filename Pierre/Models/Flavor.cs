namespace Pierre.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        public string Flav { get; set; }
        public List<TreatFlavor> JoinEntities { get; set; }
    }
}