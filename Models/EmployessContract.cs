using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class EmployessContract
    {
        public string ContractId { get; set; } = null!;
        public int? EmployeeId { get; set; }
        public int? ContractTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int JobId { get; set; }
        public int? SecializationId { get; set; }
        public int? JobCat { get; set; }

        public virtual Employess? Employee { get; set; }
        public virtual EmplyessJob Job { get; set; } = null!;
        public virtual DoctorsSpecialization? Secialization { get; set; }
    }
}
