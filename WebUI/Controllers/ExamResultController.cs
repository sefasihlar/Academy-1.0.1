using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    
    public class ExamResultController : Controller
    {
        ExamAnswerManager _examAnswerManager = new ExamAnswerManager(new EfCoreExamAswerRepository());
        CartManager _cartManager = new CartManager(new EfCoreCartRepository());
        AppUserManager _appUserManager = new AppUserManager(new EfCoreAppUserRepostory());
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public ExamResultController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var cart = _cartManager.GetCartByUserId(_userManager.GetUserId(User));

            if (cart != null)
            {
                var values = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(x => new CartItemModel()
                    {
                        //Include ve ThenInclude yapılacak
                        CartItemId = x.Id,
                        ExamId = x.ExamId,
                        Name = x.Exam.Title,
                        Description = x.Exam.Description,
                        ExamDate = x.Exam.ExamDate,
                        ClassName = x.Exam.Class.Name,
                        LessonName = x.Exam.Lesson.Name,
                        SubjectName = x.Exam.Subject.Name,

                    }).ToList()
                };
                return View(values);
            } 
            //eğer kullanıcıya tanımlı bir sınav yoksa mesaj bildirilsin
            return View();
        }

        public IActionResult ResultQuestions(int examId)
        {
            return View();
        }

        public IActionResult ResultVideo()
        {
            return View();
        }
    }
}
