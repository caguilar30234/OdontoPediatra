using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class AppointmentViewModel
    {
        [Key]
        public int AppoinmentId { get; set; }
        public int PatientId { get; set; }
        public List<PatientViewModel> Patients { get; set; }
        public PatientViewModel Patient { get; set; }

        public int ScheduleId { get; set; }
        public List<ScheduleViewModel> Schedules { get; set; }
        public ScheduleViewModel Schedule { get; set; }


        public string Motivo { get; set; } = null!;
        public bool CitaAsignada { get; set; }
    }
}
