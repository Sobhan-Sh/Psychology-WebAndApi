using Dto.Patient.PatientTurn;
using Dto.Psychologist;
using Dto.Psychologist.PsychologistTypeOfConsultation;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Dto.Psychologist.TypeOfConsultation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Psychology.Models;
using Service.IService.Patient;
using Service.IService.Psychologist;
using Utility.DateConvertor;
using Utility.ReturnFuncResult;



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

        public async Task<IActionResult> Index()
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

            return View();
        }

        /// <summary>
        /// اینجا باید روز رو از میلادی به شمسی به کلاینت برگردونیم
        /// </summary>
        /// <param name="PsychologistId"></param>
        /// <param name="ConsultationDay"></param>
        /// <returns></returns>
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

        public async Task<IActionResult> SetVisit(SetVisitModel model)
        {
            BaseResult result = await _atientTurnService.CreateAsync(model);
            if (result.IsSuccess)
                return null;
            return null;
        }
    }
}
