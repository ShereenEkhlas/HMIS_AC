using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class VendorContact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; } = null!;
        public int ContactTel { get; set; }
        public int? ContactTel2 { get; set; }
        public string? ContactEmail { get; set; }
        public int ContactVendorId { get; set; }
        public string Occuption { get; set; } = null!;
        public string LastUpdateBy { get; set; } = null!;
        public string LastUpdateFrom { get; set; } = null!;
        public DateTime LastUpdateDate { get; set; }

        public virtual Vendor ContactVendor { get; set; } = null!;
    }
}
