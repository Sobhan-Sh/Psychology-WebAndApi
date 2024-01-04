using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Dto.Psychologist.Article;
using PC.Dto.Psychologist.PsychologistTypeOfConsultation;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Dto.Psychologist.TypeOfConsultation;
using PC.Dto.User;
using PC.Dto.User.Gender;
using PC.Service.IService.Patient;
using PC.Service.IService.Psychologist;
using PC.Service.IService.User;
using PC.Utility;
using PC.Utility.DateConvertor;
using PC.Utility.ReturnFuncResult;
using PC.Utility.SendRequestToPayment.ZarinPal;
using Psychology.Models;


namespace Psychology.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPsychologistService _psychologistService;
        private readonly ITypeOfConsultationService _typeOfConsultationService;
        private readonly IPsychologistWorkingDateAndTimeService _typeOfWorkingDateAndTimeService;
        private readonly IPsychologistTypeOfConsultationService _psychologistTypeOfConsultationService;
        private readonly IPatientTurnService _atientTurnService;
        private readonly IArticlesService _articlesService;
        private readonly IUserService _userService;
        private readonly IGenderService _genderService;

        private static int UserId;

        public HomeController(IPsychologistService psychologistService, ITypeOfConsultationService typeOfConsultationService, IPsychologistWorkingDateAndTimeService typeOfWorkingDateAndTimeService, IPsychologistTypeOfConsultationService psychologistTypeOfConsultationService, IPatientTurnService atientTurnService, IArticlesService articlesService, IUserService userService, IGenderService genderService)
        {
            _psychologistService = psychologistService;
            _typeOfConsultationService = typeOfConsultationService;
            _typeOfWorkingDateAndTimeService = typeOfWorkingDateAndTimeService;
            _psychologistTypeOfConsultationService = psychologistTypeOfConsultationService;
            _atientTurnService = atientTurnService;
            _articlesService = articlesService;
            _userService = userService;
            _genderService = genderService;
        }

        public async Task<IActionResult> Index(string? renderMessage)
        {
            BaseResult<List<PsychologistViewModel>> psychologist =
                await _psychologistService.GetAllAsync();

            if (psychologist.IsSuccess)
            {
                List<PsychologistSelectListModel> psychologistSelectLlists = new();

                foreach (var item in psychologist.Data)
                {
                    psychologistSelectLlists.Add(new PsychologistSelectListModel()
                    {
                        Id = item.Id,
                        Name = $"{item.UserViewModel.GenderViewModel.Name} دکتر {item.UserViewModel.FullName()}"
                    });
                }

                ViewData["Psychologist"] = new SelectList(psychologistSelectLlists, "Id", "Name");
            }

            BaseResult<List<TypeOfConsultationViewModel>> typeOf =
              await _typeOfConsultationService.GetAllAsync();

            if (typeOf.IsSuccess)
                ViewData["TypeOfConsultation"] = new SelectList(typeOf.Data.Where(x => !x.IsDeleted), "Id", "Name");

            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["renderMessage"] = renderMessage;

            return View();
        }

        /// اینجا باید روز رو از میلادی به شمسی به کلاینت برگردونیم
        public async Task<IActionResult> CheckTimeVisit(int PsychologistId, string ConsultationDay)
        {
            BaseResult<List<CheckDateVisit>> result = await _typeOfWorkingDateAndTimeService.CheckDateVisit(PsychologistId, DateTimeConvertor.ToMiladi(ConsultationDay));
            return Json(new { success = result.IsSuccess, data = result.Data, message = result.Message });
        }

        public async Task<IActionResult> GetPsychologist(int TOCId)
        {
            BaseResult<List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel>> result = await _psychologistTypeOfConsultationService.ReturnNewModelInPageVisitGetAllAsync(new()
            {
                TypeOfConsultationId = TOCId
            });
            return Json(new { success = result.IsSuccess, data = result.Data });
        }

        [HttpPost]
        public async Task<IActionResult> SetVisit(SetVisitModel model)
        {
            BaseResult<ReturnSetVisitModel> result = await _atientTurnService.CreateAsync(model);
            if (result.IsSuccess)
            {
                BaseResult<string> response = await SendRequestToZarinPal.SendRequest(new()
                {
                    Data = $"OrderId={result.Data.OrderId}&PatientId={result.Data.PatientId}",
                    description = "پرداخت نوبت ویزیت در سامانه روانشناس من",
                    amount = result.Data.Amount,
                    callback_url = SD.VerifyPayment.Visit,
                    Phone = result.Data.Phone,
                });

                if (response.IsSuccess)
                    return Redirect(response.Data);
            }

            return RedirectToAction("Index", new { renderMessage = result.Message });
        }

        public async Task<IActionResult> Article()
        {
            BaseResult<List<ArticleViewModel>> result = await _articlesService.GetAllAsync();
            return View(result.Data);
        }

        public async Task<IActionResult> DetailsArticle(int articleId)
        {
            BaseResult<ArticleViewModel> result = await _articlesService.GetArticleViewModelAsync(articleId);
            return View(result.Data);
        }

        public async Task<IActionResult> JoinTheTeam()
        {
            //BaseResult<List<GenderViewModel>> result = await _genderService.GetAllAsync();
            //ViewData["Gender"] = new SelectList(result.Data, "Id", "Name");
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> JoinTheTeam(CreateUser user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        BaseResult<int> result = await _userService.ReturnCreateAsync(user);
        //        if (UserId == null)
        //            UserId = new();

        //        UserId = result.Data;
        //        if (result.IsSuccess)
        //            return RedirectToAction("JoinTheTeamPartTwo");
        //    }

        //    return View();
        //}

        //public IActionResult JoinTheTeamPartTwo()
        //{
        //    if (UserId < 1)
        //        return RedirectToAction("JoinTheTeam");

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> JoinTheTeamPartTwo(CreatePsychologist psychologist)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        psychologist.UserId = UserId;
        //        BaseResult result = await _psychologistService.CreateAsync(psychologist);
        //        if (result.IsSuccess)
        //            return RedirectToAction("JoinTheTeamFinish");
        //    }

        //    return View();
        //}

        //public IActionResult JoinTheTeamFinish()
        //{
        //    return View();
        //}
    }
}
