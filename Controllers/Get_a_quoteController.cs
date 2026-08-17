using CisCore.Helper;
using CisCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CisCore.Controllers
{
    public class Get_a_quoteController : Controller
    {
        private readonly IMailService _mailService;

        public Get_a_quoteController(IMailService mailService)
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

            ViewBag.Countries = new SelectList(new[]
            {
                new { Name = "Australia" },
                new { Name = "USA" },
                new { Name = "Canada" }
            }, "Name", "Name");
        }
    }
}
