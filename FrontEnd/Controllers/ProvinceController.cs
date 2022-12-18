using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceViewModel model = new ProvinceViewModel();
        ProvinceHelper provinceHelper = new ProvinceHelper();

        // GET: ProvinceController
        public ActionResult Index()
        {
            List<ProvinceViewModel> Provinces = provinceHelper.GetAll();

            return View(Provinces);
        }

        // GET: ProvinceController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ProvinceViewModel Province = provinceHelper.Details(id);
                return View(Province);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: ProvinceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvinceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProvinceViewModel Province)
        {
            try
            {
                provinceHelper.Create(Province);
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

        // GET: ProvinceController/Edit/5
        public ActionResult Edit(int id)
        {
            model = provinceHelper.Details(id);

            return View(model);
        }

        // POST: ProvinceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProvinceViewModel Province)
        {
            try
            {
                provinceHelper.EditResult(Province);
                return RedirectToAction("Details", new { id = Province.ProvinceId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProvinceController/Delete/5
        public ActionResult Delete(int id)
        {
            model = provinceHelper.Delete(id);
            return View(model);
        }

        // POST: ProvinceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProvinceViewModel Province)
        {
            bool Eliminado = provinceHelper.DeleteResponse(Province);

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
