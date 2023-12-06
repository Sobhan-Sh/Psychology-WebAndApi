using Dto.Order;
using Dto.Patient;
using Dto.Patient.PatientTurn;
using Dto.Psychologist;
using Dto.Psychologist.PsychologistTypeOfConsultation;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Dto.Psychologist.PsychologistWorkingDays;
using Dto.Psychologist.PsychologistWorkingHours;
using Dto.Psychologist.TypeOfConsultation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.IService.DiscountAndOrder;
using Service.IService.Patient;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Psychology.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PsychologistsController : Controller
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IPsychologistWorkingDateAndTimeService _dateAndTimeService;
        private readonly IPsychologistWorkingDaysService _psychologistWorkingDaysService;
        private readonly IOrderService _orderService;
        private readonly IPatientService _petientService;
        private readonly IPsychologistWorkingHoursService _psychologistWorkingHoursService;
        private readonly IPatientTurnService _petientTurnService;
        private readonly ITypeOfConsultationService _typeOfConsultationService;
        private readonly IPsychologistTypeOfConsultationService _psychologistTypeOfConsultationService;

        public PsychologistsController(IPsychologistService psychologistService, IPsychologistWorkingDateAndTimeService dateAndTimeService, IPsychologistWorkingDaysService psychologistWorkingDaysService, IOrderService orderService, IPatientService petientService, IPsychologistWorkingHoursService psychologistWorkingHoursService, IPatientTurnService petientTurnService, ITypeOfConsultationService typeOfConsultationService, IPsychologistTypeOfConsultationService psychologistTypeOfConsultationService)
        {
            _psychologistService = psychologistService;
            _dateAndTimeService = dateAndTimeService;
            _psychologistWorkingDaysService = psychologistWorkingDaysService;
            _orderService = orderService;
            _petientService = petientService;
            _psychologistWorkingHoursService = psychologistWorkingHoursService;
            _petientTurnService = petientTurnService;
            _typeOfConsultationService = typeOfConsultationService;
            _psychologistTypeOfConsultationService = psychologistTypeOfConsultationService;
        }

        private static List<PatientViewModel> staticPatientViewModel;
        private static List<PsychologistWorkingHoursViewModel> staticPsychologistWorkingHoursViewModels;
        private static List<PsychologistWorkingDaysViewModel> staitcPsychologistWorkingDaysViewModels;

        public async Task<IActionResult> Index(string? renderMessage)
        {
            BaseResult<List<PsychologistViewModel>> result = await _psychologistService.GetAllAsync();
            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            return View(result.Data);
        }

        public async Task<IActionResult> Active(int psychologistId)
        {
            BaseResult result = await _psychologistService.ActiveAsync(psychologistId);
            return RedirectToAction("Index", new { renderMessage = result.Message });
        }

        public async Task<IActionResult> DeActive(int psychologistId)
        {
            BaseResult result = await _psychologistService.DeActiveAsync(psychologistId);
            return RedirectToAction("Index", new { renderMessage = result.Message });
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

        #region EditPsychologist

        public async Task<IActionResult> EditPsychologist(int psychologistId)
        {
            BaseResult<EditPsychologist> result = await _psychologistService.GetAsync(psychologistId);
            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditPsychologist(EditPsychologist psychologist)
        {
            if (ModelState.IsValid)
            {
                BaseResult result = await _psychologistService.UpdateAsync(psychologist);
                if (result.IsSuccess)
                    return RedirectToAction("Index", new { renderMessage = result.Message });

                ViewData["Message"] = result.Message;
            }

            return View(psychologist);
        }

        #endregion

        #region DeletePsychologist

        public async Task<IActionResult> DeletePsychologst(int psychologistId)
        {
            BaseResult result =
                await _psychologistService.DeleteAsync(psychologistId);
            return RedirectToAction("PsychologistTypeOfConsultation", new { renderMessage = result.Message });
        }

        #endregion

        #region Order

        public async Task<IActionResult> OrderThisPsychologit(int psychologistId, string? renderMessage)
        {
            BaseResult<List<OrderViewModel>> result = await _orderService.GetAllAsync(new SearchOrder()
            {
                PsychologistId = psychologistId
            });
            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            ViewData["psychologistId"] = psychologistId;
            return View(result.Data);
        }

        public async Task<IActionResult> CreateOrderThisPsychologist(int psychologistId)
        {
            staticPatientViewModel = new();
            BaseResult<List<PatientViewModel>> patient = await _petientService.GetAllAsync();
            if (patient.Data == null)
                return RedirectToAction("OrderThisPsychologit", new { psychologistId = psychologistId, renderMessage = patient.Message + " (بیمار) " });

            staticPatientViewModel.AddRange(patient.Data);
            ViewData["ListItemPatient"] = patient.Data;
            ViewBag.PsychologistId = psychologistId;
            ViewBag.DateTime = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderThisPsychologist(CreateOrder order)
        {
            if (ModelState.IsValid)
            {
                BaseResult res = await _orderService.CreateAsync(order);
                if (res.IsSuccess)
                    return RedirectToAction("OrderThisPsychologit", new { psychologistId = order.PsychologistId, renderMessage = res.Message });

                ViewData["Message"] = res.Message;
            }

            ViewData["ListItemPatient"] = staticPatientViewModel;
            ViewBag.PsychologistId = order.PsychologistId;
            ViewBag.DateTime = DateTime.Now.ToString();
            return View();
        }

        #endregion

        #region WorkTimePsychologist

        public async Task<IActionResult> WorkTimePsychologist(int psychologistId, string? renderMessage)
        {
            BaseResult<List<PsychologistWorkingDateAndTimeViewModel>> result = await _dateAndTimeService.GetAllAsync(new SearchPsychologistWorkingDateAndTime()
            {
                PsychologistId = psychologistId
            });

            ViewData["psychologistId"] = psychologistId;
            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            return View(result.Data);
        }

        public async Task<IActionResult> CreateWorkTimePsychologist(int psychologistId)
        {
            if (staticPsychologistWorkingHoursViewModels == null && staitcPsychologistWorkingDaysViewModels == null)
            {
                staticPsychologistWorkingHoursViewModels = new();
                staitcPsychologistWorkingDaysViewModels = new();
                BaseResult<List<PsychologistWorkingDaysViewModel>> day = await _psychologistWorkingDaysService.GetAllAsync();
                BaseResult<List<PsychologistWorkingHoursViewModel>> hours = await _psychologistWorkingHoursService.GetAllAsync();
                staticPsychologistWorkingHoursViewModels.AddRange(hours.Data);
                staitcPsychologistWorkingDaysViewModels.AddRange(day.Data);
            }

            ViewData["ListItemWrokingDay"] = new SelectList(staitcPsychologistWorkingDaysViewModels, "Id", "Day");
            ViewData["ListItemWrokingHours"] = staticPsychologistWorkingHoursViewModels;
            ViewData["PsychologistId"] = psychologistId;
            ViewData["DateTime"] = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkTimePsychologist(CreatePsychologistWorkingDateAndTime createPsychologistWorkingDateAndTime)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _dateAndTimeService.CreateAsync(createPsychologistWorkingDateAndTime);
                if (response.IsSuccess)
                {
                    staticPsychologistWorkingHoursViewModels = null;
                    staitcPsychologistWorkingDaysViewModels = null;
                    return RedirectToAction("WorkTimePsychologist",
                            new { psychologistId = createPsychologistWorkingDateAndTime.PsychologistId, renderMessage = response.Message + " ( ساعات کاری ) " });
                }

                ViewData["Message"] = response.Message;
            }

            ViewData["ListItemWrokingDay"] = new SelectList(staitcPsychologistWorkingDaysViewModels, "Id", "Day");
            ViewData["ListItemWrokingHours"] = staticPsychologistWorkingHoursViewModels;
            ViewData["PsychologistId"] = createPsychologistWorkingDateAndTime.PsychologistId;
            ViewData["DateTime"] = DateTime.Now.ToString();
            return View();
        }

        public async Task<IActionResult> EditWorkTimePsychologist(int PsychologistWorkingDateAndTimeId)
        {
            BaseResult<EditPsychologistWorkingDateAndTime> dateAndTime = await _dateAndTimeService.GetAsync(PsychologistWorkingDateAndTimeId);
            if (staticPsychologistWorkingHoursViewModels == null && staitcPsychologistWorkingDaysViewModels == null)
            {
                staticPsychologistWorkingHoursViewModels = new();
                staitcPsychologistWorkingDaysViewModels = new();
                BaseResult<List<PsychologistWorkingDaysViewModel>> day = await _psychologistWorkingDaysService.GetAllAsync();
                BaseResult<List<PsychologistWorkingHoursViewModel>> hours = await _psychologistWorkingHoursService.GetAllAsync();
                staticPsychologistWorkingHoursViewModels.AddRange(hours.Data);
                staitcPsychologistWorkingDaysViewModels.AddRange(day.Data);
            }

            ViewData["ListItemWrokingDay"] = new SelectList(staitcPsychologistWorkingDaysViewModels, "Id", "Day", dateAndTime.Data.PsychologistWorkingDaysId);
            ViewData["ListItemWrokingHours"] = staticPsychologistWorkingHoursViewModels;
            return View(dateAndTime.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkTimePsychologist(EditPsychologistWorkingDateAndTime editPsychologistWorkingDateAndTime)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _dateAndTimeService.UpdateAsync(editPsychologistWorkingDateAndTime);
                if (response.IsSuccess)
                {
                    staticPsychologistWorkingHoursViewModels = null;
                    staitcPsychologistWorkingDaysViewModels = null;
                    return RedirectToAction("WorkTimePsychologist",
                            new { psychologistId = editPsychologistWorkingDateAndTime.PsychologistId, renderMessage = response.Message + " ( ساعات کاری ) " });
                }

                ViewData["Message"] = response.Message;
            }

            ViewData["ListItemWrokingDay"] = new SelectList(staitcPsychologistWorkingDaysViewModels, "Id", "Day");
            ViewData["ListItemWrokingHours"] = staticPsychologistWorkingHoursViewModels;
            return View(editPsychologistWorkingDateAndTime);
        }

        public async Task<IActionResult> DeleteWorkTimePsychologist(int PsychologistWorkingDateAndTimeId)
        {
            BaseResult<int> response = await _dateAndTimeService.ReturnIdDeleteAsync(PsychologistWorkingDateAndTimeId);
            return RedirectToAction("WorkTimePsychologist",
                new { psychologistId = response.Data, renderMessage = response.Message + " ( ساعات کاری ) " });
        }

        #endregion

        public async Task<IActionResult> PatientsThisPsychologist(int psychologistId)
        {
            BaseResult<List<PatientTurnViewModel>> response =
                await _petientTurnService.FindPatientByPsychologistIdAsync(psychologistId);
            if (!response.IsSuccess)
                ViewData["Message"] = response.Message;

            return View(response.Data);
        }

        public async Task<IActionResult> UnvisitedPatients(int psychologistId)
        {
            BaseResult<List<PatientTurnViewModel>> response =
                await _petientTurnService.UnvisitedPatients(psychologistId);
            if (!response.IsSuccess)
                ViewData["Message"] = response.Message;

            return View(response.Data);
        }

        #region TypeOfConsultation

        public async Task<IActionResult> TypeOfConsultation(string? renderMessage)
        {
            BaseResult<List<TypeOfConsultationViewModel>> result = await _typeOfConsultationService.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            return View(result.Data);
        }

        public IActionResult CreateTypeOfConsultation()
        {
            ViewData["Time"] = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeOfConsultation(CreateTypeOfConsultation typeOfConsultation)
        {
            if (ModelState.IsValid)
            {
                BaseResult result = await _typeOfConsultationService.CreateAsync(typeOfConsultation);
                if (result.IsSuccess)
                    return RedirectToAction("TypeOfConsultation", new { renderMessage = result.Message });

                ViewData["Message"] = result.Message;
            }

            ViewData["Time"] = DateTime.Now.ToString();
            return View();
        }

        public async Task<IActionResult> EditTypeOfConsultation(int typeOfConsultationId)
        {
            BaseResult<EditTypeOfConsultation> result = await _typeOfConsultationService.GetAsync(typeOfConsultationId);
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditTypeOfConsultation(EditTypeOfConsultation typeOfConsultation)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _typeOfConsultationService.UpdateAsync(typeOfConsultation);
                if (response.IsSuccess)
                    return RedirectToAction("TypeOfConsultation", new { renderMessage = response.Message });

                ViewData["Message"] = response.Message;
            }

            return View();
        }

        public async Task<IActionResult> DeleteTypeOfConsultation(int typeOfConsultationId)
        {
            BaseResult result = await _typeOfConsultationService.DeleteAsync(typeOfConsultationId);
            return RedirectToAction("TypeOfConsultation", new { renderMessage = result.Message });
        }

        public async Task<IActionResult> ReturnTypeOfConsultation(int typeOfConsultationId)
        {
            BaseResult result = await _typeOfConsultationService.RestoreDeleteAsync(typeOfConsultationId);
            return RedirectToAction("TypeOfConsultation", new { renderMessage = result.Message });
        }

        #endregion

        #region PsychologistTypeOfConsultation

        public async Task<IActionResult> PsychologistTypeOfConsultation(int psychologistId, string? renderMessage)
        {
            BaseResult<List<PsychologistTypeOfConsultationViewModel>> result =
                await _psychologistTypeOfConsultationService.GetAllAsync(new SearchPsychologistTypeOfConsultation()
                {
                    PsychologistId = psychologistId
                });
            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            ViewData["psychologistId"] = psychologistId;
            return View(result.Data);
        }

        public async Task<IActionResult> CreatePsychologistTypeOfConsultation(int psychologistId, string? renderMessage)
        {
            BaseResult<List<TypeOfConsultationViewModel>> result = await _typeOfConsultationService.GetAllAsync();
            if (result.IsSuccess)
                ViewData["selectListTypeOfConsultation"] = new SelectList(result.Data.Where(x => !x.IsDeleted), "Id", "Name");

            ViewData["PsychologistId"] = psychologistId;
            ViewBag.DateTime = DateTime.Now.ToString();
            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePsychologistTypeOfConsultation(CreatePsychologistTypeOfConsultation createPsychologistTypeOfConsultation)
        {
            string message = null;
            if (ModelState.IsValid)
            {
                BaseResult response =
                    await _psychologistTypeOfConsultationService.CreateAsync(createPsychologistTypeOfConsultation);
                if (response.IsSuccess)
                    return RedirectToAction("PsychologistTypeOfConsultation", new { psychologistId = createPsychologistTypeOfConsultation.PsychologistId, renderMessage = response.Message });

                message = response.Message;
            }

            return RedirectToAction("CreatePsychologistTypeOfConsultation", new { psychologistId = createPsychologistTypeOfConsultation.PsychologistId, renderMessage = message });
        }

        public async Task<IActionResult> EditPsychologistTypeOfConsultation(int psychologistTypeOfConsultationId, string? renderMessage)
        {
            BaseResult<EditPsychologistTypeOfConsultation> response =
                await _psychologistTypeOfConsultationService.GetAsync(psychologistTypeOfConsultationId);

            BaseResult<List<TypeOfConsultationViewModel>> result = await _typeOfConsultationService.GetAllAsync();

            ViewData["selectListTypeOfConsultation"] = new SelectList(result.Data.Where(x => !x.IsDeleted), "Id", "Name", response.Data.TypeOfConsultationId);
            if (!string.IsNullOrWhiteSpace(renderMessage))
                ViewData["RenderMessage"] = renderMessage;

            if (!result.IsSuccess)
                ViewData["Message"] = result.Message;

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditPsychologistTypeOfConsultation(EditPsychologistTypeOfConsultation editPsychologistTypeOfConsultation)
        {
            string message = null;
            if (ModelState.IsValid)
            {
                BaseResult response =
                    await _psychologistTypeOfConsultationService.UpdateAsync(editPsychologistTypeOfConsultation);
                if (response.IsSuccess)
                    return RedirectToAction("PsychologistTypeOfConsultation", new { psychologistId = editPsychologistTypeOfConsultation.PsychologistId, renderMessage = response.Message });

                message = response.Message;
            }

            return RedirectToAction("EditPsychologistTypeOfConsultation", new { psychologistTypeOfConsultationId = editPsychologistTypeOfConsultation.Id, renderMessage = message });
        }

        public async Task<IActionResult> DeletePsychologistTypeOfConsultation(int psychologistTypeOfConsultationId)
        {
            BaseResult<int> result =
                await _psychologistTypeOfConsultationService.ReturnDeleteAsync(psychologistTypeOfConsultationId);
            return RedirectToAction("PsychologistTypeOfConsultation", new { psychologistId = result.Data, renderMessage = result.Message });
        }

        #endregion
    }
}