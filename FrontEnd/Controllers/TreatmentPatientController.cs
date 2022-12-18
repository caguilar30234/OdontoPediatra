using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TreatmentPatientController : Controller
    {
        TreatmentPatientViewModel model = new TreatmentPatientViewModel();
        TreatmentPatientHelper treatmentPatientHelper = new TreatmentPatientHelper();


        private PatientViewModel GetPatient(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository(token);
                HttpResponseMessage response = serviceObj.GetResponse("api/Patient/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                PatientViewModel patientViewModel = response.Content.ReadAsAsync<PatientViewModel>().Result;
                return patientViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<PatientViewModel> GetPatients()
        {
            string token = HttpContext.Session.GetString("token");
            PatientHelper patientHelper = new PatientHelper();
            List<PatientViewModel> patients = patientHelper.GetAll(token);

            return patients;
        }

        private TreatmentViewModel GetTreatment(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository(token);
                HttpResponseMessage response = serviceObj.GetResponse("api/treatment/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                TreatmentViewModel treatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;
                return treatmentViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<TreatmentViewModel> GetTreatments()
        {
            string token = HttpContext.Session.GetString("token");
            TreatmentHelper treatmentHelper = new TreatmentHelper();
            List<TreatmentViewModel> treatments = treatmentHelper.GetAll(token);

            return treatments;
        }



        // GET: HomeController1
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            List<TreatmentPatientViewModel> treatmentPatients = treatmentPatientHelper.GetAll(token);

            foreach (var item in treatmentPatients)
            {
                item.Treatment = GetTreatment(item.TreatmentId);
                item.Patient = GetPatient(item.PatientId);
            }

            return View(treatmentPatients);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                TreatmentPatientViewModel treatmentPatient = treatmentPatientHelper.Details(id, token);
                treatmentPatient.Patient = GetPatient(treatmentPatient.PatientId);
                return View(treatmentPatient);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            TreatmentPatientViewModel treatmentPatient = new TreatmentPatientViewModel { };
            treatmentPatient.Patients = GetPatients();
            treatmentPatient.Treatments = GetTreatments();
            return View(treatmentPatient);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentPatientViewModel treatmentPatient)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                treatmentPatientHelper.Create(treatmentPatient,token);

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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = treatmentPatientHelper.Edit(id, token);

            model.Patients = GetPatients();
            model.Treatments = GetTreatments();

            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TreatmentPatientViewModel treatmentPatient)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                treatmentPatientHelper.EditResult(treatmentPatient, token);
                return RedirectToAction("Details", new { id = treatmentPatient.TreatmentPatientId });
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = treatmentPatientHelper.Delete(id, token);
            model.Patient = GetPatient(model.PatientId);
            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TreatmentPatientViewModel treatmentPatient)
        {
            string token = HttpContext.Session.GetString("token");
            bool Eliminado = treatmentPatientHelper.DeleteResponse(treatmentPatient, token);

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
