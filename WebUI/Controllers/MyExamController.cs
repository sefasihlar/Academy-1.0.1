using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class MyExamController : Controller
	{
		ExamManager _examManager = new ExamManager(new EfCoreExamRepository());
        public IActionResult Index()
        {
            //burada sisteme giriş yapan kullanıcının sınıf bilgisine göre sınvalar görüntülenmesi lazım 
            //sisteme giriş yapan kullanıcıyı bulup sınıf bilgisiyle filtelecek

            var values = new ExamListModel()
            {
                Exams = _examManager.GetWithList().ToList(),
            };

            return View(values);
        }
    }
}
