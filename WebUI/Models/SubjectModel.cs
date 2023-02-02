using EntityLayer.Concrete;

namespace WebUI.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }



        public List<Question> Questions { get; set; }
    }
}
