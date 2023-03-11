using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Öğretmen")]
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResultQuestions()
        {
            return View();
        }

        public IActionResult ResultVideo()
        {
            return View();
        }
    }
}
