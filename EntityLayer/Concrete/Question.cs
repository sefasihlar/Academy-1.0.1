namespace EntityLayer.Concrete
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string ImageUrl { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }


        public int LevelId { get; set; }
        public Level Level { get; set; }



        public int SubjectId { get; set; }
        public Subject Subject { get; set; }



        public int OutputId { get; set; }
        public Output Output { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Boolean Condition { get; set; }


    }
}
