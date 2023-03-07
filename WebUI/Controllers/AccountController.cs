
using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        AppUserManager _appUserManager = new AppUserManager(new EfCoreAppUserRepostory());
        ClassManager _classManager = new ClassManager(new EfCoreClassRepository());
        BranchManager _branchManager = new BranchManager(new EfCoreBranchRepository());
        CartManager _cartManager = new CartManager(new EfCoreCartRepository());
        GuardianManager _guardianManager = new GuardianManager(new EfCoreGuardianRepository());
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
	
		}

		public IActionResult Index()
        {
            return View(new AppUserListModel()
            {
                //async metod oldugu icin hata alabiriz ! 
                Users = _appUserManager.ListTogether().Where(x=>x.Authority==false).ToList(),
            });
        }

        [HttpGet]
        public IActionResult Register()
        {
            var classes = _classManager.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            var brances = _branchManager.GetAll();
            ViewBag.brances = new SelectList(brances, "Id", "Name");

            if (classes == null || brances == null)
            {
                return NotFound();
            }


            var values = new AppUserListModel()
            {
                Users = _appUserManager.ListTogether()
            };

            return View(values);
        }

        //Kullanıcı verli bilgileride burada ekleniyor aynı anda kayıt işlemi için

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model, GuardianModel guardian)
        {


            AppUser user = new AppUser()
            {

                Tc = 234234233,
                Name = model.Name,
                SurName = model.SurName,
                ClassId = model.ClassId,
                BranchId = model.BranchId,
                Condition = true,
                UserName =Convert.ToString( model.Tc),
                NormalizedEmail = "sihlarsefa7@gmail.com",
                PhoneNumber = model.Phone,

            };


            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // kullanıcı başarıyla kaydedildi
                Guardian _guardian = new Guardian()
                {
                    Id = guardian.Id,
                    GuardianName = guardian.GuardianName,
                    GuardianName2 = guardian.GuardianName2,
                    GuardianSurName = guardian.GuardianSurName,
                    GuardianSurName2 = guardian.GuardianSurName2,
                    GuardianPhone = guardian.GuardianPhone,
                    GuardianPhone2 = guardian.GuardianPhone2,
                    UserId = user.Id,
                    GuardianCondition = guardian.GuardianCondition,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                if (_guardian != null)
                {
                    _guardianManager.Create(_guardian);
                }
               
            }

            else
            {
                // kayıt işlemi başarısız oldu, hata mesajını göster
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

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
                return RedirectToAction("Index","Account");
            }

            //ModelState.AddModelError("", "Kullanıcı oluşturlamadı! Lütfen bilgileri tekrar gözden geçiriniz");

            var classes = _classManager.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            var brances = _branchManager.GetAll();
            ViewBag.brances = new SelectList(brances, "Id", "Name");

            if (classes == null || brances == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //email e göre değil tc ye göre giriş yapılacak
            var user = await _userManager.FindByEmailAsync(model.Email);


            if (user == null)
            {
                ModelState.AddModelError("", "Bu Tc ile bir hesap oluşturlmamış");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {

                // Email eklenmediği zaman Email oluşturma sayfasına yönlendirilecek
                return RedirectToAction("CreateEmail", "Account");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);


            //Kullanıcınin hesabi başarıyla onlaylandı ise giriş yapabilecek 
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            //diğer durumda hesap onaylanmadan giriş yapamacak
            ModelState.AddModelError("", "Tc yada Parola yanlış");


            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //Buraya çıkış yaptına dair mesaj gelicek


            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {

            if (userId == null || token == null)
            {
                //tempdata "Hesap onayi icin bilgileriniz yanlis"
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //onaylama islemi basarili ise kullaniciya kart tanimlansin
                    _cartManager.InitializeCart(Convert.ToString(user.Id));

                    return RedirectToAction("Login", "Account");
                }
            }

            //tempdata ile hata mesaji goster
            return View();
        }

        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                //hata mesaji 
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                //kullanici bulunamadi hatasi
                return View();

            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {

                Token = code

            });

            //Send Email ResetPassword
            //tempdata ile uyari mesaji gonder

            return RedirectToAction("Login", "Account");
        }

        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordModel { Token = token };

            return View(model);

        }

        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Home");
            }

            return View(model);
        }

    }
}

