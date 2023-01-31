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
    public class ClassManager : IClassService
    {
        private readonly IClassDal _classDal;

        public ClassManager(IClassDal classDal)
        {
            _classDal = classDal;
        }

        public void Create(Class entity)
        {
            _classDal.Create(entity);
        }

        public void Delete(Class entity)
        {
            _classDal.Delete(entity);
        }

        public List<Class> GetAll()
        {
            return _classDal.GetAll().ToList();
        }

        public Class GetById(int id)
        {
            return _classDal.GetById(id);
        }

        public void Update(Class entity)
        {
            _classDal.Update(entity);
        }
    }
}
