﻿using EntityLayer.Concrete;

namespace WebUI.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool Condition { get; set; }


    }
}
