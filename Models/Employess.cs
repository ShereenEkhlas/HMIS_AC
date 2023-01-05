using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Employess
    {
        public Employess()
        {
            EmployessContracts = new HashSet<EmployessContract>();
            Equipment = new HashSet<Equipment>();
            Maintenances = new HashSet<Maintenance>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmployeeNid { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string EmployeeAddress { get; set; } = null!;
        public string? EmployeeEmail { get; set; }
        public string EmployeeTel { get; set; } = null!;
        public string? EmployeeTel2 { get; set; }
        public int DepartId { get; set; }
        public DateTime HiringDate { get; set; }

        public virtual Department Depart { get; set; } = null!;
        public virtual ICollection<EmployessContract> EmployessContracts { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
