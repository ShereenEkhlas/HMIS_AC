using HMIS_AC.Models;
using Microsoft.EntityFrameworkCore;

namespace HMIS_AC.IServices
{
    public class EmployeeService : IBaseService<Employess>
    {
        private readonly HMISContext db;
        public EmployeeService(HMISContext db)
        {
            this.db = db;
        }

        public void Add(Employess model)
        {
            db.Employesses.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //var getpatient = GetByID(id);
            //getpatient.IsDeleted = true;
            //db.SaveChanges();
        }

        public List<Employess> GetAll()
        {
            var list = db.Employesses.Include(x => x.EmployessContracts).ToList();
            return list;
        }

        public Employess GetByID(int id)
        {
            var getemployee = db.Employesses.FirstOrDefault(x => x.EmployeeId == id);
            return getemployee;
        }

        public List<Employess> Search(string name)
        {
            throw new NotImplementedException();
        }

         
        public void Update(Employess model)
        {
            var getemployee = GetByID(model.EmployeeId);
            getemployee.EmployeeName = model.EmployeeName;
            getemployee.EmployeeAddress = model.EmployeeAddress;
            getemployee.EmployeeTel = model.EmployeeTel;
            getemployee.EmployeeTel2 = model.EmployeeTel2;
            getemployee.EmployeeEmail = model.EmployeeEmail;
            getemployee.DepartId= model.DepartId;
            getemployee.HiringDate = model.HiringDate;


            //Must Create new Username and passward for new department 
            //if (getemployee.DepartId != model.DepartId)
            //getemployee.DepartId = model.DepartId;




            db.SaveChanges();
        }
    }
}
