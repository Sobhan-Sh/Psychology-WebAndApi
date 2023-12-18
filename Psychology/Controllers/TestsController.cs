using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Test;
using PC.Service.IService.Test;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            BaseResult<List<TestViewModel>> result = await _testService.GetAllAsync();
            return View(result.Data.Where(x => !x.IsDeleted && !x.IsActive));
        }

        public async Task<IActionResult> StartTheTest(int testId)
        {
            BaseResult<List<TestViewModel>> result = await _testService.GetAllAsync(new()
            {
                TestId = testId
            });
            return View(result.Data.Where(x => !x.IsActive && !x.IsDeleted).FirstOrDefault());
        }
    }
}
