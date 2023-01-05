using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class VisitDiagnose
    {
        public int DiagnoseId { get; set; }
        public int VisitId { get; set; }
        public string LastUpdateBy { get; set; } = null!;
        public string LastUpdateFrom { get; set; } = null!;
        public DateTime LastUpdateDate { get; set; }

        public virtual Diagnosis Diagnose { get; set; } = null!;
        public virtual Visit Visit { get; set; } = null!;
    }
}
