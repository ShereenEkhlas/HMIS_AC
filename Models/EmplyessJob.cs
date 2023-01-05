using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class EmplyessJob
    {
        public EmplyessJob()
        {
            EmployessContracts = new HashSet<EmployessContract>();
        }

        public int JobId { get; set; }
        public string JobName { get; set; } = null!;
        public int? JobParent { get; set; }

        public virtual ICollection<EmployessContract> EmployessContracts { get; set; }
    }
}
