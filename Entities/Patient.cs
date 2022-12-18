using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            PatientDoctors = new HashSet<PatientDoctor>();
            TreatmentPatients = new HashSet<TreatmentPatient>();
        }

        public int PatientId { get; set; }
        public string Identification { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Age { get; set; } = null!;
        public int EducationId { get; set; }

        public virtual Education Education { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<PatientDoctor> PatientDoctors { get; set; }
        public virtual ICollection<TreatmentPatient> TreatmentPatients { get; set; }
    }
}
