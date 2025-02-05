using AuthenAuthorCookie.Models.RequestModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthenAuthorCookie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("unauthorized-v2")]
        public IActionResult GetUnauthorizedV2()
        {
            return Unauthorized();
        }

        [HttpGet("forbidden")]
        public HttpResponseMessage GetForbidden()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        }

        [HttpGet("signout")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Signout success");
        }

        [HttpPost("login-cookie")]
        public async Task<IActionResult> LoginCookieAsync([FromBody] UserRequestModel userRequestModel)
        {
            string userRole = string.Empty;

            if (userRequestModel.UserName.EndsWith("Admin"))
                userRole = "Admin";
            else if (userRequestModel.UserName.EndsWith("Administrator"))
                userRole = "Administrator";
            else
                userRole = "User";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userRequestModel.UserName),
                new Claim(ClaimTypes.Role, userRole),
                new Claim("FullName", "Nguyễn Tiến Đạt")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.
                AllowRefresh = true,

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.
                ExpiresUtc = DateTime.UtcNow.AddDays(1),

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.
                IsPersistent = true

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok();
        }
    }
}
