using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Schedule
    {
        public Schedule()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int ScheduleId { get; set; }
        public string TimeOfDay { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
