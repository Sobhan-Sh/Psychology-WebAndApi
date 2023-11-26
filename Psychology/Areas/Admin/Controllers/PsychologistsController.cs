using Dto.Psychologist;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Psychology.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PsychologistsController : Controller
    {
        private readonly IPsychologistService _psychologistService;

        public PsychologistsController(IPsychologistService psychologistService)
        {
            _psychologistService = psychologistService;
        }

        public async Task<IActionResult> Index(string? renderMessage)
        {
            BaseResult<List<PsychologistViewModel>> result = await _psychologistService.GetAllAsync();
            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            return View(result.Data);
        }

        #region CreatePsychologist

        public async Task<IActionResult> CreatePsychologist(int userId)
        {
            BaseResult<IsCheckedUser> result = await _psychologistService.IsChecked(userId);
            if (result.IsSuccess)
            {
                if (result.Data.IsPatient)
                    return Redirect("/Admin/Users?renderMessage=" + result.Message);

                ViewData["UserId"] = userId;
                ViewData["Time"] = DateTime.Now.ToString();
                ViewData["Message"] = result.Message;
                return View();
            }

            return Redirect("/Admin/Users?renderMessage=" + result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePsychologist(CreatePsychologist psychologist)
        {
            if (ModelState.IsValid)
            {
                BaseResult result = await _psychologistService.CreateAsync(psychologist);
                if (result.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = result.Message });

            }

            ViewData["UserId"] = psychologist.UserId;
            ViewData["Time"] = DateTime.Now.ToString();
            return View();
        }

        #endregion

    }
}
