using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ExamQuestionController : Controller
    {

        QuestionManager _questionManager = new QuestionManager(new EfCoreQuestionRepository());
        ExamQuestionManager _examQuestionManager = new ExamQuestionManager(new EfCoreExamQuestionRepository());


        public IActionResult Index(ExamModel model)
        {

            var values = new QuestionListModel()
            {
                Questions = _questionManager.GetWithList()
                .Where(x => x.LessonId == model.LessonId)
                .Where(x => x.SubjectId == model.SubjectId)
                .ToList(),
            };

            ViewBag.ExamId = model.Id;

            return View(values);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExamQuestions model, int[] questionIds)
        {

            if (model != null & questionIds != null)
            {


                foreach (var item in questionIds)
                {
                    //buraya userId eklenecek
                    _examQuestionManager.Create(model, item);

                };
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Basariyla Eklendi",
                    Message = "Sinav soruları basariyla eklendi",
                    Css = "error"
                });
                return RedirectToAction("Index", "Exam");

            }

            return View(model);
        }



        //burası silmeyecek alan  arasında yer alabilir. ilişkileri silmemiz gerekiyor 
        [HttpPost]
        public IActionResult Delete(int examId, int[] questionsId)
        {
            var values = _examQuestionManager.GetById(examId);

            if (examId != null & questionsId != null)
            {
                foreach (var item in questionsId)
                {
                    _examQuestionManager.DeleteFormExamQuestion(values, item);
                }

                return RedirectToAction("Index", "Exam");

            }

            return NotFound();
        }


        //şu an için kullanılmayacak
        //sınavın sorularını farklı bir sayfada sıralayıp listeleyebiliz
        //güncelleme işlemlerinide kolaylarştır
        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Update(ExamQuestions model, int[] questionIds)
        {
            var values = _examQuestionManager.GetById(model.ExamId);


            if (model != null & questionIds != null)
            {
                foreach (var item in questionIds)
                {
                    values.QuestionId = item;
                }

                _examQuestionManager.Update(values);
                return RedirectToAction("Index", "Exam");
            }

            return View(model);
        }

    }
}
