using BusinessLayer.GenericService;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IExamQuestionService : IGenericService<ExamQuestions>
    {
        void Create(ExamQuestions entity, int questionId);

        List<ExamQuestions> GetQuestionsList();
        void DeleteFormExamQuestion(ExamQuestions entity, int questionId);
    }
}
