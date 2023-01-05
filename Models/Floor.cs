using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Floor
    {
        public Floor()
        {
            Departments = new HashSet<Department>();
        }

        public int FloorId { get; set; }
        public string FloorName { get; set; } = null!;

        public virtual ICollection<Department> Departments { get; set; }
    }
}
