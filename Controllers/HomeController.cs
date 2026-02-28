using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using System.Diagnostics;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HomeController(
            ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendContact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact", model);
            }

            var accessKey = _configuration["Web3Forms:AccessKey"];
            if (string.IsNullOrWhiteSpace(accessKey))
            {
                _logger.LogError("Web3Forms access key is not configured.");
                ModelState.AddModelError(string.Empty, "Contact form is temporarily unavailable. Please try again later.");
                return View("Contact", model);
            }

            using var client = _httpClientFactory.CreateClient();
            using var content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("access_key", accessKey),
                new KeyValuePair<string, string>("name", model.Name),
                new KeyValuePair<string, string>("email", model.Email),
                new KeyValuePair<string, string>("message", model.Message),
                new KeyValuePair<string, string>("subject", "Portfolio Contact Form Submission")
            ]);

            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync("https://api.web3forms.com/submit", content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send contact form to Web3Forms.");
                ModelState.AddModelError(string.Empty, "Message failed to send. Please try again.");
                return View("Contact", model);
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Web3Forms returned status code {StatusCode}", response.StatusCode);
                ModelState.AddModelError(string.Empty, "Message failed to send. Please try again.");
                return View("Contact", model);
            }

            return RedirectToAction(nameof(ContactConfirmation));
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
