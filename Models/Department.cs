using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Department
    {
        public Department()
        {
            Employesses = new HashSet<Employess>();
            HospitalLocations = new HashSet<HospitalLocation>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int DepartmentFloor { get; set; }

        public virtual Floor DepartmentFloorNavigation { get; set; } = null!;
        public virtual ICollection<Employess> Employesses { get; set; }
        public virtual ICollection<HospitalLocation> HospitalLocations { get; set; }
    }
}
