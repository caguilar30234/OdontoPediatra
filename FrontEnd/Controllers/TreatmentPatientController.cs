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
                ServiceRepository serviceObj = new ServiceRepository();
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
            PatientHelper patientHelper = new PatientHelper();
            List<PatientViewModel> patients = patientHelper.GetAll();

            return patients;
        }

        private TreatmentViewModel GetTreatment(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
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
            TreatmentHelper treatmentHelper = new TreatmentHelper();
            List<TreatmentViewModel> treatments = treatmentHelper.GetAll();

            return treatments;
        }



        // GET: HomeController1
        public ActionResult Index()
        {
            List<TreatmentPatientViewModel> treatmentPatients = treatmentPatientHelper.GetAll();

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
                TreatmentPatientViewModel treatmentPatient = treatmentPatientHelper.Details(id);
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
                treatmentPatientHelper.Create(treatmentPatient);

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
            model = treatmentPatientHelper.Edit(id);

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
                treatmentPatientHelper.EditResult(treatmentPatient);
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
            model = treatmentPatientHelper.Delete(id);
            model.Patient = GetPatient(model.PatientId);
            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TreatmentPatientViewModel treatmentPatient)
        {
            bool Eliminado = treatmentPatientHelper.DeleteResponse(treatmentPatient);

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
