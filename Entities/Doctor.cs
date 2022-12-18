using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Doctor
    {
        public Doctor()
        {
            Advices = new HashSet<Advice>();
            Clinics = new HashSet<Clinic>();
            PatientDoctors = new HashSet<PatientDoctor>();
        }

        public int DoctorId { get; set; }
        public string Identification { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Advice> Advices { get; set; }
        public virtual ICollection<Clinic> Clinics { get; set; }
        public virtual ICollection<PatientDoctor> PatientDoctors { get; set; }
    }
}
