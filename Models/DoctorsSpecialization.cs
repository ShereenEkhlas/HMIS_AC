using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class DoctorsSpecialization
    {
        public DoctorsSpecialization()
        {
            EmployessContracts = new HashSet<EmployessContract>();
        }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; } = null!;
        public int? SpecializationParent { get; set; }

        public virtual ICollection<EmployessContract> EmployessContracts { get; set; }
    }
}
