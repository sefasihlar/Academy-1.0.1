using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
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
                Questions = _questionManager.GetAll().ToList()
            });
        }

        
    }
}
