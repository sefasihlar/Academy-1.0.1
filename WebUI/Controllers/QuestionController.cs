using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class QuestionController : Controller
    {
        QuestionManager _questionManager = new QuestionManager(new EfCoreQuestionRepository());
        LessonManager _lessonManager = new LessonManager(new EfCoreLessonRepository());
        LevelManager _levelManager = new LevelManager(new EfCoreLevelRepository());
        SubjectManager _subjectManager = new SubjectManager(new EfCoreSubjectRepository());
        OutputManager _outputManager = new OutputManager(new EfCoreOutputRepository());
        OptionManager _optionManager = new OptionManager(new EfCoreOptionRepository());
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
            return View(new QuestionModel()
            {

            });
        }


        [HttpPost]
        public async Task<IActionResult> Create(QuestionModel model, IFormFile file, OptionModel options)
        {

            var questionOptions = new List<Option>(); // yeni bir liste oluştur

            foreach (var item in model.Options)
            {
                var optionValue = new Option()
                {
                    Name = item.Name,
                    Text = item.Text,
                    Condition = item.Condition,
                };
                questionOptions.Add(optionValue); // Option nesnelerini yeni liste olarak ekle
            }

            // Question nesnesini oluştur
            var values = new Question()
            {
                Text = model.Text,
                QuestionText = model.QuestionText,
                ImageUrl = file.FileName,
                LessonId = model.LessonId,
                LevelId = model.LevelId,
                SubjectId = model.SubjectId,
                Options = questionOptions, // yeni liste olarak ekle
                OutputId = model.OutputId,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
            };

            // Question nesnesini veritabanına ekle
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Template\\questions", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (values != null)
            {
                _questionManager.Create(values);
                return RedirectToAction("Index", "Question");
            }

            // Question nesnesinin Id özelliğini al
            var questionId = values.Id;

            // Option nesnelerinin QuestionId özelliğini güncelle
            foreach (var item in questionOptions)
            {
                item.QuestionId = questionId;
                _optionManager.Create(item);
            }

            
            //eger bir validation ile karsilasirsa dropdownlarin tekara dolmasi icin tekrar ediyoruz

            var lesson = _lessonManager.GetAll();
            ViewBag.lessons = new SelectList(lesson, "Id", "Name");

            var level = _levelManager.GetAll();
            ViewBag.levels = new SelectList(level, "Id", "Name");

            var subject = _subjectManager.GetAll();
            ViewBag.subjects = new SelectList(subject, "Id", "Name");

            var output = _outputManager.GetAll();
            ViewBag.outputs = new SelectList(output, "Id", "Name");

            var option = _optionManager.GetAll();
            ViewBag.options = new SelectList(option, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int questionId, int outputId, int optionId, int subjectId, int lessonId)
        {
            _questionManager.DeleteFromQuestion(questionId, outputId, optionId, subjectId, lessonId);
            return RedirectToAction("Index", "Question");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var values = _questionManager.GetById(id);
            if (values == null)
            {
                return NotFound();
            }

            return View(new QuestionModel()
            {
                Id = values.Id,
                Text = values.Text,
                QuestionText= values.QuestionText,
                ImageUrl = values.ImageUrl,
                LessonId = values.LessonId,
                LevelId = values.LevelId,
                SubjectId = values.SubjectId,
                Options = values.Options,
                OutputId = values.OutputId,
                CreatedDate = values.CreatedDate,
                UpdatedDate = values.UpdatedDate,
                Condition = values.Condition,
            });
        }

        [HttpPost]
        public IActionResult Update(QuestionModel model)
        {
            if (ModelState.IsValid)
            {


                var values = _questionManager.GetById(model.Id);
                if (values != null)
                {
                    values.Text = model.Text;
                    values.QuestionText = model.QuestionText;
                    values.ImageUrl = model.ImageUrl;
                    values.LessonId = model.LessonId;
                    values.LevelId = model.LevelId;
                    values.SubjectId = model.SubjectId;
                    values.Options = model.Options;
                    values.OutputId = model.OutputId;
                    values.CreatedDate = model.CreatedDate;
                    values.UpdatedDate = model.UpdatedDate;
                    values.Condition = model.Condition;


                    _questionManager.Update(values);
                    return RedirectToAction("Index", "Question");
                }
            }
            return View(model);

        }




    }
}
