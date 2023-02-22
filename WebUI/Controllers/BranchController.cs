using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
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
			var values = new Branch
			{

				Name = model.Name,
				CreatedDate= model.CreatedDate,
			};
			if (values == null)
			{
				return NotFound(model);
			}
			_branchManager.Create(values);
			return View();

		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var values = _branchManager.GetById(id);
			if (values != null)
			{

				_branchManager.Delete(values);
				return View();
			}
			return View();
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

			});
		}
	[HttpPost]
	public IActionResult Update(BranchModel model)
	{
		if (ModelState.IsValid)
		{
			var values = _branchManager.GetById(model.Id);
			if (values != null)
			{
				return NotFound();
			}
			_branchManager.Update(values);
		}
		return View();
	}


}
}
