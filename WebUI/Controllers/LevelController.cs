using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Öğretmen")]
    public class LevelController : Controller
    {
        LevelManager _levelManager = new LevelManager(new EfCoreLevelRepository());
        public IActionResult Index()
        {
            return View(new LevelListModel()
            {
                Levels = _levelManager.GetAll()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LevelModel model)
        {
            if (ModelState.IsValid)
            {

                var values = new Level()
                {
                    Name = model.Name,
                    Condition = model.Condition,
                    CreatedDate = model.CreatedDate,
                };

                _levelManager.Create(values);

                return RedirectToAction("Index", "Level");
            }


            return View(model);
        }

        public IActionResult Delete(LevelModel model)
        {
            var values = _levelManager.GetById(model.Id);

            if (values != null)
            {
                _levelManager.Delete(values);
                return RedirectToAction("Index", "Level");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Detail(LevelModel model)
        {
            var values = _levelManager.GetById(model.Id);

            if (values == null)
            {
                return NotFound();
            }

            return View(new LevelModel()
            {
                Id = values.Id,
                Name = values.Name,
                Condition = values.Condition,
            });
        }

        [HttpPost]
        public IActionResult Update(LevelModel model)
        {
            if (ModelState.IsValid)
            {

                var values = _levelManager.GetById(model.Id);

                if (values == null)
                {
                    return NotFound();
                }

                values.Name = model.Name;
                values.Condition = model.Condition;
                values.UpdatedDate = model.UpdatedDate;
                _levelManager.Update(values);

            }
            return RedirectToAction("Index", "Level");
        }

    }
}
