using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        [Required]
        public string Flav { get; set; }
        public List<TreatFlavor> JoinEntities { get; set; }
    }
}