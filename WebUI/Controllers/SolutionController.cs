using BusinessLayer.Concrete;
using DataAccessLayer.EfCoreRepository;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class SolutionController : Controller
	{
		SolutionManager _solutionManager = new SolutionManager(new EfCoreSolutionRepository());
		OptionManager _optionManager = new OptionManager(new EfCoreOptionRepository());
		public IActionResult Index()
		{
			var values = new SolutionListModel()
			{
				Solutions = _solutionManager.GetWithQuestionList().ToList(),
			};
			return View(values);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var options = _optionManager.GetAll();
			ViewBag.options = new SelectList(options, "Id", "Name");

			var values = new SolutionListModel()
			{
				Solutions = _solutionManager.GetWithQuestionList()
			};

			return View(values);
		}


		[HttpPost]
		public IActionResult Create(SolutionModel model)
		{
			var values = new Solution()
			{
				Text = model.Text,
				VideoUrl = model.VideoUrl,
				QuestionId = model.QuestionId,
				OptionId = model.OptionId,

			};
			if (values!=null)
			{
				_solutionManager.Create(values);
				return RedirectToAction("Index", "Solution");
			}

			var options = _optionManager.GetAll();
			ViewBag.options = new SelectList(options, "Id", "Name");

			return View(model);
		}

		[HttpGet]
		public IActionResult Detail(int id)
		{
			var values = _solutionManager.GetById(id);
			if (values == null)
			{
				return NotFound();
			}

			return View(new SolutionModel()
			{
				Id= values.Id,
				Text= values.Text,
				VideoUrl = values.VideoUrl,
				QuestionId = values.QuestionId,
				OptionId = values.OptionId,
				Condition= values.Condition,
			});
		}


		[HttpPost]
		public IActionResult Update(SolutionModel model)
		{
			var values = _solutionManager.GetById(model.Id);

			if (values==null)
			{
				return NotFound();
			}

			model.Text = values.Text;
		    model.VideoUrl= values.VideoUrl;
			model.QuestionId = values.QuestionId;
			model.OptionId = values.OptionId;
			model.Condition= values.Condition;


			return RedirectToAction("Index","Solution");
		}

		public IActionResult Questions()
		{
			return View();
		}

	}
}
