using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class AdviceViewModel
    {

        public int AdviceId { get; set; }
        [Required]
        [Display(Name = "ID de doctor")]
        public string DoctorId { get; set; } = null!;
        [Required]
        [Display(Name = "Título")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = null!;
        [Display(Name = "Imagen")]
        public byte[]? Picture { get; set; }
    }
}
