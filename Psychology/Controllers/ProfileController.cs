using Dto.User;
using Dto.User.Gender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.IService.User;
using System.Security.Claims;
using Utility.ReturnFuncResult;

namespace Psychology.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGenderService _genderService;

        public ProfileController(IUserService userService, IGenderService genderService)
        {
            _userService = userService;
            _genderService = genderService;
        }

        [Route("/Profile")]
        public async Task<IActionResult> Profile()
        {
            BaseResult<EditUser> user = await _userService.GetAsync(Id: Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            BaseResult<List<GenderViewModel>> gender = await _genderService.GetAllAsync();
            ViewData["listGender"] = new SelectList(gender.Data, "Id", "Name", user.Data.GenderId);
            return View(user.Data);
        }

        [HttpPost]
        [Route("/Profile")]
        public async Task<IActionResult> Profile(EditUser user)
        {
            string message;
            if (ModelState.IsValid)
            {
                BaseResult response = await _userService.UpdateAsync(user);
                message = response.Message;
            }

            return RedirectToAction("Profile");
        }
    }
}
