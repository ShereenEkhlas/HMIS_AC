using Microsoft.AspNetCore.Mvc;
using HMIS_AC.Models;
using HMIS_AC.IServices;
using Newtonsoft.Json;

namespace HMIS_AC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IBaseService<Employess> employeeservice;
        private readonly HMISContext db;
        public EmployeeController(IBaseService<Employess> employeeservice, HMISContext db)
        {
            this.employeeservice = employeeservice;
            this.db = db;
        }



        public IActionResult Index()
        {

            return View();
        }

        public IActionResult LoadEmployee()
        {
            return View();
        }


        [HttpGet]
        public string LoadJsonEmployee()
        {
            List<Employess> employesses = employeeservice.GetAll();

            //return Json(new { data = employesses });
            string serializedData = JsonConvert.SerializeObject(new { data = employesses });
            return serializedData;

        }



        [HttpGet]
        public IActionResult AddEmployee()
        {
            var depts = db.Departments.Select(c => "<option value= '" + c.DepartmentId + "'>" + c.DepartmentName + "</option>");
            ViewBag.Departments = string.Join("", depts);

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employess employess)
        {
            try
            {
                //employess = DateTime.Now;
                //patient.LastUpdateDate = DateTime.Now;
                //patient.LastUpdateFrom = HttpContext.Connection.RemoteIpAddress.ToString();
                //patient.LastUpdateBy = User.FindFirstValue(ClaimTypes.Name);

                employeeservice.Add(employess);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }


        }



        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var depts = db.Departments.Select(c => "<option value= '" + c.DepartmentId + "'>" + c.DepartmentName + "</option>");
            ViewBag.Departments = string.Join("", depts);

            var getpatient = employeeservice.GetByID(id);

            return View(getpatient);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employess employess)
        {

            try
            {
                employeeservice.Update(employess);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(employess);
            }


        }



        //[HttpPost]
        //public String DeletePatient(int id)
        //{



        //    patientservice.Delete(id);

        //    var res = new
        //    {
        //        deleted = true
        //    };

        //    string serializedData = JsonConvert.SerializeObject(res);
        //    return serializedData;

        //    // return delete_ok;


        //}





        //public IActionResult PatientDetails(int id)
        //{


        //    return View();
        //}









    }
}
