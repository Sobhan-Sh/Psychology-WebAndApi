using Microsoft.AspNetCore.Mvc;
using PC.Dto.Message;
using PC.Dto.Patient;
using PC.Service.IService.IMessageService;
using PC.Service.IService.Patient;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
       // private readonly IMessageService _messageService;

        public PatientsController(IPatientService patientService/*, IMessageService messageService*/)
        {
            _patientService = patientService;
           // _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            BaseResult<List<ListPatientViewModel>> result = await _patientService.GetListPatientAsync();
            return View(result.Data);
        }

        public async Task<IActionResult> MessagePatientToPschologist(int patientId)
        {
          //  BaseResult<List<MessagePatientToPschologist>> result = await _messageService.GetAllMessagePatientAsync(patientId);
            return null; //View(result.Data);
        }
    }
}
