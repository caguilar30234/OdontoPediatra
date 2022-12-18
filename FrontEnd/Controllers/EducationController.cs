using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EducationController : Controller
    {
        EducationViewModel model = new EducationViewModel();
        EducationHelper EducationHelper = new EducationHelper();
        // GET: EducationController
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            List<EducationViewModel> Educations = EducationHelper.GetAll(token);

            return View(Educations);
        }

        // GET: EducationController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                EducationViewModel Education = EducationHelper.Details(id);
                return View(Education);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: EducationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducationViewModel Education)
        {
            try
            {
                EducationHelper.Create(Education);
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

        // GET: EducationController/Edit/5
        public ActionResult Edit(int id)
        {
            model = EducationHelper.Details(id);

            return View(model);
        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EducationViewModel Education)
        {
            try
            {
                EducationHelper.EditResult(Education);
                return RedirectToAction("Details", new { id = Education.EducationId });
            }
            catch
            {
                return View();
            }
        }

        // GET: EducationController/Delete/5
        public ActionResult Delete(int id)
        {
            model = EducationHelper.Delete(id);
            return View(model);
        }

        // POST: EducationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EducationViewModel Education)
        {
            bool Eliminado = EducationHelper.DeleteResponse(Education);

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
