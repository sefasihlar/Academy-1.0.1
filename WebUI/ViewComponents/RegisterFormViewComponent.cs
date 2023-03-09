using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using System.ComponentModel;

namespace WebUI.ViewComponents
{
    public class RegisterFormViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(RegisterModel model)
        {
            var values = new RegisterModel()
            {

            };

            return View(values);
        }
    }
}
