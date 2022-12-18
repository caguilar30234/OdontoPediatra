using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PatientDoctor
    {
        public int PatientDoctorId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
