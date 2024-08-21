using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
//using MyPortfolio.Services;
using System.Diagnostics;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        //private readonly EmailService _emailService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //_emailService = emailService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Socials()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SendContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //_emailService.SendEmail(model.Email, "Contact Form Submission", model.Message);
                return RedirectToAction("ContactConfirmation");
            }
            return View("Contact", model);
        }

        public IActionResult ContactConfirmation()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}