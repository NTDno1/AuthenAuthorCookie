using Microsoft.AspNetCore.Mvc;

namespace AuthenAuthorCookie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page Test";
            return View();
        }
        public IActionResult UserPage()
        {
            return View();
        }
    }
}
