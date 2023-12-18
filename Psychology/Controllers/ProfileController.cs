using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC.Dto.Discount;
using PC.Dto.Patient;
using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Dto.User;
using PC.Dto.User.Gender;
using PC.Service.IService.DiscountAndOrder;
using PC.Service.IService.Patient;
using PC.Service.IService.Psychologist;
using PC.Service.IService.User;
using PC.Utility.Auth.IAuth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGenderService _genderService;
        private readonly IPsychologistService _ipsychologistService;
        private readonly IAuthHelper _authHelper;
        private readonly IPatientService _petientService;
        private readonly IDiscountService _discountService;

        private static string RenderMessageStatic;

        public ProfileController(IUserService userService, IGenderService genderService, IPsychologistService ipsychologistService, IAuthHelper authHelper, IPatientService petientService, IDiscountService discountService)
        {
            _userService = userService;
            _genderService = genderService;
            _ipsychologistService = ipsychologistService;
            _authHelper = authHelper;
            _petientService = petientService;
            _discountService = discountService;
        }

        [Route("/Profile")]
        public async Task<IActionResult> Profile()
        {
            BaseResult<EditUser> user = await _userService.GetAsync(Id: _authHelper.CurrentAccountId());
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

        #region PsychologistProfile

        public async Task<IActionResult> MyPatient()
        {
            BaseResult<List<PatientTurnViewModel>> result = await _ipsychologistService.PatientMy(_authHelper.CurrentAccountId());
            if (RenderMessageStatic == null)
                RenderMessageStatic = "";
            else if (!string.IsNullOrWhiteSpace(RenderMessageStatic))
            {
                ViewData["RenderMessage"] = RenderMessageStatic;
                RenderMessageStatic = "";
            }

            return View(result.Data);
        }

        public async Task<IActionResult> EditPatientMy(int patientId)
        {
            BaseResult<PatientViewModel> resultPatient = await _petientService.GetAsync(patientId);
            if (resultPatient.IsSuccess)
            {
                BaseResult<List<GenderViewModel>> resultGender = await _genderService.GetAllAsync();
                ViewData["listGender"] = new SelectList(resultGender.Data, "Id", "Name",
                    resultPatient.Data.UserViewModel.GenderViewModel.Id);

                return View(resultPatient.Data);
            }

            return RedirectToAction("MyPatient");
        }

        [HttpPost]
        public async Task<IActionResult> EditPatientMy(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                BaseResult resultPatient = await _petientService.UpdateAsync(patientViewModel);
                RenderMessageStatic = resultPatient.Message;
                return RedirectToAction("MyPatient");
            }

            return RedirectToAction("EditPatientMy", new { patientId = patientViewModel.Id });
        }

        public async Task<IActionResult> Visited(int patientId)
        {
            BaseResult result = await _petientService.Visited(patientId);
            RenderMessageStatic = result.Message;
            return RedirectToAction("MyPatient");
        }

        public async Task<IActionResult> ChangeToPatient(int patientId)
        {
            BaseResult result = await _petientService.ChangeToPatient(patientId);
            RenderMessageStatic = result.Message;
            return RedirectToAction("MyPatient");
        }

        public async Task<IActionResult> RestorPatient(int patientId)
        {
            BaseResult result = await _petientService.RestorPatient(patientId);
            RenderMessageStatic = result.Message;
            return RedirectToAction("MyPatient");
        }

        public async Task<IActionResult> MyIncome()
        {
            BaseResult<List<MyIncome>> result = await _ipsychologistService.MyIncome(_authHelper.CurrentAccountId());
            return View(result.Data);
        }

        public async Task<IActionResult> DiscountPatient(int patientId)
        {
            BaseResult<DiscountViewModel> result = await _discountService.GetByPatientId(patientId);
            return View(result.Data);
        }

        #endregion
    }
}
