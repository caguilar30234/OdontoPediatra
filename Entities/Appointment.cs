using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Appointment
    {
        public int AppoinmentId { get; set; }
        public int PatientId { get; set; }
        public int ScheduleId { get; set; }
        public string Motivo { get; set; } = null!;
        public bool? CitaAsignada { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
    }
}
