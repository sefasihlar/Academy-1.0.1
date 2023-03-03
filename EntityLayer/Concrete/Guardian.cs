﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Guardian
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string ? Name2 { get; set; }
        public string SurName { get; set; }
        public string? SurName2 { get; set; }
        public string Phone { get; set; }
        public string ? Phone2 { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

        public bool Condition { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;

	}
}