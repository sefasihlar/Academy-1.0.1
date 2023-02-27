using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using DataAccessLayer.EfCoreRepository;
using EntityLayer.Concrete;

namespace WebUI.ViewComponents
{
    public class OptionViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new QuestionModel()
            {
            });
        }
    }
}
