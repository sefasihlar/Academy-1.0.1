using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class MyExamController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
