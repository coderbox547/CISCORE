using CisCore.Helper;
using CisCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CisCore.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IMailService _mailService;

        public PortfolioController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Mail model)
        {
            if (ModelState.IsValid)
            {
                await _mailService.SendEmailAsync(model);
                return View("Thankyou");
            }
            return View(model);
        }
    }
}
