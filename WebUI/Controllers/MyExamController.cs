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
        QuestionManager _questionManager = new QuestionManager(new EfCoreQuestionRepository());
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
                Exams = _examManager.GetWithList().Where(x => x.ClassId == getId.ClassId).ToList(),
            };

            return View(values);
        }

        public IActionResult TeacherExams()
        {
            var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            var getId = _appUserManager.GetById(Convert.ToInt32(userId));

            var values = new ExamListModel()
            {
                Exams = _examManager.GetWithList().Where(x=>x.UserId==getId.Id).ToList(),
            };

            return View(values);
        }

        public IActionResult Exam(int id)
        {
            var süre = 60;

            var values = new QuestionListModel()
            {
                Questions = _questionManager.GetQuestionsByExam(id),

                SureDegeri = süre
            };
            ViewBag.ExamId = id;

            return View(values);
        } 



    }
}
