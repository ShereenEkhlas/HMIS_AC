using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            VisitDiagnoses = new HashSet<VisitDiagnose>();
        }

        public int DiagnoseId { get; set; }
        public string DiagnoseName { get; set; } = null!;

        public virtual ICollection<VisitDiagnose> VisitDiagnoses { get; set; }
    }
}
