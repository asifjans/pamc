using Microsoft.AspNetCore.Mvc;
using ParadiseAvenueMuslimCemetery.Models;

namespace ParadiseAvenueMuslimCemetery.Controllers
{
    public class DonateController : Controller
    {
        private readonly IEmailSender _emailSender;
        
        public DonateController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Email email)
        {
            await _emailSender.SendEmailAsync(email.Name, email.EmailAddress, email.Amount);
            return View();
        }
    }
}
