using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PatientViewModel
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        [Display(Name = "Identificación")]
        public string Identification { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar el nombre del paciente")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar los apellidos del paciente")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Debe la edad del paciente")]
        [Display(Name = "Edad")]
        public string Age { get; set; } = null!;
        public int EducationId { get; set; }
        public List<EducationViewModel> Educations { get; set; }
        public EducationViewModel Education { get; set; }
    }
}
