using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class PatientArchive
    {
        public int ArchiveId { get; set; }
        public string? ArchiveName { get; set; }
        public string? ArchiveNote { get; set; }
        public int VisitId { get; set; }

        public virtual Visit Visit { get; set; } = null!;
    }
}
