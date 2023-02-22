
using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class AccountController : Controller
	{
		AppUserManager _appUserManager = new AppUserManager(new EfCoreAppUserRepostory());
		private readonly UserManager<AppUser> _userManager;

		public IActionResult Index()
		{
			return View(new AppUserListModel()
			{
				Users = _appUserManager.ListTogether().ToList()
			});
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterModel());
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				AppUser user = new AppUser()
				{
					Tc = model.Tc,
					Name = model.Name,
					SurName = model.SurName,
					ClassId = model.ClassId,
					BranchId = model.BranchId,
					PhoneNumber = model.Phone,
					Email= model.Email,
					
				};

				

				var result = await _userManager.CreateAsync(user,model.Password);

				if (result.Succeeded)
				{
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

					var callbackUrl = Url.Action("ConfirmEmail", "Account", new
					{
						userId = user.Id,
						Token = code,
			        });

					//Burası email gönderme kısmı(send Email)

					//Kullanıcı oluştuldu mesajı eklenecek tempdate ile 
					return View();
				}
			}
			ModelState.AddModelError("", "Kullanıcı oluşturlamadı! Lütfen bilgileri tekrar gözden geçiriniz");
			return View(model);
		} 
	}
}
