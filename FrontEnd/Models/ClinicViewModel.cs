using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ClinicViewModel
    {
        [Key]
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public List<DoctorViewModel> Doctors { get; set; }
        public DoctorViewModel Doctor { get; set; }


        [Required(ErrorMessage = "Se require un nombre de clínica")]
        [Display(Name = "Nombre de la clínica")]
        public string ClinicName { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese el teléfono de la clínica")]
        [Display(Name = "Teléfono clínica")]
        public string ClinicPhone { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese una dirección para la clínica")]
        [Display(Name = "Dirección clínica")]
        public string ClinicAddress { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese la provincia")]
        [Display(Name = "Provincia")]
        public int ProvinceId { get; set; }
        public List<ProvinceViewModel> Provinces { get; set; }
        public ProvinceViewModel Province { get; set; }
    }
}
