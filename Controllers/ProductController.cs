using Microsoft.AspNetCore.Mvc;

namespace CisCore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index() => View();
    }
}
