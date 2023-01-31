using EntityLayer.Concrete;

namespace WebUI.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual AppUser? User { get; set; }

        public List<Question> Questions { get; set; }
    }
}
