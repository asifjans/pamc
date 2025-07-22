using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ParadiseAvenueMuslimCemetery.Models;
using System.Diagnostics;

namespace ParadiseAvenueMuslimCemetery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendQuickEmail([FromForm] ParadiseAvenueMuslimCemetery.Models.Email email)
        {
            if (string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                return BadRequest("Email is required.");
            }

            await _emailSender.SendEmailForSignupAsync(email);
            return Ok("Email sent successfully.");
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Donation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Donation(ParadiseAvenueMuslimCemetery.Models.Email email)
        {
            await _emailSender.SendEmailAsync(email.Name, email.EmailAddress, email.Amount);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
