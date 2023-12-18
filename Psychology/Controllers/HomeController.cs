using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Dto.Psychologist.PsychologistTypeOfConsultation;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Dto.Psychologist.TypeOfConsultation;
using PC.Service.IService.Patient;
using PC.Service.IService.Psychologist;
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

        public HomeController(IPsychologistService psychologistService, ITypeOfConsultationService typeOfConsultationService, IPsychologistWorkingDateAndTimeService typeOfWorkingDateAndTimeService, IPsychologistTypeOfConsultationService psychologistTypeOfConsultationService, IPatientTurnService atientTurnService)
        {
            _psychologistService = psychologistService;
            _typeOfConsultationService = typeOfConsultationService;
            _typeOfWorkingDateAndTimeService = typeOfWorkingDateAndTimeService;
            _psychologistTypeOfConsultationService = psychologistTypeOfConsultationService;
            _atientTurnService = atientTurnService;
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
    }
}
