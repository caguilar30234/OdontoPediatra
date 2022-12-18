using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentViewModel model = new AppointmentViewModel();
        AppointmentHelper appointmentHelper= new AppointmentHelper();

        private ScheduleViewModel GetSchedule(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository(token);
                HttpResponseMessage response = serviceObj.GetResponse("api/schedule/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                ScheduleViewModel scheduleViewModel = response.Content.ReadAsAsync<ScheduleViewModel>().Result;
                return scheduleViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<ScheduleViewModel> GetSchedules()
        {
            string token = HttpContext.Session.GetString("token");
            ScheduleHelper scheduleHelper = new ScheduleHelper();
            ScheduleViewModel schedule = new ScheduleViewModel();
            List<ScheduleViewModel> schedules = scheduleHelper.GetAll(token);

            return schedules;
        }



        private PatientViewModel GetPatient(int id)
        {
            string token = HttpContext.Session.GetString("token");
            PatientHelper patientHelper= new PatientHelper();
            PatientViewModel patient= new PatientViewModel();
            patient = patientHelper.GetPatient(id, token);

            return patient;
        }
        private List<PatientViewModel> GetPatients()
        {
            string token = HttpContext.Session.GetString("token");
            PatientHelper patientHelper = new PatientHelper();
            PatientViewModel patient = new PatientViewModel();
            List<PatientViewModel> patients = patientHelper.GetAll(token);

            return patients;
        }


        // GET: AppointmentController
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            List<AppointmentViewModel> appointments = appointmentHelper.GetAll(token);

            foreach (var item in appointments)
            {
                item.Schedule = GetSchedule(item.ScheduleId);
                item.Patient= GetPatient(item.PatientId);
            }


            return View(appointments);
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                AppointmentViewModel appointmentViewModel = appointmentHelper.Details(id, token);

                appointmentViewModel.Patient = GetPatient(appointmentViewModel.PatientId);
                appointmentViewModel.Schedule = GetSchedule(appointmentViewModel.ScheduleId);

                return View(appointmentViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            AppointmentViewModel appointment = new AppointmentViewModel { };
            appointment.Schedules = GetSchedules();
            appointment.Patients = GetPatients();
            
            
            return View(appointment);
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentViewModel appointment)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                appointmentHelper.Create(appointment, token);
                
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

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = appointmentHelper.Details(id, token);

            model.Schedules = GetSchedules();

            return View(model);
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointmentViewModel appointmentViewModel)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                appointmentHelper.EditResult(appointmentViewModel, token);
                return RedirectToAction("Details", new { id = appointmentViewModel.AppoinmentId });
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = appointmentHelper.Delete(id, token);
            model.Patient = GetPatient(model.PatientId);
            model.Schedule = GetSchedule(model.ScheduleId);
            return View(model);
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AppointmentViewModel appointment)
        {
            string token = HttpContext.Session.GetString("token");
            bool Eliminado = appointmentHelper.DeleteResponse(appointment, token);

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
