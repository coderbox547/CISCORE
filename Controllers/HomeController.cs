using Microsoft.AspNetCore.Mvc;

namespace CisCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        // These actions scroll to sections on the home page
        public IActionResult Services()  => View("Index");
        public IActionResult Process()   => View("Index");
        public IActionResult Testimonials() => View("Index");

        // Ecommerce is its own view
        public IActionResult Ecommerce() => View("Ecommerce");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
