using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MRI.ImageGallery.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        [Authorize]
        // clear local cookies
        public async Task Logout()
        {
            //this will logout user from local browser
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            //this will logout user from IDP

            // Redirects to the IDP linked to scheme
            // "OpenIdConnectDefaults.AuthenticationScheme" (oidc)
            // so it can clear its own session/cookie
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
