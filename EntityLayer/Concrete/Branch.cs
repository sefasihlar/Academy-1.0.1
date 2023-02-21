using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public  class Branch
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
