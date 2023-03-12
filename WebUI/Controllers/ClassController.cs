using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Öğretmen")]
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClassModel model)
        {

            var values = new Class
            {
                Name = model.Name,
                Condition = model.Condition,
            };

            _classManager.Create(values);

            TempData.Put("message", new ResultMessage()
            {
                Title = "Basarili",
                Message = "isleminiz basariyla gerceklesti",
                Css = "success"
            });

            return RedirectToAction("Index", "Class");

        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _classManager.GetById(id);
            if (values != null)
            {
                _classManager.Delete(values);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Başarlı",
                    Message = "Silme işlemi başarıyla gerçekleşti",
                    Css = "success"
                });
                return RedirectToAction("Index", "Class");
            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Opps!!!",
                Message = "Silme islemi gerceklestirlemedi",
                Css = "error"
            });

            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var values = _classManager.GetById(id);

            if (values == null)
            {
                return NotFound();
            }

            return View(new ClassModel()
            {
                Id = values.Id,
                Name = values.Name,
                Condition = values.Condition,
            });
        }



        [HttpPost]
        public IActionResult Update(ClassModel model)
        {
            if (ModelState.IsValid)
            {

                var values = _classManager.GetById(model.Id);

                if (values == null)
                {
                    return NotFound();
                }

                values.Name = model.Name;
                values.Condition = model.Condition;
                values.UpdatedDate = model.UpdatedDate;

                _classManager.Update(values);
            }
            return RedirectToAction("Index", "Class");
        }

    }
}
