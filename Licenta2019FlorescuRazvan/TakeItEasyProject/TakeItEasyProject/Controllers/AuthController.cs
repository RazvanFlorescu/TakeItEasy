using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace TakeItEasyProject.Controllers
{
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationSchemeProvider authenticationSchemeProvider;

        public AuthController(IAuthenticationSchemeProvider authenticationSchemeProvider)
        {
            this.authenticationSchemeProvider = authenticationSchemeProvider;
        }
     
        [HttpGet("facebookLogin")]
        public async Task<IActionResult> Login()
        {
            var allSchemeProvider = (await authenticationSchemeProvider.GetAllSchemesAsync())
                .Select(n => n.DisplayName).Where(n => !string.IsNullOrEmpty(n));

            return Ok(allSchemeProvider);
        }

        [HttpGet("facebookSignin")]
        public IActionResult SignIn(string provider)
        {
            return Ok(Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Facebook"));
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}



