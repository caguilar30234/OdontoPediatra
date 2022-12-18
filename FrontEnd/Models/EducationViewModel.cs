using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class EducationViewModel
    {
        [Key]
        public int EducationId { get; set; }
        [Required]
        [Display(Name = "Escolaridad")]
        public string Level { get; set; } = null!;
    }
}
