using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class ServicesPricelist
    {
        public int ServiceId { get; set; }
        public double ServicePrice { get; set; }
        public int ContractId { get; set; }

        public virtual ServicesContract Contract { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
