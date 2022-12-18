using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class EducationModel
    {
        public int EducationId { get; set; }
        [Required]
        [Display(Name = "Nivel educativo")]
        public string Level { get; set; } = null!;
    }
}
