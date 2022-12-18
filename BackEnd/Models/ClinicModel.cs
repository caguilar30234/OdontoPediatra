using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class ClinicModel
    {
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        [Required]
        [Display(Name = "Clínica")]
        public string ClinicName { get; set; } = null!;
        [Required]
        [Display(Name = "Teléfono")]
        public string ClinicPhone { get; set; } = null!;
        [Required]
        [Display(Name = "Dirección")]
        public string ClinicAddress { get; set; } = null!;
        [Required]
        public int ProvinceId { get; set; }
    }
}
