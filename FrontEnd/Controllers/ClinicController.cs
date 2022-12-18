using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ClinicController : Controller
    {
        ClinicViewModel model = new ClinicViewModel();
        ClinicaHelper clinicaHelper = new ClinicaHelper();


        private ProvinceViewModel GetProvince(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository(token);
                HttpResponseMessage response = serviceObj.GetResponse("api/province/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                ProvinceViewModel provinceViewModel = response.Content.ReadAsAsync<ProvinceViewModel>().Result;
                return provinceViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<ProvinceViewModel> GetProvinces()
        {
            string token = HttpContext.Session.GetString("token");
            ProvinceHelper provinceHelper= new ProvinceHelper();
            List<ProvinceViewModel> provinces = provinceHelper.GetAll(token);

            return provinces;
        }

        private DoctorViewModel GetDoctor(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository(token);
                HttpResponseMessage response = serviceObj.GetResponse("api/doctor/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                DoctorViewModel doctorViewModel = response.Content.ReadAsAsync<DoctorViewModel>().Result;
                return doctorViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<DoctorViewModel> GetDoctors()
        {
            string token = HttpContext.Session.GetString("token");
            DoctorHelper doctorHelper = new DoctorHelper();
            List<DoctorViewModel> doctors = doctorHelper.GetAll(token);

            return doctors;
        }



        // GET: HomeController1
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            List<ClinicViewModel> clinics = clinicaHelper.GetAll(token);

            foreach (var item in clinics)
            {
                item.Province = GetProvince(item.ProvinceId);
                item.Doctor = GetDoctor(item.DoctorId);
            }

            return View(clinics);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                ClinicViewModel clinic = clinicaHelper.Details(id, token);
                clinic.Province = GetProvince(clinic.ProvinceId);
                return View(clinic);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            ClinicViewModel clinic = new ClinicViewModel { };
            clinic.Provinces = GetProvinces();
            return View(clinic);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicViewModel clinic)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                clinicaHelper.Create(clinic, token);
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
            model = clinicaHelper.Edit(id, token);

            model.Provinces = GetProvinces();

            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicViewModel clinic)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                clinicaHelper.EditResult(clinic,token);
                return RedirectToAction("Details", new { id = clinic.ClinicId });
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
            model = clinicaHelper.Delete(id, token);
            model.Province = GetProvince(model.ProvinceId);
            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClinicViewModel clinic)
        {
            string token = HttpContext.Session.GetString("token");
            bool Eliminado = clinicaHelper.DeleteResponse(clinic, token);

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
