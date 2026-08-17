using CisCore.Helper;
using CisCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CisCore.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMailService _mailService;

        public ContactController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Mail model)
        {
            if (ModelState.IsValid)
            {
                await _mailService.SendEmailAsync(model);
                return View("Thankyou");
            }

            PopulateDropdowns();
            return View(model);
        }

        private void PopulateDropdowns()
        {
            ViewBag.Roles = new SelectList(new[]
            {
                new { Name = "Owner / CEO" },
                new { Name = "Professional" },
                new { Name = "Others" }
            }, "Name", "Name");

            ViewBag.Services = new SelectList(new[]
            {
                new { Name = "Web Development" },
                new { Name = "App Development" },
                new { Name = "UI/UX Designing" },
                new { Name = "QA & Testing" },
                new { Name = "E-commerce" }
            }, "Name", "Name");
        }
    }
}
