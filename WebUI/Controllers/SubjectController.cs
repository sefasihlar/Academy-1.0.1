using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Rewrite;
using System.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
	[Authorize(Roles = "Öğretmen")]
	public class SubjectController : Controller
    {
        LessonManager _lessonManager = new LessonManager(new EfCoreLessonRepository());
        SubjectManager _subjectManager = new SubjectManager(new EfCoreSubjectRepository());
        public IActionResult Index()
        {
            var values = new SubjectListModel()
            {
                Subjects = _subjectManager.GetWithLessonList()
            };

            return View(values);


        }

        [HttpGet]
        public IActionResult Create()
        {

            //var lesson = _lessonManager.GetAll();
            //ViewBag.lessons = new SelectList(lesson,"Id","Name");

            var values = new SubjectListModel()
            {
                Subjects = _subjectManager.GetWithLessonList()
            };
            return View();
        }


        [HttpPost]
        public IActionResult Create(SubjectModel model)
        {
            if (model.Name == null || model.LessonId == null)
            {
                return NotFound();
            }

            var values = new Subject()
            {
                Name = model.Name,
                LessonId = model.LessonId,
                Condition = model.Condition,
                CreatedDate = model.CreatedDate,

            };

            if (values != null)
            {
                _subjectManager.Create(values);
                return RedirectToAction("Index", "Subject");
            }

            var lesson = _lessonManager.GetAll();
            ViewBag.lessons = new SelectList(lesson, "Id", "Name");

            return View(model);

        }

        [HttpPost]
        public IActionResult Delete(int subjectId, int lessonId)
        {
            _subjectManager.DeleteFromSubject(subjectId, lessonId);
            return RedirectToAction("Index", "Subject");

        }

        [HttpGet]
        public IActionResult Detail(SubjectModel model)
        {
            var values = _subjectManager.GetById(model.Id);

            if (values == null)
            {
                return NotFound();
            }

            return View(new SubjectModel()
            {
                Id = values.Id,
                Name = values.Name,
                LessonId = values.LessonId,
                Condition= values.Condition,
            });
        }

        [HttpPost]
        public IActionResult Update(SubjectModel model)
        {
            var values = _subjectManager.GetById(model.Id);

            if (values == null)
            {
                return NotFound();
            }

            values.Name = model.Name;
            values.LessonId = model.LessonId;
            values.Condition = model.Condition;
            values.UpdatedDate = model.UpdatedDate;

            _subjectManager.Update(values);
            return RedirectToAction("Index","Subject");
        }
    }
}
