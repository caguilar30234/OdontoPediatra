using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TreatmentPatientViewModel
    {
        [Key]
        public int TreatmentPatientId { get; set; }
        [Required]
        public int PatientId { get; set; }
        public PatientViewModel Patient { get; set; }
        public List<PatientViewModel> Patients { get; set; }
        public PatientViewModel patient { get; set; }
        [Required]
        public int TreatmentId { get; set; }
        public TreatmentViewModel Treatment { get; set; }
        public List<TreatmentViewModel> Treatments { get; set; }
        public TreatmentViewModel treatment { get; set; }
    }
}
