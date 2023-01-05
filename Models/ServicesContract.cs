using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class ServicesContract
    {
        public ServicesContract()
        {
            ServicesPricelists = new HashSet<ServicesPricelist>();
        }

        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CompanyId { get; set; }
        public string? ExcutedBy { get; set; }

        public virtual InsurredCompany Company { get; set; } = null!;
        public virtual ICollection<ServicesPricelist> ServicesPricelists { get; set; }
    }
}
