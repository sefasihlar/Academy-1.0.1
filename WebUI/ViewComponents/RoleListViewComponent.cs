using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace WebUI.ViewComponents
{
    public class RoleListViewComponent:ViewComponent
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleListViewComponent(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = new AppRoleListModel()
            {
                Roles = _roleManager.Roles.ToList()
            };
            return View(values);
        }
    }
}
