using Microsoft.AspNetCore.Mvc;

namespace AuthenAuthorCookie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
