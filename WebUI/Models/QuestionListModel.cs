using EntityLayer.Concrete;

namespace WebUI.Models
{
    public class QuestionListModel
    {
        public List<Question> Questions { get; set; }
        public int SureDegeri { get; set; }

        public List<int> SelectedQuestions { get; set; }
    }
}
