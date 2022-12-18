using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Province
    {
        public Province()
        {
            Clinics = new HashSet<Clinic>();
        }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = null!;

        public virtual ICollection<Clinic> Clinics { get; set; }
    }
}
