using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class PatientRelative
    {
        public PatientRelative()
        {
            Visits = new HashSet<Visit>();
        }

        public int RelativeId { get; set; }
        public string? RelativeName { get; set; }
        public int? RelativeTel1 { get; set; }
        public int? RelativeTel2 { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
