using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Müdür")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = new AppRoleListModel()
            {
                Roles = _roleManager.Roles.ToList(),
            };


            return View(values);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(RoleModel model)
        {


            var values = new AppRole()
            {
                Name = model.Name,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                Condition = model.Condition,
            };

            var result = await _roleManager.CreateAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");

            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Detail(int id)
        {

            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            if (values == null)
            {
                return NotFound();
            }

            var model = new RoleModel()
            {
                Id = values.Id,
                Name = values.Name,
            };

            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Update(RoleModel model)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);

            if (values != null)
            {
                values.Name = model.Name;
                var result = await _roleManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }

                else
                {
                    return NotFound();
                }
            }

            return View(model);

        }


        public async Task<IActionResult> Delete(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            if (values != null)
            {
                var result = await _roleManager.DeleteAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
            }

            return View();

        }

        public IActionResult Officer()
        {

            return View();
        }


    }
}
