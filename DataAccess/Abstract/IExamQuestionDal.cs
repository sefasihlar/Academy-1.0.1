using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IExamQuestionDal : IGenericDal<ExamQuestions>
    {
        void Create(ExamQuestions entity, int questionId);

        List<ExamQuestions> GetQuestionsList();
        void DeleteFromExamQuestion(ExamQuestions entity, int questionId);
    }
}
