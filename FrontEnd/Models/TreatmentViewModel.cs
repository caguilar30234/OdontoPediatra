using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TreatmentViewModel
    {
        [Key]
        public int TreatmentId { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para el tratamiento")]
        [Display(Name = "Nombre tratamiento")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese una descripción")]
        [Display(Name = "Descripción")]
        [MinLength(10, ErrorMessage = "La descripción de ser de al menos 10 caracteres")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar un monto")]
        [Display(Name = "Costo Base")]
        public int BaseCost { get; set; }
    }
}
