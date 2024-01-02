using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC.Dto.Discount;
using PC.Dto.Order;
using PC.Dto.Patient;
using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Dto.Psychologist.Article;
using PC.Dto.Psychologist.Comment;
using PC.Dto.Psychologist.PsychologistAboutUs;
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
    // [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGenderService _genderService;
        private readonly IPsychologistService _ipsychologistService;
        private readonly IAuthHelper _authHelper;
        private readonly IPatientService _petientService;
        private readonly IDiscountService _discountService;
        private readonly IArticlesService _articlesService;
        private readonly IPsychologistAboutUsService _psychologistAboutUs;
        private readonly ICommentService _commentService;
        private readonly IOrderService _orderService;
        private readonly IPatientTurnService _petientTurnService;

        private static string RenderMessageStatic;

        public ProfileController(IUserService userService, IGenderService genderService, IPsychologistService ipsychologistService, IAuthHelper authHelper, IPatientService petientService, IDiscountService discountService, IArticlesService articlesService, IPsychologistAboutUsService psychologistAboutUs, ICommentService commentService, IOrderService orderService, IPatientTurnService petientTurnService)
        {
            _userService = userService;
            _genderService = genderService;
            _ipsychologistService = ipsychologistService;
            _authHelper = authHelper;
            _petientService = petientService;
            _discountService = discountService;
            _articlesService = articlesService;
            _psychologistAboutUs = psychologistAboutUs;
            _commentService = commentService;
            _orderService = orderService;
            _petientTurnService = petientTurnService;
        }

        [Route("/Profile")]
        public async Task<IActionResult> Profile()
        {
            BaseResult<EditUser> user = await _userService.GetAsync(Id: _authHelper.CurrentAccountId());
            BaseResult<List<GenderViewModel>> gender = await _genderService.GetAllAsync();
            ViewData["listGender"] = new SelectList(gender.Data, "Id", "Name", user.Data.GenderId);
            if (!string.IsNullOrWhiteSpace(RenderMessageStatic))
            {
                ViewData["RenderMessage"] = RenderMessageStatic;
                RenderMessageStatic = "";
            }

            return View(user.Data);
        }

        [HttpPost]
        [Route("/Profile")]
        public async Task<IActionResult> Profile(EditUser user)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _userService.UpdateAsync(user);
                RenderMessageStatic = response.Message;
            }

            return RedirectToAction("Profile");
        }

        public IActionResult ChangePassword()
        {
            ViewData["UserId"] = _authHelper.CurrentAccountId();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePassword pass)
        {
            RenderMessageStatic = "مقادیر خواسته شده خالی هستند";
            if (ModelState.IsValid)
            {
                BaseResult response = await _userService.ChangePasswordAsync(pass);
                RenderMessageStatic = response.Message;
                if (response.IsSuccess)
                    return RedirectToAction("Profile");
            }

            ViewData["UserId"] = _authHelper.CurrentAccountId();
            ViewData["ErrorMessage"] = RenderMessageStatic;
            RenderMessageStatic = "";
            return View();
        }

        #region PsychologistProfile 

        public async Task<IActionResult> MyIncome()
        {
            BaseResult<List<MyIncome>> result = await _ipsychologistService.MyIncome(_authHelper.CurrentAccountId());
            return View(result.Data);
        }

        #region Patient

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

        #endregion

        #region Discount

        public async Task<IActionResult> DiscountPatient(int patientId)
        {
            BaseResult<CreateDiscount> result = await _discountService.GetByPatientId(patientId);
            ViewData["PatientId"] = patientId;
            ViewData["PsychologistId"] = _authHelper.CurrentAccountId();
            return View(result.Data);
        }

        public async Task<IActionResult> SetDiscountInPatient(CreateDiscount discount)
        {
            BaseResult result = await _discountService.CreateAsync(discount);
            return RedirectToAction("DiscountPatient", new { patientId = discount.PatientId });
        }

        public async Task<IActionResult> DeleteDiscount(int patientId)
        {
            BaseResult result = await _discountService.DeleteByPatientIdAsync(patientId);
            return RedirectToAction("DiscountPatient", new { patientId = patientId });
        }

        #endregion

        #region Article

        public async Task<IActionResult> MyArticles()
        {
            BaseResult<List<ArticleViewModel>> result = await _articlesService.GetAllAsync(new SearchArticle()
            {
                PsychologistId = _authHelper.CurrentAccountId()
            });
            if (RenderMessageStatic == null)
                RenderMessageStatic = "";
            else if (!string.IsNullOrWhiteSpace(RenderMessageStatic))
            {
                ViewData["RenderMessage"] = RenderMessageStatic;
                RenderMessageStatic = "";
            }

            return View(result.Data);
        }

        public IActionResult CreateArticle()
        {
            ViewData["PsychologistId"] = _authHelper.CurrentAccountId();
            ViewBag.DateTiem = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticle article)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _articlesService.CreateAsync(article);
                RenderMessageStatic = response.Message;
                if (response.IsSuccess)
                    return RedirectToAction("MyArticles");
            }

            ViewData["PsychologistId"] = _authHelper.CurrentAccountId();
            return View();
        }

        public async Task<IActionResult> EditArticle(int articleId)
        {
            BaseResult<EditArticle> response = await _articlesService.GetAsync(articleId);
            if (RenderMessageStatic == null)
                RenderMessageStatic = "";
            else if (!string.IsNullOrWhiteSpace(RenderMessageStatic))
            {
                ViewData["RenderMessage"] = RenderMessageStatic;
                RenderMessageStatic = "";
            }

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(EditArticle article)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _articlesService.UpdateAsync(article);
                RenderMessageStatic = response.Message;
                if (response.IsSuccess)
                    return RedirectToAction("MyArticles");
            }

            ViewData["PsychologistId"] = _authHelper.CurrentAccountId();
            return RedirectToAction("EditArticle", new { articleId = article.Id });
        }

        public async Task<IActionResult> DetailsArticle(int articleId)
        {
            BaseResult<EditArticle> response = await _articlesService.GetAsync(articleId);
            return View(response.Data);
        }

        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            BaseResult response = await _articlesService.DeleteAsync(articleId);
            RenderMessageStatic = response.Message;
            return RedirectToAction("MyArticles");
        }

        public async Task<IActionResult> RestorArticle(int articleId)
        {
            BaseResult response = await _articlesService.RestorAsync(articleId);
            RenderMessageStatic = response.Message;
            return RedirectToAction("MyArticles");
        }

        #endregion

        #region AboutUs

        public async Task<IActionResult> AboutMy()
        {
            BaseResult<List<PsychologistAboutUsViewModel>> result = await _psychologistAboutUs.GetAllAsync(
                new SearchPsychologistAboutUs()
                {
                    PsychologistId = _authHelper.CurrentAccountId()
                });
            if (!string.IsNullOrWhiteSpace(RenderMessageStatic))
            {
                ViewData["RenderMessage"] = RenderMessageStatic;
                RenderMessageStatic = "";
            }

            return View(result.Data);
        }

        public IActionResult CreateAboutUs()
        {
            ViewBag.DateTime = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutUs(CreatePsychologistAboutUs aboutUs)
        {
            RenderMessageStatic = "فیلد های مورده خالی هستند";
            if (ModelState.IsValid)
            {
                aboutUs.PsychologistId = _authHelper.CurrentAccountId();
                BaseResult response = await _psychologistAboutUs.CreateAsync(aboutUs);
                RenderMessageStatic = response.Message;
                if (response.IsSuccess) return RedirectToAction("AboutMy");
            }

            ViewBag.DateTime = DateTime.Now.ToString();
            ViewData["RenderMessage"] = RenderMessageStatic;
            RenderMessageStatic = "";
            return View();
        }

        public async Task<IActionResult> EditAbout(int AboutId)
        {
            BaseResult<EditPsychologistAboutUs> response = await _psychologistAboutUs.GetAsync(AboutId);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditAbout(EditPsychologistAboutUs aboutUs)
        {
            RenderMessageStatic = "فیلد های مورده خالی هستند";
            if (ModelState.IsValid)
            {
                BaseResult response = await _psychologistAboutUs.UpdateAsync(aboutUs);
                RenderMessageStatic = response.Message;
                if (response.IsSuccess)
                    return RedirectToAction("AboutMy");
            }

            ViewData["RenderMessage"] = RenderMessageStatic;
            RenderMessageStatic = "";
            return View();
        }

        public async Task<IActionResult> DetailsAboutMy(int AboutId)
        {
            BaseResult<EditPsychologistAboutUs> response = await _psychologistAboutUs.GetAsync(AboutId);
            return View(response.Data);
        }

        public async Task<IActionResult> DeleteAbout(int AboutId)
        {
            BaseResult response = await _psychologistAboutUs.DeleteAsync(AboutId);
            RenderMessageStatic = response.Message;
            return RedirectToAction("AboutMy");
        }

        #endregion

        #region Comment

        public async Task<IActionResult> Chat(int patientId)
        {
            BaseResult<List<CommentViewModel>> result = await _commentService.GetAllAsync(new SearchComment()
            {
                PaitentId = patientId,
                PsychologistId = _authHelper.CurrentAccountId()
            });
            ViewBag.ArrayId = new int[] { patientId, _authHelper.CurrentAccountId() };
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(int patientId, List<IFormFile> files)
        {
            if (patientId > 0 && files.Any())
            {
                BaseResult<ResultUploadFileChat> result = await _commentService.CreateFileAsync(patientId, _authHelper.CurrentAccountId(), _authHelper.CurrentAccountId(), files);
                return Json(new { success = true, message = result.Message, files = result.Data, id = result.Data.ListFilesId });
            }

            return Json(new { success = false, message = "بیلاخ" });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int patientId, string message)
        {
            if (!string.IsNullOrWhiteSpace(message) && patientId > 0)
            {
                BaseResult<string> result = await _commentService.CreateMessageAsync(patientId, _authHelper.CurrentAccountId(), _authHelper.CurrentAccountId(), message);
                return Json(new { success = true, message = result.Message, id = result.Data });
            }

            return Json(new { success = false, message = "بیلاخ" });
        }

        [HttpPost]
        public async Task<IActionResult> IsVisitedComment(string commentId)
        {
            if (commentId.Length > 0)
            {
                BaseResult result = await _commentService.IsVisitedAsync(commentId);
                return Json(new { success = true, message = result.Message });
            }

            return Json(new { success = false, message = "بیلاخ👍👍" });
        }

        public async Task<IActionResult> PsychologistMyChatAll()
        {
            BaseResult<List<CommentViewModel>> result = await _ipsychologistService.GetAllCommentAsync(_authHelper.CurrentAccountId());
            return View(result.Data);
        }

        #endregion

        #endregion

        #region Patient

        public async Task<IActionResult> PatientOrder()
        {
            BaseResult<List<OrderViewModel>> result = await _orderService.GetAllAsync(_authHelper.CurrentAccountId());
            return View(result.Data);
        }

        public async Task<IActionResult> MyPsychologist()
        {
            BaseResult<List<PsychologistViewModel>> result = await _petientTurnService.FindPsychologistByPatientIdAsync(_authHelper.CurrentAccountId());
            return View(result.Data);
        }

        public async Task<IActionResult> ChatPatient(int psychologistId)
        {
            BaseResult<List<OrderViewModel>> result = await _orderService.GetAllAsync(_authHelper.CurrentAccountId());
            return View(result.Data);
        }

        #endregion
    }
}
