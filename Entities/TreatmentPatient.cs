using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TreatmentPatient
    {
        public int TreatmentPatientId { get; set; }
        public int PatientId { get; set; }
        public int TreatmentId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Treatment Treatment { get; set; } = null!;
    }
}
