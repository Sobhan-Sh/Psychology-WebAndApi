using Microsoft.AspNetCore.Mvc;

namespace Psychology.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
