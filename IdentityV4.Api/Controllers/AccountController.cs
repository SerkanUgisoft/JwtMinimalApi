using IdentityServer4.Services;
using IdentityServer4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using IdentityV4.Api.Models;
using IdentityV4.Api.Services;

namespace IdentityV4.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IUserService _userService;

        public AccountController(IIdentityServerInteractionService interaction, IUserService userService)
        {
            _interaction = interaction;
            _userService = userService;
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _userService.GetByUsername(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "User or password are not correct");
                return View(model);
            }
            //could do password check;

            var identityServerUser = new IdentityServerUser(user.Id.ToString());
            await HttpContext.SignInAsync(identityServerUser);
            return Redirect(model.ReturnUrl);
        }
        public async Task<IActionResult> Logout(string logoutId)
        {
            var client = await _interaction.GetLogoutContextAsync(logoutId);
            if (string.IsNullOrEmpty(client.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "Home");
            }
            //await HttpContext.SignOutAsync();
            return Redirect(client.PostLogoutRedirectUri);
        }
    }
}
