using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SubjectManager : ISubjectService
    {
        private readonly ISubjectDal _subjectDal;

        public SubjectManager(ISubjectDal subjectDal)
        {
            _subjectDal = subjectDal;
        }

        public void Create(Subject entity)
        {
            _subjectDal.Create(entity);
        }

        public void Delete(Subject entity)
        {
            _subjectDal.Delete(entity);
        }

        public List<Subject> GetAll()
        {
            return _subjectDal.GetAll().ToList();
        }

        public Subject GetById(int id)
        {
            return _subjectDal.GetById(id);
        }

        public void Update(Subject entity)
        {
            _subjectDal.Update(entity);
        }
    }
}
