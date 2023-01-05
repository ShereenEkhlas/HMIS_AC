using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Service
    {
        public Service()
        {
            VisitServices = new HashSet<VisitService>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string ServiceAvailability { get; set; } = null!;

        public virtual ServicesPricelist? ServicesPricelist { get; set; }
        public virtual ICollection<VisitService> VisitServices { get; set; }
    }
}
