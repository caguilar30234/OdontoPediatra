using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Número de Identificación")]
        public string Identification { get; set; } = null!;
        [Required]
        [Display(Name = "Nombre paciente")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Apellidos paciente")]
        public string LastName { get; set; } = null!;
        [Required]
        [Display(Name = "Edad")]
        public string Age { get; set; } = null!;
        [Required]
        public int EducationId { get; set; }
    }
}
