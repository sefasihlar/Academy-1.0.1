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
    public class OutputController : Controller
    {
        OutputManager _outputManager = new OutputManager(new EfCoreOutputRepository());
        public IActionResult Index()
        {
            var values = new OutputListModel()
            {
                Outputs = _outputManager.GetAll()
            };

            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OutputModel model)
        {
            if (ModelState.IsValid)
            {

                var values = new Output()
                {
                    Name = model.Name,
                    Condition = model.Condition,
                    CreatedDate = model.CreatedDate,
                    UpdatedDate = model.UpdatedDate,
                };

                if (values != null)
                {
                    _outputManager.Create(values);
					TempData.Put("message", new ResultMessage()
					{
						Title = "Başarılı",
						Message = "Öğrenme çıktısı eklendi",
						Css = "success"
					});
					return RedirectToAction("Index", "Output");
                }
            }
			TempData.Put("message", new ResultMessage()
			{
				Title = "Hata",
				Message = "Öğrenme çıktısı ekleme işlemşi başarısız. Lütfen bilgileri gözden geçiriniz",
				Css = "error"
			});
			return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _outputManager.GetById(id);
            if (values != null)
            {
                _outputManager.Delete(values);
                return RedirectToAction("Index", "Output");
            }

            return NotFound(values);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var values = _outputManager.GetById(id);
            if (values == null)
            {
                return NotFound();
            }

            return View(new OutputModel()
            {
                Id = values.Id,
                Name = values.Name,
                Condition = values.Condition,
                CreatedDate = values.CreatedDate,
                UpdatedDate = values.UpdatedDate,
            });
        }

        [HttpPost]
        public IActionResult Update(OutputModel model)
        {
            if (ModelState.IsValid)
            {
                var values = _outputManager.GetById(model.Id);
                if (values != null)
                {
                    values.Name = model.Name;
                    values.Condition = model.Condition;
                    values.CreatedDate = model.CreatedDate;
                    values.UpdatedDate = model.UpdatedDate;

                    _outputManager.Update(values);
					TempData.Put("message", new ResultMessage()
					{
						Title = "Başarılı",
						Message = "Öğrenme çıktısı başarıyla güncellendi",
						Css = "success"
					});
					return RedirectToAction("Index", "Output");
                }
            }
			TempData.Put("message", new ResultMessage()
			{
				Title = "Hata",
				Message = "Öğrenme çıktısı güncellenemedi lütfen bilgileri gözden geçiriniz",
				Css = "error"
			});
			return NotFound(model);
        }
    }
}
