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
    public class SolutionManager : ISolutionService
    {
        private readonly ISolutionDal _solutionDal;

        public SolutionManager(ISolutionDal solutionDal)
        {
            _solutionDal = solutionDal;
        }

        public void Create(Solution entity)
        {
            _solutionDal.Create(entity);
        }

        public void Delete(Solution entity)
        {
            _solutionDal.Delete(entity);
        }

        public List<Solution> GetAll()
        {
            return _solutionDal.GetAll().ToList();
        }

        public Solution GetById(int id)
        {
            return _solutionDal.GetById(id);
        }

        public void Update(Solution entity)
        {
            _solutionDal.Update(entity);
        }
    }
}
