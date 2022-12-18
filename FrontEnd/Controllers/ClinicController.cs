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
                ServiceRepository serviceObj = new ServiceRepository();
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
            ProvinceHelper provinceHelper= new ProvinceHelper();
            List<ProvinceViewModel> provinces = provinceHelper.GetAll();

            return provinces;
        }

        private DoctorViewModel GetDoctor(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
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
            DoctorHelper doctorHelper = new DoctorHelper();
            List<DoctorViewModel> doctors = doctorHelper.GetAll();

            return doctors;
        }



        // GET: HomeController1
        public ActionResult Index()
        {
            List<ClinicViewModel> clinics = clinicaHelper.GetAll();

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
                ClinicViewModel clinic = clinicaHelper.Details(id);
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
                clinicaHelper.Create(clinic);
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
            model = clinicaHelper.Edit(id);

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
                clinicaHelper.EditResult(clinic);
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
            model = clinicaHelper.Delete(id);
            model.Province = GetProvince(model.ProvinceId);
            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClinicViewModel clinic)
        {
            bool Eliminado = clinicaHelper.DeleteResponse(clinic);

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
