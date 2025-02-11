using Microsoft.AspNetCore.Mvc;

namespace AuthenAuthorCookie.Controllers.ViewControllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
