
using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
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
        [Authorize(Roles = "Müdür")]
        public IActionResult Index()
        {
            return View(new AppUserListModel()
            {
                //async metod oldugu icin hata alabiriz ! 
                Users = _appUserManager.ListTogether().Where(x => x.Authority == false).ToList(),
            });
        }
        [Authorize(Roles = "Öğretmen")]
        [HttpGet]
        public IActionResult Register()
        {
            var classes = _classManager.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            var brances = _branchManager.GetAll();
            ViewBag.brances = new SelectList(brances, "Id", "Name");

            if (classes == null || brances == null)
            {
                return RedirectToAction("404", "Error");
            }


            var values = new AppUserListModel()
            {
                Users = _appUserManager.ListTogether()
            };

            return View(values);
        }

        //Kullanıcı verli bilgileride burada ekleniyor aynı anda kayıt işlemi için

        [Authorize(Roles = "Öğretmen")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model, GuardianModel guardian)
        {

            AppUser user = new AppUser()
            {

                Tc = model.TcNumber,
                Name = model.Name,
                SurName = model.SurName,
                ClassId = model.ClassId,
                BranchId = model.BranchId,
                PasswordHash = model.Password,
                Condition = true,
                UserName = Convert.ToString(model.TcNumber),
                NormalizedEmail = "",
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
                return RedirectToAction("Index", "Account");
            }



            //ModelState.AddModelError("", "Kullanıcı oluşturlamadı! Lütfen bilgileri tekrar gözden geçiriniz");

            var classes = _classManager.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            var brances = _branchManager.GetAll();
            ViewBag.brances = new SelectList(brances, "Id", "Name");

            if (classes == null || brances == null)
            {
                return RedirectToAction("404", "Error");
            }



            return RedirectToAction("Index", "Account", model);
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
            var user = await _userManager.FindByNameAsync(model.UserName);

            var userValues = new AppUserModel()
            {
                Name = user.Name,
                SurName = user.SurName,
            };


            ViewBag.userValues = userValues;

            if (user == null)
            {
                ModelState.AddModelError("", "Bu Tc ile bir hesap oluşturlmamış");
                return View(model);
            }



            if (!await _userManager.IsEmailConfirmedAsync(user))
            {

                // Email eklenmediği zaman Email oluşturma sayfasına yönlendirilecek
                return RedirectToAction("CreateEmail", "Account", model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);


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
                TempData["message"] = "Geçersiz token";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["message"] = "böyle bir kullanıcı yok";
                return View();
            }

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //onaylama islemi basarili ise kullaniciya kart tanimlansin
                    _cartManager.InitializeCart(Convert.ToString(user.Id));
                    TempData["message"] = "Hesabının onaylandı";
                    return RedirectToAction("ConfirmEmail", "Account");
                }
            }

            TempData["message"] = "Hesabının Onaylanmadı";
            return View();

            //tempdata ile hata mesaji goster
        }

        [HttpGet]

        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
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

            return RedirectToAction("ResetPassword", "Account");
        }
        [HttpGet]
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
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateEmail(LoginModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmail(AppUserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
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
                    return RedirectToAction("Index", "Account");
                }
            }
            return View(model);
        }

    }
}

