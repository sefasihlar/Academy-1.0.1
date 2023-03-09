using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using EntityLayer.Concrete;

namespace WebUI.ViewComponents
{
    public class BranchFormViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var values = new BranchModel()
            {

            };


            return View(values);
        }
    }
}
