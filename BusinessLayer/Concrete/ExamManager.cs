using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public void Create(Exam entity)
        {
            _examDal.Create(entity);
        }

        public void Delete(Exam entity)
        {
            _examDal.Delete(entity);
        }

        public List<Exam> GetAll()
        {
            return _examDal.GetAll().ToList();
        }

        public Exam GetById(int id)
        {
            return _examDal.GetById(id);
        }

        public void Update(Exam entity)
        {
            _examDal.Update(entity);
        }
    }
}
