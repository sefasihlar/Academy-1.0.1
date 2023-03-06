using EntityLayer.Concrete;

namespace WebUI.Models
{
	public class GuardianModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Name2 { get; set; }
		public string SurName { get; set; }
		public string? SurName2 { get; set; }
		public string Phone { get; set; }
		public string? Phone2 { get; set; }

		public int UserId { get; set; }
		public AppUser User { get; set; }

		public bool Condition { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
	}
}
