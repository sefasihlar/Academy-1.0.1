using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class LessonController : Controller
    {
        LessonManager _lessonManager = new LessonManager(new EfCoreLessonRepository());
        ClassManager _classManager = new ClassManager(new EfCoreClassRepository());
        public IActionResult Index()
        {
            var values = new LessonListModel()
            {
                Lessons = _lessonManager.GetWithClassList()
            };

            if (values == null)
            {
                return NotFound();
            }

            return View(values);
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            var classes = _classManager.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            if (classes==null)
            {
                return NotFound();
            }

            var values = new LessonListModel()
            {
                Lessons = _lessonManager.GetWithClassList()
            };

            if (values==null)
            {
                return NotFound();
            }

            return View(values);
        }


        [HttpPost]
        public IActionResult Create(LessonModel model)
        {
            var values = new Lesson()
            {
                Name = model.Name,
                ClassId = model.ClassId,
            };

            if (values != null)
            {
                _lessonManager.Create(values);
                return RedirectToAction("Index", "Lesson");
            }

            var classes = _classManager.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            return View(model);
        }
    }
}
