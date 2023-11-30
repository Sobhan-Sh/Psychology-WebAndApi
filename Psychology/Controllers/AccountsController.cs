using Dto.account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Account;
using System.Security.Claims;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Psychology.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthService _authService;

        public AccountsController(IAuthService authService)
        {
            _authService = authService;
        }

        #region Login

        public IActionResult Login(string ReturnUrl = "/")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login log, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                BaseResult<LoginResult> response = await _authService.LoginAsync(log);
                if (response.IsSuccess && response.StatusCode == ValidationCode.Success)
                {
                    //TODO: اینجا باید من اعتبار سنجی کنم اگر کاربر گوشیش فعال نبود بره به صفحه فعال کردن گوشی
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.MobilePhone, response.Data.Phone),
                        new Claim(ClaimTypes.Role, response.Data.Role),
                        new Claim(ClaimTypes.NameIdentifier, response.Data.UserId.ToString()),
                        new Claim("Token", response.Data.Token)
                       };

                    if (response.Data.Avatar != null) claims.Add(new Claim("Avatar", response.Data.Avatar));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                    {
                        IsPersistent = log.RemomberMe,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    });
                    return Redirect(ReturnUrl);
                }

                ViewBag.MessageError = response.Message;
            }

            return View("login", log);
        }

        #endregion

        #region Register

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register rgs)
        {
            if (!ModelState.IsValid)
                return View("Register", rgs);
            else
            {
                BaseResult response = await _authService.RegisterAsync(rgs);
                if (response.IsSuccess && response.StatusCode == ValidationCode.Success)
                {

                }
                return Redirect("/");
            }
        }

        #endregion

        #region Logout

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion
    }
}
