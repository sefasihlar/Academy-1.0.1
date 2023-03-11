using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using WebUI.Models;

namespace WebUI.Controllers
{

    public class ExamResultController : Controller
    {
        ExamAnswerManager _examAnswerManager = new ExamAnswerManager(new EfCoreExamAswerRepository());
        SolutionManager _solutionManager = new SolutionManager(new EfCoreSolutionRepository());
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
                        ExamId = x.Exam.Id,
                        Name = x.Exam.Title,
                        Description = x.Exam.Description,
                        ExamDate = x.Exam.ExamDate,
                        LessonName = x.Exam.Lesson.Name,
                        SubjectName = x.Exam.Subject.Name,

                    }).ToList()
                };
                return View(values);
            }
            //eğer kullanıcıya tanımlı bir sınav yoksa mesaj bildirilsin
            return View();
        
        }
        [HttpGet]
        public IActionResult ResultQuestions(int id)
        {
            var score = 0;
            var questionFalse = 0;
            var questionTrue = 0;
            var trueOption = "";
            var correctAnswers = new List<string>();

            var examAnswers = _examAnswerManager.GetListTogether().Where(x => x.ExamId == id).ToList();
            var solutions = _solutionManager.GetWithQuestionList();

          
            foreach (var examAnswer in examAnswers)
            {
                var solution = solutions.FirstOrDefault(s => s.Question.Id == examAnswer.Question.Id && s.OptionId == examAnswer.Option.Id);

                var TrueOption = solutions.FirstOrDefault(s => s.Question.Id == examAnswer.QuestionId).Option.Name;
                correctAnswers.Add(TrueOption);

                if (solution != null)
                {
                    score += 5;
                    questionTrue += 1;
                }

                else if(solution==null)
                {
                    questionFalse += 1;
                }
            }

            var model = new ExamAnswerListModel()
            {
                ExamAnswers = examAnswers,
                QuestionFalse = questionFalse,
                QuestionTrue = questionTrue,
                Score = score,
                CorrectAnswers = correctAnswers
            };

            return View(model);
        }

        public IActionResult ResultVideo(int id)
        {
            var questionId = _solutionManager.GetAll().FirstOrDefault(x => x.QuestionId == id);

            var values = new SolutionModel()
            {
                QuestionId = id,
                Text = questionId.Text,
                VideoUrl = questionId.VideoUrl,
            };
            return View(values);
        }
    }
}
