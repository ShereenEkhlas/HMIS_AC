using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class DepartmentManagment
    {
        public int DepartId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PositionTitle { get; set; }
    }
}
