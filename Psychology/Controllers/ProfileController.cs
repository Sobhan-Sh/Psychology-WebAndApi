using Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService.User;
using System.Security.Claims;
using Utility.ReturnFuncResult;

namespace Psychology.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/Profile")]
        public async Task<IActionResult> Profile()
        {
            BaseResult<EditUser> user = await _userService.GetAsync(Id: Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            return View("Porfille", user.Data);
        }



        //public ActionResult 
    }
}
