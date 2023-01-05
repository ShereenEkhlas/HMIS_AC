using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class InsurredCompany
    {
        public InsurredCompany()
        {
            ServicesContracts = new HashSet<ServicesContract>();
            Visits = new HashSet<Visit>();
        }

        public int InsurredId { get; set; }
        public string InsurredComapnyName { get; set; } = null!;

        public virtual ICollection<ServicesContract> ServicesContracts { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
