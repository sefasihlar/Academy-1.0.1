using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using DataAccessLayer.EfCoreRepository;

namespace WebUI.ViewComponents
{
	public class BranchListViewComponent:ViewComponent
	{
		BranchManager _branchManager = new BranchManager(new EfCoreBranchRepository());

		public IViewComponentResult Invoke(BranchModel model)
		{
			var branch = _branchManager.GetAll();
			ViewBag.brances = new SelectList(branch, "Id", "Name");
			return View(model);
		}
	}
}
