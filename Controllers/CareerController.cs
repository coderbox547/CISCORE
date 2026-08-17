using CisCore.Helper;
using CisCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CisCore.Controllers
{
    public class CareerController : Controller
    {
        private readonly IMailService _mailService;

        public CareerController(IMailService mailService)
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
            ViewBag.Positions = new SelectList(new[]
            {
                new { Name = "Senior .Net Developer" },
                new { Name = "Wordpress Developer" }
            }, "Name", "Name");
        }
    }
}
