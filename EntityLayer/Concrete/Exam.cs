﻿namespace EntityLayer.Concrete
{
    public class Exam
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public String Description { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        public List<Question> Questions { get; set; }



    }
}
