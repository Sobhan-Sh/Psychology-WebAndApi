﻿using Dto.Psychologist;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Psychology.Models;
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

        public HomeController(IPsychologistService psychologistService, ITypeOfConsultationService typeOfConsultationService, IPsychologistWorkingDateAndTimeService typeOfWorkingDateAndTimeService)
        {
            _psychologistService = psychologistService;
            _typeOfConsultationService = typeOfConsultationService;
            _typeOfWorkingDateAndTimeService = typeOfWorkingDateAndTimeService;
        }

        public async Task<IActionResult> Index()
        {
            BaseResult<List<PsychologistViewModel>> psychologist =
                await _psychologistService.GetAllAsync();

            if (psychologist.IsSuccess)
            {
                List<PsychologistSelectLlist> psychologistSelectLlists = new();

                foreach (var item in psychologist.Data)
                {
                    psychologistSelectLlists.Add(new PsychologistSelectLlist()
                    {
                        Id = item.Id,
                        Name = $"{item.UserViewModel.GenderViewModel.Name} دکتر {item.UserViewModel.FullName()}"
                    });
                }

                SelectList list = new SelectList(psychologistSelectLlists, "Id", "Name");
                ViewData["Psychologist"] = list;

            }
            // BaseResult<List<TypeOfConsultationViewModel>> typeOf =
            //    await _typeOfConsultationService.GetAllAsync();

            //ViewData["TypeOfConsultation"] = new SelectList(typeOf.Data, "Id", "Name");
            return View();
        }


        public async Task<IActionResult> CheckTimeVisit(int PsychologistId, string ConsultationDay)
        {
            BaseResult<List<CheckDateVisit>> result = await _typeOfWorkingDateAndTimeService.CheckDateVisit(PsychologistId, DateTimeConvertor.ToMiladi(ConsultationDay));
            return Json(new { success = "ok" });
        }
    }
}
