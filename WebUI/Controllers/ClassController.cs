using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ClassController : Controller
    {
        ClassManager _classManager = new ClassManager(new EfCoreClassRepository());

        public IActionResult Index()
        {
            return View(new ClassListModel()
            {
                //where(x=> x.solution).ToList() Expression oldugu icin filtreleme yapabiliriz
                Classes = _classManager.GetAll().ToList()
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClassModel model)
        {
            if (ModelState.IsValid)
            {
                var values = new Class
                {
                    Name = model.Name,
                };

                _classManager.Create(values);

                return RedirectToAction("Index", "Class");
                    
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _classManager.GetById(id);
            if (values!=null)
            {
                _classManager.Delete(values);
                return RedirectToAction("Index", "Class");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Detail(ClassModel model)
        {
            Class values = _classManager.GetById(model.Id);

            if (values == null)
            {
                return NotFound();
            }

            return View(values);
        }

    }
}
