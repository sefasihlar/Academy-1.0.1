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
        public IActionResult Create(ExamAnswers model, int[] questionIds, Dictionary<int,int> optionIds)
        {
            //yarın bu algoritmanın açıklamasını yaz

            var optionCount = optionIds.Count();
          
            if (model != null & questionIds != null)
            {
                model.UserId = 1;
                foreach (var item in questionIds)
                {

                    foreach (var option in optionIds)
                    {
                        if (optionCount!=0)
                        {
                            _examAnswerManager.Create(model, item, option.Value);
                            optionCount--;
                        }
                        else
                        {
                            _examAnswerManager.Create(model, item, null);
                        }
                       
                    }
                };

                return RedirectToAction("Index", "Exam");

            }

            return View(model);
        }


    }
}
