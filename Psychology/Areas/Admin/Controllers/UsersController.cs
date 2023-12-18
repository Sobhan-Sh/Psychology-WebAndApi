using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC.Dto.User.Gender;
using PC.Service.IService.User;
using PC.Utility.ReturnFuncResult;
using AdminChangePasswored = PC.Dto.User.AdminChangePasswored;
using CreateUser = PC.Dto.User.CreateUser;
using EditUser = PC.Dto.User.EditUser;
using ResultFindUserAuth = PC.Dto.User.ResultFindUserAuth;
using UserViewModel = PC.Dto.User.UserViewModel;

namespace Psychology.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGenderService _genderService;

        public UsersController(IUserService userService, IGenderService genderService)
        {
            _userService = userService;
            _genderService = genderService;
        }

        public async Task<IActionResult> Index(string? renderMessage)
        {
            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RnderMessage"] = renderMessage;

            BaseResult<List<UserViewModel>> result = await _userService.GetAllAsync();
            return View(result.Data);
        }

        #region block & onBlock & activePhone

        public async Task<IActionResult> OnBlock(int userId)
        {
            BaseResult result = await _userService.OnBlockAsync(userId);
            return RedirectToAction("Index", new { renderMessage = result.Message });
        }

        public async Task<IActionResult> Block(int userId)
        {
            BaseResult result = await _userService.BlockAsync(userId);
            return RedirectToAction("Index", new { renderMessage = result.Message });
        }

        public async Task<IActionResult> ActivePhone(int userId)
        {
            BaseResult result = await _userService.ActivePhone(userId);
            return RedirectToAction("Index", new { renderMessage = result.Message });
        }

        #endregion

        #region CreateUser

        public async Task<IActionResult> CreateUser()
        {
            BaseResult<List<GenderViewModel>> result = await _genderService.GetAllAsync();
            if (result.IsSuccess)
                ViewData["ListItemGender"] =
                    new SelectList(result.Data, "Id", "Name");

            ViewBag.DateTime = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser user)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _userService.CreateAsync(user);
                if (response.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = response.Message });

                ViewData["message"] = response.Message;
            }

            ViewBag.DateTime = DateTime.Now.ToString();
            BaseResult<List<GenderViewModel>> result = await _genderService.GetAllAsync();
            if (result.IsSuccess)
                ViewData["ListItemGender"] =
                    new SelectList(result.Data, "Id", "Name");

            return View();
        }

        #endregion

        #region UpdateUser

        public async Task<IActionResult> EditUser(int userId, string? renderMessage)
        {
            // get list genders
            BaseResult<List<GenderViewModel>> response = await _genderService.GetAllAsync();
            // get user
            BaseResult<EditUser> result = await _userService.GetAsync(userId);
            // send list gender in view
            ViewData["ListItemGender"] =
                new SelectList(response.Data, "Id", "Name", result.Data.GenderId);
            // print result
            ViewData["message"] = result.Message;
            // render(print error)
            if (string.IsNullOrEmpty(renderMessage))
                ViewData["RenderMessage"] = result.Message;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUser user)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                BaseResult result = await _userService.UpdateAsync(user);
                if (result.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = result.Message });

                message = result.Message;
            }

            return RedirectToAction("EditUser", new { userId = user.Id, renderMessage = message });
        }

        #endregion

        #region DeleteUser

        public async Task<IActionResult> DeleteUser(int userId)
        {
            BaseResult<UserViewModel> result = await _userService.ReturnViewGetAsync(userId);
            // print result
            if (!result.IsSuccess)
                ViewData["message"] = result.Message;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserViewModel user)
        {
            if (user.Id > 0)
            {
                BaseResult result = await _userService.DeleteAsync(user.Id);
                if (result.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = result.Message });

                ViewData["message"] = result.Message;
            }

            return RedirectToAction("DeleteUser", new { userId = user.Id });
        }

        #endregion

        #region ChangePassword

        public async Task<IActionResult> ChangePassword(int userId, string? renderMessage)
        {
            BaseResult<EditUser> result = await _userService.GetAsync(userId);
            if (!result.IsSuccess)
                return RedirectToAction("Index", new { renderMessage = result.Message });

            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["Message"] = renderMessage;

            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(AdminChangePasswored pas)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                BaseResult result = await _userService.ChangePasswordAsync(pas);
                if (result.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = result.Message });

                message = result.Message;
            }

            return RedirectToAction("ChangePassword", new { userId = pas.Id, renderMessage = message });
        }

        #endregion

        #region ChangeAuth

        public async Task<IActionResult> ChangeAuth(int userId, string? renderMessage)
        {
            BaseResult<ResultFindUserAuth> result = await _userService.ChangeAuth(userId);
            if (result.IsSuccess)
            {
                if (!string.IsNullOrWhiteSpace(renderMessage))
                    ViewData["Message"] = renderMessage;

                ViewBag.UserId = userId;
                ViewData["RoleViewModel"] = new SelectList(result.Data.RoleViewModels, "Id", "Name", result.Data.RoleId);
                return View();
            }

            return RedirectToAction("Index", new { renderMessage = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAuth(PC.Dto.User.ChangeAuth auth)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                BaseResult result = await _userService.ChangeAuth(auth);
                if (result.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = result.Message });

                message = result.Message; ;
            }

            return RedirectToAction("ChangeAuth", new { userId = auth.Id, renderMessage = message });
        }

        #endregion
    }
}
