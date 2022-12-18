using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class ProvinceModel
    {
        public int ProvinceId { get; set; }
        [Required]
        [Display(Name ="Provincia")]
        public string ProvinceName { get; set; } = null!;
    }
}
