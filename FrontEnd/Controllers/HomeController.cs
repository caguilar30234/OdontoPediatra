using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Text;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        TreatmentHelper TreatmentHelper = new TreatmentHelper();
        private readonly ILogger<HomeController> _logger;
        public HomeController( ILogger<HomeController> logger)
        {
                _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Paciente()
        {
            return View();
        }
        public IActionResult Usuario()
        {
            List<TreatmentViewModel> Treatments = TreatmentHelper.GetAll();

            return View(Treatments);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Authenticate/login", user);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;

                TokenModel tokenModel = JsonConvert.DeserializeObject<TokenModel>(content);

                HttpContext.Session.SetString("token", tokenModel.Token);


                var claim = new Claim(ClaimTypes.Role, tokenModel.Role);
                var identityRole = new ClaimsIdentity(new[] { claim });
                var principal = new ClaimsPrincipal(identityRole);
                HttpContext.User = principal;

                if (User.IsInRole("odontologo"))
                {

                    return RedirectToAction("Paciente");
                }
                if (User.IsInRole("paciente"))
                {

                    return RedirectToAction("Usuario");
                }

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {

                throw;
            }

        }

        #region logout
        /************ LOGOUT ***********************/
        public IActionResult Logout()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Authenticate/logout");
                if(response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                HttpContext.Session.Clear();
                HttpContext.Session.Remove("token");
                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel user)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Authenticate/register", user);
                response.EnsureSuccessStatusCode();

                return View("Login");

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult GeneratePDF() 
        {
            var Renderer = new IronPdf.HtmlToPdf();
            Renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A2;
            Renderer.RenderingOptions.ViewPortWidth = 1280;
            Renderer.RenderingOptions.EnableJavaScript= true;
            Renderer.RenderingOptions.RenderDelay= 1000;
            Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
            var doc = Renderer.RenderUrlAsPdf("http://localhost:5180/Home/Usuario");
            return File(doc.Stream.ToArray(), "application/pdf");
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAdmin(UserViewModel user)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Authenticate/register-admin", user);
                response.EnsureSuccessStatusCode();

                return View("Login");

            }
            catch (Exception)
            {

                throw;
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    






    }
}