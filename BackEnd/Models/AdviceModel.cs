using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class AdviceModel
    {
        public int AdviceId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Requiere el doctor encargado")]
        [Display(Name ="Título")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; } = null!;
        [Display(Name = "Imagen")]
        public byte[]? Picture { get; set; }
    }
}
