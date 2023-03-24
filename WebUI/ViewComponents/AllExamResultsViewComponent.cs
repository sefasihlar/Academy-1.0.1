using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using DataAccessLayer.EfCoreRepository;

namespace WebUI.ViewComponents
{
    public class AllExamResultsViewComponent:ViewComponent
    {
        ScorsManager _scorsManager = new ScorsManager(new EfCoreScorsRepository());
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IViewComponentResult Invoke(int LessonId,int UserId)
        {
            if (LessonId == 0)
            {
                LessonId = 4;
            }
            var values = new ScorListModel()
            {
                scors = _scorsManager.GetTogetherList().Where(x => x.Exam.Lesson.Id == ViewBag.LessonId & x.UserId == ViewBag.userId).ToList()
            };

            if (values!=null)
            {
                return View(values);
            }

            return View(LessonId);
            
        }
    }
}
