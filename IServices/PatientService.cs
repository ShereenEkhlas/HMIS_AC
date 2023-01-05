using HMIS_AC.Models;

namespace HMIS_AC.IServices
{
    public class PatientService :IBaseService<Patient>
    {
        private readonly HMISContext db;
        public PatientService(HMISContext db)
        {
            this.db = db;
        }

        public void Add(Patient model)
        {
            db.Patients.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var getpatient = GetByID(id);
            getpatient.IsDeleted=true;
            db.SaveChanges();
        }

        public List<Patient> GetAll()
        {
            var list = db.Patients.Where(x => x.IsDeleted==false).ToList();
            return list;
        }

        public Patient GetByID(int id)
        {
            var getpatient = db.Patients.FirstOrDefault(x => x.PatientId == id);
            return getpatient;
        }

        public List<Patient> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient model)
        {
            var getpatient = GetByID(model.PatientId);
            getpatient.PatientName = model.PatientName;
            getpatient.PatientAddress = model.PatientAddress;
            getpatient.PatientTel1=model.PatientTel1;
            getpatient.PatientTel2 = model.PatientTel2;
            getpatient.PatientEmail = model.PatientEmail;
            getpatient.PatientNid=model.PatientNid;
            getpatient.PatientGender = model.PatientGender;
            //getpatient.IsDeleted = model.IsDeleted;
            db.SaveChanges();
        }
    }
}
