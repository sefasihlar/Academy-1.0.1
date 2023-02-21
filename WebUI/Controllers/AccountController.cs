using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
