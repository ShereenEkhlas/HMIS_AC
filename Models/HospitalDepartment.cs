using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class HospitalDepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int Floor { get; set; }
    }
}
