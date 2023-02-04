using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class QuestionController : Controller
    {
        QuestionManager _questionManager = new QuestionManager(new EfCoreQuestionRepository());

        public IActionResult Index()
        {

            return View(new QuestionListModel()
            {
                //where(x=> x.solution).ToList() Expression oldugu icin filtreleme yapabiliriz
                Questions = _questionManager.GetWithList().ToList()
            });
        }


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                var values = new Question()
                {
                    Text = model.Text,
                    ImageUrl = model.ImageUrl,
                    LessonId = model.LessonId,
                    LevelId = model.LevelId,
                    SubjectId = model.SubjectId,
                    OptionId = model.OptionId,
                    OutputId = model.OutputId,
                    CreatedDate = model.CreatedDate,
                    UpdatedDate = model.UpdatedDate,
                    Condition = model.Condition,
                };

                if (values!=null)
                {
                    _questionManager.Create(values);
                    return RedirectToAction("Index","Question");
                }
            }


            return View(model);
        }

        
    }
}
