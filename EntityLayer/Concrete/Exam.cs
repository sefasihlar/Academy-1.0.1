﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Exam : BaseTable
    {
        public string? Title { get; set; }
        public String Description { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
