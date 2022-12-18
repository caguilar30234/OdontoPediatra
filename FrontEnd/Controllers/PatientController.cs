using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PatientController : Controller
    {
        PatientViewModel model = new PatientViewModel();
        PatientHelper patientHelper = new PatientHelper();

        private EducationViewModel GetEducation(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository(token);
                HttpResponseMessage response = serviceObj.GetResponse("api/education/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                EducationViewModel educationViewModel = response.Content.ReadAsAsync<EducationViewModel>().Result;
                return educationViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<EducationViewModel> GetEducations()
        {
            string token = HttpContext.Session.GetString("token");
            EducationHelper educationHelper = new EducationHelper();
            EducationViewModel education = new EducationViewModel();
            List<EducationViewModel> schedules = educationHelper.GetAll(token);

            return schedules;
        }

        // GET: PatientController
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            List<PatientViewModel> Patients = patientHelper.GetAll(token);
            foreach (var item in Patients)
            {
                item.Education = GetEducation(item.EducationId);
            }

            return View(Patients);
        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                PatientViewModel Patient = patientHelper.Details(id, token);
                Patient.Education = GetEducation(Patient.EducationId);
                return View(Patient);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            PatientViewModel patient = new PatientViewModel { };
            patient.Educations = GetEducations();
            return View(patient);
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientViewModel Patient)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                patientHelper.Create(Patient, token);
                return RedirectToAction("Index");
            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Error", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = patientHelper.Details(id, token);
            model.Educations = GetEducations();

            return View(model);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientViewModel Patient)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                patientHelper.EditResult(Patient, token);
                return RedirectToAction("Details", new { id = Patient.PatientId });
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = patientHelper.Delete(id, token);
            model.Education = GetEducation(model.EducationId);
            return View(model);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PatientViewModel Patient)
        {
            string token = HttpContext.Session.GetString("token");
            bool Eliminado = patientHelper.DeleteResponse(Patient, token);

            if (Eliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
