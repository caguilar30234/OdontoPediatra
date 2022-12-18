using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ScheduleViewModel
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required(ErrorMessage ="Debe ingresar un horario")]
        [Display(Name ="Horario")]
        public string TimeOfDay { get; set; } = null!;
    }
}
