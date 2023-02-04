using BusinessLayer.GenericService;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IQuestionService : IGenericService<Question>
    {
        List<Question> GetWithList();
        void DeleteFromQuestion(int questionId,int outputId,int optionId,int subjectId, int lessonId,int examId);
    }
}
