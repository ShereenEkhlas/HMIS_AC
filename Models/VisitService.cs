using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class VisitService
    {
        public int ServiceId { get; set; }
        public int VisitId { get; set; }
        public string? ApprovalId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public string? ServiceBy { get; set; }
        public string RequestedDoctor { get; set; } = null!;
        public string RequestedDepartment { get; set; } = null!;
        public string? ServiceNotes { get; set; }

        public virtual Service Service { get; set; } = null!;
        public virtual Visit Visit { get; set; } = null!;
    }
}
