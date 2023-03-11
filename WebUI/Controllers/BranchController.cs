using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Öğretmen,Müdür Yardımcısı")]
    public class BranchController : Controller
    {
        BranchManager _branchManager = new BranchManager(new EfCoreBranchRepository());
        public IActionResult Index()
        {
            return View(new BranchListModel()
            {
                Branches = _branchManager.GetAll().ToList()
            });

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(BranchModel model)
        {
            if (ModelState.IsValid)
            {
                var values = new Branch
                {

                    Name = model.Name,
                    Condition = model.Condition,
                    CreatedDate = model.CreatedDate,
                };
                if (values == null)
                {
                    return NotFound(model);
                }
                _branchManager.Create(values);
                return RedirectToAction("Index", "Branch");
            }


            return RedirectToAction("Index", "Branch", model);



        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _branchManager.GetById(id);
            if (values != null)
            {

                _branchManager.Delete(values);
                return RedirectToAction("Index", "Branch");
            }
            return View("Index", "Branch");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var values = _branchManager.GetById(id);

            if (values == null)
            {

                return NotFound();
            }

            return View(new BranchModel()
            {
                Id = values.Id,
                Name = values.Name,
                Condition = values.Condition,

            });
        }
        [HttpPost]
        public IActionResult Update(BranchModel model)
        {

            var values = _branchManager.GetById(model.Id);
            if (values == null)
            {
                return NotFound();
            }
            values.Name = model.Name;
            values.Condition = model.Condition;
            values.UpdatedDate = model.UpdatedDate;
            _branchManager.Update(values);

            return RedirectToAction("Index", "Branch");
        }


    }
}
