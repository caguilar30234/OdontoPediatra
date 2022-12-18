using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PatientUser
    {
        [Key]
        public int PatientUserId { get; set; }
        [Required]
        public string DoctorId { get; set; } = null!;
        public List<DoctorViewModel> Doctors { get; set; }
        public DoctorViewModel Doctor { get; set; }
        [Required]
        public int PatientId { get; set; }
        public PatientViewModel Patient { get; set; }
    }
}
