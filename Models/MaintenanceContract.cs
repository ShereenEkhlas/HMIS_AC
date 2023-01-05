using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class MaintenanceContract
    {
        public MaintenanceContract()
        {
            Devices = new HashSet<Equipment>();
        }

        public string ContractId { get; set; } = null!;
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public string ContractType { get; set; } = null!;
        public double? ContractValue { get; set; }
        public int ContractExcuter { get; set; }
        public string LatUpdateBy { get; set; } = null!;
        public string LastUpdateFrom { get; set; } = null!;
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<Equipment> Devices { get; set; }
    }
}
