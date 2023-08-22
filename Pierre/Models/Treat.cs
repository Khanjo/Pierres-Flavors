using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
    public class Treat
    {
        public int TreatId { get; set; }
        [Required(ErrorMessage = "Please enter a name for this treat")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TreatFlavor> JoinEntities { get; set; }
    }
}