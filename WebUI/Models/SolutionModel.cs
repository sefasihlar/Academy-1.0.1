using EntityLayer.Concrete;

namespace WebUI.Models
{
    public class SolutionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
