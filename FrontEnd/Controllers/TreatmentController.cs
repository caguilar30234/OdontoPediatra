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
            List<TreatmentViewModel> Treatments = TreatmentHelper.GetAll();

            return View(Treatments);
        }

        // GET: TreatmentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TreatmentViewModel Treatment = TreatmentHelper.Details(id);
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
                TreatmentHelper.Create(Treatment);
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
            model = TreatmentHelper.Details(id);

            return View(model);
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TreatmentViewModel Treatment)
        {
            try
            {
                TreatmentHelper.EditResult(Treatment);
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
            model = TreatmentHelper.Delete(id);
            return View(model);
        }

        // POST: TreatmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TreatmentViewModel Treatment)
        {
            bool Eliminado = TreatmentHelper.DeleteResponse(Treatment);

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
            List<TreatmentViewModel> Treatments = TreatmentHelper.GetAll();

            var servicios = Json(Treatments.ToList());
            return servicios;
        }
    }
}
