using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class HospitalLocation
    {
        public HospitalLocation()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int RoomDepId { get; set; }
        public int RoomFloor { get; set; }

        public virtual Department RoomDep { get; set; } = null!;
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
