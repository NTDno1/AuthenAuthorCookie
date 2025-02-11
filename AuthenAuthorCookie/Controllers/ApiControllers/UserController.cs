using Microsoft.AspNetCore.Mvc;

namespace AuthenAuthorCookie.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            return Ok("GetUser");
        }
    }
}
