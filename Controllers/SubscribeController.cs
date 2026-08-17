using CisCore.Helper;
using CisCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CisCore.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IMailService _mailService;

        public SubscribeController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Mail model)
        {
            await _mailService.SendEmailAsync(model);
            return View("Index");
        }
    }
}
