using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class VisitDoctor
    {
        public int VisitId { get; set; }
        public int DoctorId { get; set; }
        public string? LastUpdateBy { get; set; }
        public string? LastUpdateFrom { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual Visit Visit { get; set; } = null!;
    }
}
