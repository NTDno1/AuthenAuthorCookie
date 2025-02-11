using Microsoft.AspNetCore.Mvc;

namespace AuthenAuthorCookie.Controllers
{
    public class AdminPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
