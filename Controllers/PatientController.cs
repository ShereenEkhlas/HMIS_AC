using HMIS_AC.IServices;
using HMIS_AC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HMIS_AC.Controllers
{
    public class PatientController : Controller
    {

        private readonly IBaseService<Patient> patientservice;
        public PatientController(IBaseService<Patient> patientservice)
        {
            this.patientservice = patientservice;   
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult LoadPatients()
        {
            return View();
        }


        [HttpGet]
        public string LoadJsonPatients()
        {
            List<Patient> patients =patientservice.GetAll();

            //return Json(new { data = patients });
            string serializedData = JsonConvert.SerializeObject(new { data = patients });
            return serializedData;


        }



        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            try
            {
                patient.CreationDate=DateTime.Now;
                patient.LastUpdateDate = DateTime.Now;
                patient.LastUpdateFrom = HttpContext.Connection.RemoteIpAddress.ToString();
                patient.LastUpdateBy= User.FindFirstValue(ClaimTypes.Name);

                patientservice.Add(patient);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }

            
        }



        [HttpGet]
        public IActionResult EditPatient(int id)
        {
            var getpatient=patientservice.GetByID(id);

            return View(getpatient);
        }

        [HttpPost]
        public IActionResult EditPatient(Patient patient)
        {

            try
            {
                patientservice.Update(patient);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(patient);
            }
        }



        [HttpPost]
        public String DeletePatient(int id)
        {



            patientservice.Delete(id);
            
            var res = new
            {
                deleted = true
            };

            string serializedData = JsonConvert.SerializeObject(res);
            return serializedData;

            // return delete_ok;


        }





        public IActionResult PatientDetails(int id)
        {

         
                return View();  
        }





    }
}
