using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class EquipmentsAccessory
    {
        public int AccessoryId { get; set; }
        public int EquipmentId { get; set; }
        public string AccessoryName { get; set; } = null!;
        public string? Notes { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;
    }
}
