using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Advice
    {
        public int AdviceId { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[]? Picture { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
    }
}
