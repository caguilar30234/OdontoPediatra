using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class AppointmentModel
    {
        public int AppoinmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Momento del día")]
        public int ScheduleId { get; set; }
        [Required]
        [Display(Name = "Motivo de la cita")]
        public string Motivo { get; set; } = null!;
        public bool? CitaAsignada { get; set; }
    }
}
