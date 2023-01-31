using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void Create(Question entity)
        {
            _questionDal.Create(entity);
        }

        public void Delete(Question entity)
        {
            _questionDal.Delete(entity);
        }

        public List<Question> GetAll()
        {
            return _questionDal.GetAll().ToList();
        }

        public Question GetById(int id)
        {
            return _questionDal.GetById(id);
        }

        public void Update(Question entity)
        {
            _questionDal.Update(entity);
        }
    }
}
