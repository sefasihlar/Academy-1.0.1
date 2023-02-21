﻿using EntityLayer.Concrete;

namespace WebUI.Models
{
	public class BranchModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ClassId { get; set; }
		public Class Class { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;

		public Boolean Condition { get; set; }
	}
}
