using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProvinceViewModel
    {
        [Key]
        public int ProvinceId { get; set; }
        [Required(ErrorMessage = "Se require un nombre de provincia")]
        [Display(Name = "Provincia")]
        public string ProvinceName { get; set; } = null!;
    }
}
