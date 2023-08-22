using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        [Required(ErrorMessage = "Please enter a name for this flavor")]
        public string Flav { get; set; }
        public List<TreatFlavor> JoinEntities { get; set; }
    }
}