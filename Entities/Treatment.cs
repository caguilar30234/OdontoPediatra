using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Treatment
    {
        public Treatment()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            TreatmentPatients = new HashSet<TreatmentPatient>();
        }

        public int TreatmentId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int BaseCost { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<TreatmentPatient> TreatmentPatients { get; set; }
    }
}
