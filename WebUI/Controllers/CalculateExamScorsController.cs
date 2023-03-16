using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class CalculateExamScorsController : Controller
	{

		ExamAnswerManager _examAnswerManager = new ExamAnswerManager(new EfCoreExamAswerRepository());
		SolutionManager _solutionManager = new SolutionManager(new EfCoreSolutionRepository());
		CartManager _cartManager = new CartManager(new EfCoreCartRepository());
		AppUserManager _appUserManager = new AppUserManager(new EfCoreAppUserRepostory());
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;

		public CalculateExamScorsController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			return View();
		}



		public IActionResult AllUsersResultQuestions(int id)
		{
			var examAnswers = _examAnswerManager.GetListTogether().Where(x => x.ExamId == id).ToList();
			var solutions = _solutionManager.GetWithQuestionList();
			var allUsersResults = new List<ExamAnswerListModel>();
			var users = _userManager.Users.ToList();

			foreach (var user in users)
			{
				var userExamAnswers = examAnswers.Where(x => x.UserId == user.Id).ToList();

				var nullQuestion = 0;
				var score = 0;
				var questionFalse = 0;
				var questionTrue = 0;
				var trueOption = "";

				var correctAnswers = new List<string>();

				if (userExamAnswers == null)
				{
					continue;
				}

				foreach (var examAnswer in userExamAnswers)
				{
					if (examAnswer.OptionId != null)
					{
						var solution = solutions.FirstOrDefault(s => s.Question.Id == examAnswer.Question.Id && s.OptionId == examAnswer.Option.Id);

						var TrueOption = solutions.FirstOrDefault(s => s.Question.Id == examAnswer.QuestionId).Option.Name;
						correctAnswers.Add(TrueOption);

						if (solution != null)
						{
							score += 5;
							questionTrue += 1;
						}

						else if (solution == null)
						{
							questionFalse += 1;
						}

						else
						{
							nullQuestion += 1;
						}

					}
					else
					{
						var TrueOption = solutions.FirstOrDefault(s => s.Question.Id == examAnswer.QuestionId).Option.Name;
						correctAnswers.Add(TrueOption);
						nullQuestion += 1;
					}
				}

				var model = new ExamAnswerListModel()
				{
					ExamAnswers = userExamAnswers,
					QuestionFalse = questionFalse,
					QuestionTrue = questionTrue,
					QuestionNull = nullQuestion,
					Score = score,
					CorrectAnswers = correctAnswers,

				};

				allUsersResults.Add(model);
			}

			return View(allUsersResults);

		}
	}
}
