using Microsoft.AspNetCore.Mvc;

namespace CisCore.Controllers
{
    public class SolutionController : Controller
    {
        public IActionResult Index() => View();
    }
}
