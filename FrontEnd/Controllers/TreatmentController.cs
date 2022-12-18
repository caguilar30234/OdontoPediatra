using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TreatmentController : Controller
    {
        TreatmentViewModel model = new TreatmentViewModel();
        TreatmentHelper TreatmentHelper = new TreatmentHelper();

        // GET: TreatmentController
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            List<TreatmentViewModel> Treatments = TreatmentHelper.GetAll(token);

            return View(Treatments);
        }

        // GET: TreatmentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                TreatmentViewModel Treatment = TreatmentHelper.Details(id, token);
                return View(Treatment);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: TreatmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentViewModel Treatment)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                TreatmentHelper.Create(Treatment, token);
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

        // GET: TreatmentController/Edit/5
        public ActionResult Edit(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = TreatmentHelper.Details(id, token);

            return View(model);
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TreatmentViewModel Treatment)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                TreatmentHelper.EditResult(Treatment,token);
                return RedirectToAction("Details", new { id = Treatment.TreatmentId });
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentController/Delete/5
        public ActionResult Delete(int id)
        {
            string token = HttpContext.Session.GetString("token");
            model = TreatmentHelper.Delete(id, token);
            return View(model);
        }

        // POST: TreatmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TreatmentViewModel Treatment)
        {
            string token = HttpContext.Session.GetString("token");
            bool Eliminado = TreatmentHelper.DeleteResponse(Treatment, token);

            if (Eliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        public JsonResult ConsultarTratamientosJson()
        {
            string token = HttpContext.Session.GetString("token");
            List<TreatmentViewModel> Treatments = TreatmentHelper.GetAll(token);

            var servicios = Json(Treatments.ToList());
            return servicios;
        }
    }
}
