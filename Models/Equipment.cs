using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentsAccessories = new HashSet<EquipmentsAccessory>();
            Maintenances = new HashSet<Maintenance>();
            Contracts = new HashSet<MaintenanceContract>();
        }

        public int EquipId { get; set; }
        public string EquipSn { get; set; } = null!;
        public string EquipName { get; set; } = null!;
        public string EquipBrand { get; set; } = null!;
        public string EquipModel { get; set; } = null!;
        public double EquipPrice { get; set; }
        public int VendorId { get; set; }
        public int EquipLocation { get; set; }
        public int RequestedBy { get; set; }
        public DateTime BuyingDate { get; set; }
        public int BuyingExcuter { get; set; }

        public virtual Employess BuyingExcuterNavigation { get; set; } = null!;
        public virtual HospitalLocation EquipLocationNavigation { get; set; } = null!;
        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<EquipmentsAccessory> EquipmentsAccessories { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }

        public virtual ICollection<MaintenanceContract> Contracts { get; set; }
    }
}
