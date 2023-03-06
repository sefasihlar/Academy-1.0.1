using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class ExamAnswerController : Controller
	{
        ExamAnswerManager _examAnswerManager = new ExamAnswerManager(new EfCoreExamAswerRepository());
        ExamQuestionManager _examQuestionManager = new ExamQuestionManager(new EfCoreExamQuestionRepository());
		public IActionResult Index()
		{
			return View();
		}


        [HttpGet]
        public IActionResult Create(ExamAnswers model)
        {
            ViewBag.ExamModel = model.ExamId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ExamAnswers model, int[] questionIds, Dictionary<int, int> optionIds)
        {
            if (model != null && questionIds != null && optionIds != null)
            {
                model.UserId = 1;
                foreach (var item in questionIds)
                {
                    //TryGetValue değeri kontrol edip varsa atama yapar yoksa değeri null yaparak geçer
                    if (optionIds.TryGetValue(item, out int option))
                    {
                        _examAnswerManager.Create(model, item, option);
                    }
                    else
                    {
                        _examAnswerManager.Create(model, item, null);
                    }
                }

                return RedirectToAction("Index", "Exam");
            }

            return View(model);
        }


    }
}
