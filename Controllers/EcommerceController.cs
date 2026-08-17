using Microsoft.AspNetCore.Mvc;

namespace CisCore.Controllers
{
    public class EcommerceController : Controller
    {
        public IActionResult Index() => View();
    }
}
