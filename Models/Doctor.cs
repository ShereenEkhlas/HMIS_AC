using System;
using System.Collections.Generic;

namespace HMIS_AC.Models
{
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;
        public int DoctorSpecializationId { get; set; }
        public int DepartId { get; set; }
        public string DoctorTel { get; set; } = null!;
        public string? DoctorTel2 { get; set; }
        public string DoctorType { get; set; } = null!;

        public virtual HospitalDepartment Depart { get; set; } = null!;
        public virtual DoctorsSpecialization DoctorSpecialization { get; set; } = null!;
    }
}
