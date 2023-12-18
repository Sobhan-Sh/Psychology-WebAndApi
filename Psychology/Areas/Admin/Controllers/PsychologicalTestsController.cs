using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Test;
using PC.Dto.Test.Answer;
using PC.Dto.Test.Question;
using PC.Service.IService.Test;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;

namespace Psychology.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PsychologicalTestsController : Controller
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private IMapper _mapper;

        private static List<CreateQuestion> _listCreateQuestions;
        private static List<CreateAnswer> listAnswer;

        public PsychologicalTestsController(ITestService testService, IQuestionService questionService, IAnswerService answerService, IMapper mapper)
        {
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("CreateTest");
        }

        public IActionResult CreateTest()
        {
            listAnswer = new();
            ViewBag.DateTime = DateTime.Now;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(CreateTest test)
        {
            if (ModelState.IsValid)
            {
                BaseResult<int> res = await _testService.CreateAsync(test);
                if (!res.IsSuccess && res.StatusCode == ValidationCode.BadRequest)
                {
                    ViewData["error"] = "true";
                    ViewData["message"] = res.Message;
                    return View(test);
                }

                _listCreateQuestions = new();
                return RedirectToAction("CreateQuestion", new { Id = res.Data });
            }

            return View(test);
        }

        public IActionResult CreateQuestion(int Id)
        {
            ViewBag.TestId = Id;
            if (_listCreateQuestions != null)
                ViewData["questions"] = _listCreateQuestions;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestion question)
        {
            question.Id = 0;
            BaseResult<CreateQuestion> res = await _questionService.CreateAsync(question);
            ViewData["questions"] = _listCreateQuestions;
            ViewBag.TestId = question.TestId;
            if (!res.IsSuccess && res.StatusCode == ValidationCode.BadRequest)
            {
                ViewData["Message"] = res.Message;
                return View();
            }

            _listCreateQuestions.Add(res.Data);
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            BaseResult<int> res = await _questionService.ReturnDeleteAsync(questionId);
            if (!res.IsSuccess && res.StatusCode == ValidationCode.BadRequest)
                return Json(new { success = res.IsSuccess, message = res.Message });

            _listCreateQuestions.RemoveAt(_listCreateQuestions.FindIndex(x => x.Id == questionId));
            return Json(new { success = res.IsSuccess, message = res.Message });
        }

        [HttpPut]
        public IActionResult CreateTest(CreateAnswer answer)
        {
            if (listAnswer == null)
                listAnswer = new();

            if (listAnswer.Any(x => x.Id == answer.Id))
                return Json(new { success = false });

            listAnswer.Add(answer);
            return Json(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> CreateTest(int answerId)
        {
            try
            {
                if (!listAnswer.Any(x => x.Id == answerId))
                    return Json(new { success = false });

                listAnswer.RemoveAt(listAnswer.FindIndex(x => x.Id == answerId));
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false });
            }
        }

        public async Task<IActionResult> Finish()
        {
            foreach (var qu in _listCreateQuestions)
            {
                foreach (var ans in listAnswer)
                {
                    BaseResult res = await _answerService.CreateAsync(new CreateAnswer()
                    {
                        CreatedAt = DateTime.Now.ToString(),
                        IsActive = true,
                        QuestionId = qu.Id,
                        Score = ans.Score,
                        Title = ans.Title,
                        Id = 0
                    });
                    if (!res.IsSuccess)
                    {
                        ViewData["message"] = res.Message;
                        return View();
                    }
                }
            }

            return View();
        }
    }
}
