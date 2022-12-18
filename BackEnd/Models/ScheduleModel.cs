using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.Models
{
    public class ScheduleModel
    {
        public int ScheduleId { get; set; }
        [Required]
        [Display(Name = "Momento del día")]
        public string TimeOfDay { get; set; } = null!;
    }
}
