using Microsoft.AspNetCore.Mvc;
using PC.Dto.Test;
using PC.Dto.Test.Answer;
using PC.Dto.Test.Question;
using PC.Service.IService.Test;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestsController : Controller
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public TestsController(ITestService testService, IQuestionService questionService, IAnswerService answerService)
        {
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;
        }

        public async Task<IActionResult> Index(string? RnderMessage)
        {
            BaseResult<List<TestViewModel>> response = await _testService.GetAllAsync();
            if (!response.IsSuccess)
                ViewData["message"] = response.Message;

            if (!string.IsNullOrWhiteSpace(RnderMessage))
                ViewData["RnderMessage"] = RnderMessage;

            return View(response.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Index(int testId)
        {
            BaseResult response = await _testService.DeleteAsync(testId);
            if (!response.IsSuccess)
                return Json(new { success = response.IsSuccess, message = response.Message });

            return Json(new { success = response.IsSuccess, message = response.Message });
        }

        public async Task<IActionResult> ActiveTest(int testId)
        {
            BaseResult response = await _testService.ActiveAsync(testId);
            return RedirectToAction("Index", new { RnderMessage = response.Message });
        }

        public async Task<IActionResult> DeActiveTest(int testId)
        {
            BaseResult response = await _testService.DeActiveAsync(testId);
            return RedirectToAction("Index", new { RnderMessage = response.Message });
        }




        // View Question
        public async Task<IActionResult> ViewQuestions(int testId)
        {
            BaseResult<List<QuestionViewModel>> response = await _questionService.GetAllAsync(new SearchQustionViewModel()
            {
                TestId = testId
            });
            if (!response.IsSuccess)
                ViewData["message"] = response.Message;

            return View(response.Data);
        }

        // Delete Question
        [HttpDelete]
        public async Task<IActionResult> ViewQuestions(int questionId, int testId)
        {
            BaseResult response = await _questionService.DeleteAsync(questionId);
            if (!response.IsSuccess)
                return Json(new { success = response.IsSuccess, message = response.Message });

            return Json(new { success = response.IsSuccess, message = response.Message });
        }

        // Create Question
        public IActionResult CreateQuestion(int testId)
        {
            ViewData["testId"] = testId;
            ViewData["DateTime"] = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestion question)
        {
            ViewData["testId"] = question.TestId;
            if (ModelState.IsValid)
            {
                BaseResult<CreateQuestion> response = await _questionService.CreateQuestionAndAnswer(question);
                if (response.IsSuccess)
                    return RedirectToAction("ViewQuestions", new { testId = response.Data.TestId });

                ViewData["message"] = response.Message;
            }

            return View();
        }

        // Update Question
        public async Task<IActionResult> UpdateQuestion(int questionId)
        {
            BaseResult<EditQuestion> response = await _questionService.GetAsync(questionId);
            if (!response.IsSuccess)
                ViewData["message"] = response.Message;

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(EditQuestion question)
        {
            if (ModelState.IsValid)
            {
                BaseResult response = await _questionService.UpdateAsync(question);
                if (response.IsSuccess)
                    return RedirectToAction("ViewQuestions", new { testId = question.TestId });

                ViewData["message"] = response.Message;
            }

            return View();
        }




        // View Answer
        public async Task<IActionResult> ViewAnswer(int questionId)
        {
            BaseResult<QuestionViewModel> response = await _questionService.GetQuestionViewModelAsync(questionId);
            if (!response.IsSuccess)
                ViewData["message"] = response.Message;

            return View(response.Data);
        }

        // Remove Answer
        [HttpDelete]
        public async Task<IActionResult> ViewAnswer(int answerId, int testId)
        {
            BaseResult response = await _answerService.DeleteAllAnswerQuestionsAsync(answerId);
            if (!response.IsSuccess)
                return Json(new { success = response.IsSuccess, message = response.Message });

            return Json(new { success = response.IsSuccess, message = response.Message });
        }

        // Create Answer
        public IActionResult CreateAnswer(int questionId)
        {
            ViewData["questionId"] = questionId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer(CreateAnswer answer)
        {
            ViewData["questionId"] = answer.QuestionId;
            BaseResult<CreateAnswer> response = await _answerService.ReturnCreateAsync(answer);
            if (!response.IsSuccess)
            {
                ViewData["message"] = response.Message;
                return View();
            }

            BaseResult result = await _answerService.UpdateAnswersInQuestionAsync(response.Data);
            if (!result.IsSuccess)
            {
                ViewData["message"] = response.Message;
                return View();
            }

            return RedirectToAction("ViewAnswer", new { questionId = response.Data.QuestionId });
        }
    }
}
