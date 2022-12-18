using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Clinic
    {
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public string ClinicName { get; set; } = null!;
        public string ClinicPhone { get; set; } = null!;
        public string ClinicAddress { get; set; } = null!;
        public int ProvinceId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Province Province { get; set; } = null!;
    }
}
