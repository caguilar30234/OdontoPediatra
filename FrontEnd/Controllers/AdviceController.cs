using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    public class AdviceController : Controller
    {
        AdviceViewModel model = new AdviceViewModel();
        AdviceHelper adviceHelper = new AdviceHelper();

        public ActionResult Index()
        {

            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Advice");

            switch (responseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    return RedirectToAction("Login", "Home");
                case System.Net.HttpStatusCode.OK:
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    List<AdviceViewModel> personas = JsonConvert.DeserializeObject<List<AdviceViewModel>>(content);
                    return View(personas);
                default:
                    return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
               AdviceViewModel advice = adviceHelper.Details(id);
                return View(advice);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdviceViewModel advice, List<IFormFile> fileUpload)
        {
            try
            {
                adviceHelper.Create(advice, fileUpload);
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

        public ActionResult Edit(int id)
        {

            model = adviceHelper.Details(id);

            return View(model);
        }

        //POST: AdviController/Edit with Picture List<IFormFile> fileUpload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdviceViewModel advice, List<IFormFile> fileUpload)
        {
            adviceHelper.Edit(advice, fileUpload);
            return RedirectToAction("Details", new { id = advice.AdviceId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            model = adviceHelper.Details(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(AdviceViewModel advice)
        {
            bool Eliminado = adviceHelper.Delete(advice);

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
