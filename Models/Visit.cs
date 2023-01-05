using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Visit
    {
        public Visit()
        {
            PatientArchives = new HashSet<PatientArchive>();
            VisitDiagnoses = new HashSet<VisitDiagnose>();
            VisitDoctors = new HashSet<VisitDoctor>();
            VisitServices = new HashSet<VisitService>();
        }

        public int VisitId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? VisitStartDate { get; set; }
        public DateTime? VisitEndDate { get; set; }
        public string? VisitNote { get; set; }
        public bool VisitInsurred { get; set; }
        public int? VisitInsurredCompanyId { get; set; }
        public int? RelativeId { get; set; }
        public string VisitStatus { get; set; } = null!;
        public string? RefererDoctor { get; set; }
        public string LastUpdateBy { get; set; } = null!;
        public string LastUpdateFrom { get; set; } = null!;
        public DateTime LastUpdateDate { get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual PatientRelative? Relative { get; set; }
        public virtual InsurredCompany? VisitInsurredCompany { get; set; }
        public virtual ICollection<PatientArchive> PatientArchives { get; set; }
        public virtual ICollection<VisitDiagnose> VisitDiagnoses { get; set; }
        public virtual ICollection<VisitDoctor> VisitDoctors { get; set; }
        public virtual ICollection<VisitService> VisitServices { get; set; }
    }
}
