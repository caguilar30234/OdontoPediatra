using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.Models
{
    public class TreatmentModel
    {
        public int TreatmentId { get; set; }
        [Required]
        [Display(Name = "Nombre del Tratammiento")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = null!;
        [Required]
        [Display(Name = "Costo Base")]
        public int BaseCost { get; set; }
    }
}
