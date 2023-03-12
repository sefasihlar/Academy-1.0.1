using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class MyExamController : Controller
    {
        ExamManager _examManager = new ExamManager(new EfCoreExamRepository());
        AppUserManager _appUserManager = new AppUserManager(new EfCoreAppUserRepostory());
        private readonly UserManager<AppUser> _userManager;

        public MyExamController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            var getId = _appUserManager.GetById(Convert.ToInt32(userId));
            //sisteme giriş yapan kullanıcıyı bulup sınıf bilgisiyle filtelecek
            var values = new ExamListModel()
            {
                Exams = _examManager.GetWithList().Where(x=>x.ClassId==getId.ClassId).ToList(),
            };

            return View(values);
        }
    }
}
