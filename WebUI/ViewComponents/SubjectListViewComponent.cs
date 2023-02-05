using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.ViewComponents
{
    public class SubjectListViewComponent : ViewComponent
    {
        SubjectManager _lessonManager = new SubjectManager(new EfCoreSubjectRepository());

        public IViewComponentResult Invoke(SubjectModel model)
        {
            var subject = _lessonManager.GetAll();
            ViewBag.subject = new SelectList(subject, "Id", "Name");
            return View(model);
        }
    }
}
