using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void Create(Lesson entity)
        {
            _lessonDal.Create(entity);
        }

        public void Delete(Lesson entity)
        {
            _lessonDal.Delete(entity);
        }

        public List<Lesson> GetAll()
        {
            return _lessonDal.GetAll().ToList();
        }

        public Lesson GetById(int id)
        {
            return _lessonDal.GetById(id);
        }

        public void Update(Lesson entity)
        {
            _lessonDal.Update(entity);
        }
    }
}
