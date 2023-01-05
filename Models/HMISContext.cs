using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HMIS_AC.Models
{
    public partial class HMISContext : DbContext
    {
        public HMISContext()
        {
        }

        public HMISContext(DbContextOptions<HMISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentManagment> DepartmentManagments { get; set; } = null!;
        public virtual DbSet<Diagnosis> Diagnoses { get; set; } = null!;
        public virtual DbSet<DoctorsSpecialization> DoctorsSpecializations { get; set; } = null!;
        public virtual DbSet<Employess> Employesses { get; set; } = null!;
        public virtual DbSet<EmployessContract> EmployessContracts { get; set; } = null!;
        public virtual DbSet<EmployessContractType> EmployessContractTypes { get; set; } = null!;
        public virtual DbSet<EmplyessJob> EmplyessJobs { get; set; } = null!;
        public virtual DbSet<Equipment> Equipments { get; set; } = null!;
        public virtual DbSet<EquipmentsAccessory> EquipmentsAccessories { get; set; } = null!;
        public virtual DbSet<Floor> Floors { get; set; } = null!;
        public virtual DbSet<HospitalDepartment> HospitalDepartments { get; set; } = null!;
        public virtual DbSet<HospitalLocation> HospitalLocations { get; set; } = null!;
        public virtual DbSet<InsurredCompany> InsurredCompanies { get; set; } = null!;
        public virtual DbSet<Maintenance> Maintenances { get; set; } = null!;
        public virtual DbSet<MaintenanceContract> MaintenanceContracts { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientArchive> PatientArchives { get; set; } = null!;
        public virtual DbSet<PatientRelative> PatientRelatives { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServicesContract> ServicesContracts { get; set; } = null!;
        public virtual DbSet<ServicesPricelist> ServicesPricelists { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<VendorContact> VendorContacts { get; set; } = null!;
        public virtual DbSet<Visit> Visits { get; set; } = null!;
        public virtual DbSet<VisitDiagnose> VisitDiagnoses { get; set; } = null!;
        public virtual DbSet<VisitDoctor> VisitDoctors { get; set; } = null!;
        public virtual DbSet<VisitService> VisitServices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=150.200.12.1;initial catalog=HMIS;persist security info=True;user id=hmis_login;password=acms@bms;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.DepartmentFloor).HasColumnName("department_floor");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("department_name");

                entity.HasOne(d => d.DepartmentFloorNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DepartmentFloor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Floors");
            });

            modelBuilder.Entity<DepartmentManagment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Department_Managment");

                entity.Property(e => e.DepartId).HasColumnName("depart_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.PositionTitle).HasColumnName("position_title");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.DiagnoseId)
                    .ValueGeneratedNever()
                    .HasColumnName("diagnose_id");

                entity.Property(e => e.DiagnoseName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("diagnose_name");
            });

            modelBuilder.Entity<DoctorsSpecialization>(entity =>
            {
                entity.HasKey(e => e.SpecializationId);

                entity.ToTable("Doctors_specializations");

                entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");

                entity.Property(e => e.SpecializationName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("specialization_name");

                entity.Property(e => e.SpecializationParent).HasColumnName("specialization_parent");
            });

            modelBuilder.Entity<Employess>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Employess");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.DepartId).HasColumnName("depart_id");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("employee_address");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee_email");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("employee_name");

                entity.Property(e => e.EmployeeNid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("employee_NID");

                entity.Property(e => e.EmployeeTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee_tel");

                entity.Property(e => e.EmployeeTel2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee_tel2");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.HiringDate)
                    .HasColumnType("datetime")
                    .HasColumnName("hiring_date");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.Employesses)
                    .HasForeignKey(d => d.DepartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employess_Departments");
            });

            modelBuilder.Entity<EmployessContract>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.ToTable("Employess_Contracts");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contract_id");

                entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.JobCat).HasColumnName("job_cat");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.SecializationId).HasColumnName("secialization_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployessContracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employess_Contracts_Employess");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.EmployessContracts)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employess_Contracts_Emplyess_Jobs");

                entity.HasOne(d => d.Secialization)
                    .WithMany(p => p.EmployessContracts)
                    .HasForeignKey(d => d.SecializationId)
                    .HasConstraintName("FK_Employess_Contracts_Doctors_specializations");
            });

            modelBuilder.Entity<EmployessContractType>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.ToTable("Employess_contract_types");

                entity.Property(e => e.ContractId)
                    .ValueGeneratedNever()
                    .HasColumnName("contract_id");

                entity.Property(e => e.ContractName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contract_name");
            });

            modelBuilder.Entity<EmplyessJob>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("Emplyess_Jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("job_name");

                entity.Property(e => e.JobParent).HasColumnName("job_parent");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.EquipId);

                entity.Property(e => e.EquipId)
                    .ValueGeneratedNever()
                    .HasColumnName("equip_id");

                entity.Property(e => e.BuyingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("buying_date");

                entity.Property(e => e.BuyingExcuter).HasColumnName("buying_excuter");

                entity.Property(e => e.EquipBrand)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("equip_brand");

                entity.Property(e => e.EquipLocation).HasColumnName("equip_location");

                entity.Property(e => e.EquipModel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("equip_model");

                entity.Property(e => e.EquipName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("equip_name");

                entity.Property(e => e.EquipPrice).HasColumnName("equip_price");

                entity.Property(e => e.EquipSn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("equip_sn");

                entity.Property(e => e.RequestedBy).HasColumnName("requested_by");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.BuyingExcuterNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.BuyingExcuter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipments_Equipments");

                entity.HasOne(d => d.EquipLocationNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipments_Hospital_Locations");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipments_Vendors");
            });

            modelBuilder.Entity<EquipmentsAccessory>(entity =>
            {
                entity.HasKey(e => e.AccessoryId);

                entity.ToTable("Equipments_Accessories");

                entity.Property(e => e.AccessoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("accessory_id");

                entity.Property(e => e.AccessoryName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("accessory_name");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentsAccessories)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipments_Accessories_Equipments");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(e => e.FloorId)
                    .ValueGeneratedNever()
                    .HasColumnName("floor_id");

                entity.Property(e => e.FloorName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("floor_name");
            });

            modelBuilder.Entity<HospitalDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("Hospital_Departments");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("department_name");

                entity.Property(e => e.Floor).HasColumnName("floor");
            });

            modelBuilder.Entity<HospitalLocation>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("Hospital_Locations");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("room_id");

                entity.Property(e => e.RoomDepId).HasColumnName("room_dep_id");

                entity.Property(e => e.RoomFloor).HasColumnName("room_floor");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("room_name");

                entity.HasOne(d => d.RoomDep)
                    .WithMany(p => p.HospitalLocations)
                    .HasForeignKey(d => d.RoomDepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hospital_Locations_Departments");
            });

            modelBuilder.Entity<InsurredCompany>(entity =>
            {
                entity.HasKey(e => e.InsurredId);

                entity.ToTable("Insurred_Companies");

                entity.Property(e => e.InsurredId)
                    .ValueGeneratedNever()
                    .HasColumnName("insurred_id");

                entity.Property(e => e.InsurredComapnyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("insurred_comapny_name");
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.ToTable("Maintenance");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EquipId).HasColumnName("equip_id");

                entity.Property(e => e.ExitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("exit_date");

                entity.Property(e => e.ExitResponsible).HasColumnName("exit_responsible");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fixing_date");

                entity.Property(e => e.MulfuctionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("mulfuction_date");

                entity.Property(e => e.Mulfunction)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mulfunction");

                entity.Property(e => e.ReturnBackDate)
                    .HasColumnType("datetime")
                    .HasColumnName("return_back_date");

                entity.HasOne(d => d.Equip)
                    .WithMany(p => p.Maintenances)
                    .HasForeignKey(d => d.EquipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maintenance_Equipments");

                entity.HasOne(d => d.ExitResponsibleNavigation)
                    .WithMany(p => p.Maintenances)
                    .HasForeignKey(d => d.ExitResponsible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maintenance_Employess");
            });

            modelBuilder.Entity<MaintenanceContract>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PK_Maintenance_Contracts_1");

                entity.ToTable("Maintenance_Contracts");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contract_id");

                entity.Property(e => e.ContractEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("contract_end");

                entity.Property(e => e.ContractExcuter).HasColumnName("contract_excuter");

                entity.Property(e => e.ContractStart)
                    .HasColumnType("datetime")
                    .HasColumnName("contract_start");

                entity.Property(e => e.ContractType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("contract_type")
                    .IsFixedLength();

                entity.Property(e => e.ContractValue).HasColumnName("contract_value");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.Property(e => e.LatUpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lat_update_by");

                entity.HasMany(d => d.Devices)
                    .WithMany(p => p.Contracts)
                    .UsingEntity<Dictionary<string, object>>(
                        "MaintenanceContractEquipment",
                        l => l.HasOne<Equipment>().WithMany().HasForeignKey("DeviceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Maintenance_Contract_Equipments_Equipments"),
                        r => r.HasOne<MaintenanceContract>().WithMany().HasForeignKey("ContractId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Maintenance_Contract_Equipments_Maintenance_Contract_Equipments"),
                        j =>
                        {
                            j.HasKey("ContractId", "DeviceId");

                            j.ToTable("Maintenance_Contract_Equipments");

                            j.IndexerProperty<string>("ContractId").HasMaxLength(50).IsUnicode(false).HasColumnName("contract_id");

                            j.IndexerProperty<int>("DeviceId").HasColumnName("device_id");
                        });
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("patient_address");

                entity.Property(e => e.PatientEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patient_email");

                entity.Property(e => e.PatientGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("patient_gender")
                    .IsFixedLength();

                entity.Property(e => e.PatientName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("patient_name");

                entity.Property(e => e.PatientNid).HasColumnName("patient_NID");

                entity.Property(e => e.PatientTel1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("patient_tel1");

                entity.Property(e => e.PatientTel2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("patient_tel2");
            });

            modelBuilder.Entity<PatientArchive>(entity =>
            {
                entity.HasKey(e => e.ArchiveId);

                entity.ToTable("Patient_Archive");

                entity.Property(e => e.ArchiveId)
                    .ValueGeneratedNever()
                    .HasColumnName("archive_id");

                entity.Property(e => e.ArchiveName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("archive_name");

                entity.Property(e => e.ArchiveNote)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("archive_note");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.PatientArchives)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Archive_Visits");
            });

            modelBuilder.Entity<PatientRelative>(entity =>
            {
                entity.HasKey(e => e.RelativeId)
                    .HasName("PK_Relative_Relation");

                entity.ToTable("Patient_Relative");

                entity.Property(e => e.RelativeId)
                    .ValueGeneratedNever()
                    .HasColumnName("relative_id");

                entity.Property(e => e.RelativeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("relative_name");

                entity.Property(e => e.RelativeTel1).HasColumnName("relative_tel1");

                entity.Property(e => e.RelativeTel2).HasColumnName("relative_tel2");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("service_id");

                entity.Property(e => e.ServiceAvailability)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("service_availability")
                    .IsFixedLength();

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("service_name");
            });

            modelBuilder.Entity<ServicesContract>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.ToTable("Services_Contracts");

                entity.Property(e => e.ContractId)
                    .ValueGeneratedNever()
                    .HasColumnName("contract_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.ExcutedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("excuted_by");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ServicesContracts)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Contracts_Insurred_Companies");
            });

            modelBuilder.Entity<ServicesPricelist>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK_Services");

                entity.ToTable("Services_Pricelist");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("service_id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.ServicePrice).HasColumnName("service_price");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ServicesPricelists)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Services_Contracts");

                entity.HasOne(d => d.Service)
                    .WithOne(p => p.ServicesPricelist)
                    .HasForeignKey<ServicesPricelist>(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Pricelist_Services");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorId)
                    .ValueGeneratedNever()
                    .HasColumnName("vendor_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.Property(e => e.OfficialEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("official_email");

                entity.Property(e => e.VendorAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("vendor_address");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("vendor_name");

                entity.Property(e => e.VendorTel).HasColumnName("vendor_tel");

                entity.Property(e => e.VendorTel2).HasColumnName("vendor_tel2");

                entity.Property(e => e.VendorWebsite)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("vendor_website");
            });

            modelBuilder.Entity<VendorContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("Vendor_Contacts");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedNever()
                    .HasColumnName("contact_id");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contact_email");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("contact_name");

                entity.Property(e => e.ContactTel).HasColumnName("contact_tel");

                entity.Property(e => e.ContactTel2).HasColumnName("contact_tel2");

                entity.Property(e => e.ContactVendorId).HasColumnName("contact_vendor_id");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.Property(e => e.Occuption)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("occuption");

                entity.HasOne(d => d.ContactVendor)
                    .WithMany(p => p.VendorContacts)
                    .HasForeignKey(d => d.ContactVendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendor_Contacts_Vendors");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.Property(e => e.VisitId)
                    .ValueGeneratedNever()
                    .HasColumnName("visit_id");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.RefererDoctor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("referer_doctor");

                entity.Property(e => e.RelativeId).HasColumnName("relative_id");

                entity.Property(e => e.VisitEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("visit_end_date");

                entity.Property(e => e.VisitInsurred).HasColumnName("visit_insurred");

                entity.Property(e => e.VisitInsurredCompanyId).HasColumnName("visit_insurred_company_id");

                entity.Property(e => e.VisitNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("visit_note");

                entity.Property(e => e.VisitStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("visit_start_date");

                entity.Property(e => e.VisitStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("visit_status")
                    .IsFixedLength();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Visits_Patients");

                entity.HasOne(d => d.Relative)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.RelativeId)
                    .HasConstraintName("FK_Visits_Relative_Relation");

                entity.HasOne(d => d.VisitInsurredCompany)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.VisitInsurredCompanyId)
                    .HasConstraintName("FK_Visits_Insurred_Companies");
            });

            modelBuilder.Entity<VisitDiagnose>(entity =>
            {
                entity.HasKey(e => new { e.DiagnoseId, e.VisitId });

                entity.ToTable("Visit_Diagnose");

                entity.Property(e => e.DiagnoseId).HasColumnName("diagnose_id");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.HasOne(d => d.Diagnose)
                    .WithMany(p => p.VisitDiagnoses)
                    .HasForeignKey(d => d.DiagnoseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Diagnose_Diagnoses");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitDiagnoses)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Diagnose_Visits");
            });

            modelBuilder.Entity<VisitDoctor>(entity =>
            {
                entity.HasKey(e => new { e.VisitId, e.DoctorId });

                entity.ToTable("Visit_Doctors");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_date");

                entity.Property(e => e.LastUpdateFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_update_from");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitDoctors)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Visits_Visits");
            });

            modelBuilder.Entity<VisitService>(entity =>
            {
                entity.HasKey(e => new { e.ServiceId, e.VisitId });

                entity.ToTable("visit_services");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approval_date");

                entity.Property(e => e.ApprovalId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("approval_id");

                entity.Property(e => e.RequestedDepartment)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("requested_department");

                entity.Property(e => e.RequestedDoctor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("requested_doctor");

                entity.Property(e => e.ServiceBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("service_by");

                entity.Property(e => e.ServiceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("service_date");

                entity.Property(e => e.ServiceNotes)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("service_notes");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.VisitServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_visit_services_Services");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitServices)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_visit_services_Visits");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
