using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Equipment = new HashSet<Equipment>();
            VendorContacts = new HashSet<VendorContact>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; } = null!;
        public string VendorAddress { get; set; } = null!;
        public int VendorTel { get; set; }
        public int? VendorTel2 { get; set; }
        public string? VendorWebsite { get; set; }
        public string? OfficialEmail { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? LastUpdateBy { get; set; }
        public string? LastUpdateFrom { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<VendorContact> VendorContacts { get; set; }
    }
}
