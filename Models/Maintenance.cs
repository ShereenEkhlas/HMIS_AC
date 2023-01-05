using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Maintenance
    {
        public int Id { get; set; }
        public int EquipId { get; set; }
        public DateTime MulfuctionDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? ReturnBackDate { get; set; }
        public int ExitResponsible { get; set; }
        public string Mulfunction { get; set; } = null!;
        public DateTime? FixingDate { get; set; }

        public virtual Equipment Equip { get; set; } = null!;
        public virtual Employess ExitResponsibleNavigation { get; set; } = null!;
    }
}
