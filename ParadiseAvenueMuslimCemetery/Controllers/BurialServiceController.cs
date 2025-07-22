using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ParadiseAvenueMuslimCemetery.Models;

namespace ParadiseAvenueMuslimCemetery.Controllers
{
    public class BurialServiceController : Controller
    {
        private readonly IEmailSender _emailSender;

        public BurialServiceController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WhattoDoWhenSomeoneDies()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegistrationForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RegistrationForm(Registration registration)
        {
            
                await _emailSender.SendEmailForRegistrationAsync(registration);
         
            ModelState.Clear();
                return View();
        }
        public IActionResult PricingTiminig()
        {
            return View();
        }
        public IActionResult RulesRegulations()
        {
            return View();
        }
        public IActionResult CemeteryDirections()
        {
            return View();
        }
        public IActionResult FuneralHomes()
        {
            return View();
        }

    }
}
