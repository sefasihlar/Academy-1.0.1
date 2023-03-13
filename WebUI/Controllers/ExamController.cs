﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ExamController : Controller
    {
        ClassManager _classManager = new ClassManager(new EfCoreClassRepository());
        LessonManager _lessonManager = new LessonManager(new EfCoreLessonRepository());
        SubjectManager _subjectManager = new SubjectManager(new EfCoreSubjectRepository());
        ExamManager _examManager = new ExamManager(new EfCoreExamRepository());
        QuestionManager _questionManager = new QuestionManager(new EfCoreQuestionRepository());
        public IActionResult Index()
        {

            var values = new ExamListModel()
            {
                Exams = _examManager.GetWithList().ToList(),
            };

            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ExamModel model)
        {
            if (ModelState.IsValid)
            {
                var values = new Exam()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    ExamDate = model.ExamDate,
                    ClassId = model.ClassId,
                    LessonId = model.LessonId,
                    SubjectId = model.SubjectId,
                    CreatedDate = model.CreatedDate,
                    UpdatedDate = model.UpdatedDate,
                    Condition = model.Condition,
                };


                if (values != null)
                {
                    _examManager.Create(values);
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Basariyla Eklendi",
                        Message = "Sinav basariyla eklendi Sinavlarim kismindan eklemis oldugunuz sinavlari goruntuleyebilirsiniz",
                        Css = "success"
                    });
                    return RedirectToAction("Index", "Exam");

                }
            }

           
            var lesson = _lessonManager.GetAll();
            ViewBag.lessons = new SelectList(lesson, "Id", "Name");

            var level = _classManager.GetAll();
            ViewBag.levels = new SelectList(level, "Id", "Name");

            var subject = _subjectManager.GetAll();
            ViewBag.subjects = new SelectList(subject, "Id", "Name");

            TempData.Put("message", new ResultMessage()
            {
                Title = "Hata",
                Message = "Sinav ekleme işlemi başarısız.Lütfen bilgileri gözden geçiriniz",
                Css = "error"
            });

            return RedirectToAction("Index","Exam",model);
        }



        [HttpPost]
        public IActionResult Delete(int examId, int classId, int lessonId, int subjectId)
        {
            if (examId != null || classId != null || lessonId != null || subjectId != null)
            {
                _examManager.DeleteFromExam(examId, classId, lessonId, subjectId);
				TempData.Put("message", new ResultMessage()
				{
					Title = "Silme basarili",
					Message = "Sinaviniz basariyla silindi",
					Css = "success"
				});
				return RedirectToAction("Index", "Exam");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var values = _examManager.GetById(id);
            if (values == null)
            {
                return NotFound();
            }


            return View(new ExamModel()
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                ClassId = values.ClassId,
                LessonId = values.LessonId,
                SubjectId = values.SubjectId,
                CreatedDate = values.CreatedDate,
                UpdatedDate = values.UpdatedDate,
                Condition = values.Condition,
            });
        }

        [HttpPost]
        public IActionResult Update(ExamModel model)
        {
            var values = _examManager.GetById(model.Id);
            if (values != null)
            {
                values.Id = model.Id;
                values.Title = model.Title;
                values.Description = model.Description;
                values.ClassId = model.ClassId;
                values.LessonId = model.LessonId;
                values.SubjectId = model.SubjectId;
                values.UpdatedDate = model.UpdatedDate;
                values.Condition = model.Condition;

                _examManager.Update(values);
				TempData.Put("message", new ResultMessage()
				{
					Title = "Guncelleme basarili",
					Message = "Sinav guncelleme islemi basariyla gerceklesti",
					Css = "success"
				});
				return RedirectToAction("Index", "Exam");
            }
			TempData.Put("message", new ResultMessage()
			{
				Title = "Guncelleme basarisiz",
				Message = "Sinav guncelleme islemi basarisiz lütfen bilgileri gozden geciriniz",
				Css = "error"
			});
			return View(model);
        }



        [HttpGet]
        public IActionResult Exam(int id)
        {
            var süre = 60;

            var values = new QuestionListModel()
            {
                
                Questions = _questionManager.GetQuestionsByExam(id),
                
                SureDegeri = süre

            };
            
            ViewBag.ExamId = id;

            return View(values);
        }
    }
}
