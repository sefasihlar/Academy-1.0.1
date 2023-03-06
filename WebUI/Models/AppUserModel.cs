using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace WebUI.Models
{
	public class AppUserModel : IdentityUser<int>
	{
		public int Tc { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }

		public int ClassId { get; set; }
		public Class Class { get; set; }

		public int BranchId { get; set; }
		public Branch Branch { get; set; }

		public List<ExamAnswers> ExamAnswers { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;

		public Boolean Condition { get; set; }
	}
}
