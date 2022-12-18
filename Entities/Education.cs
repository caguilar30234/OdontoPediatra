using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Education
    {
        public Education()
        {
            Patients = new HashSet<Patient>();
        }

        public int EducationId { get; set; }
        public string Level { get; set; } = null!;

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
