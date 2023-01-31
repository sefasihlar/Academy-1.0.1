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
    public class OutputManager : IOutputService
    {
        private readonly IOutputDal _outputDal;

        public OutputManager(IOutputDal outputDal)
        {
            _outputDal = outputDal;
        }

        public void Create(Output entity)
        {
            _outputDal.Create(entity);  
        }

        public void Delete(Output entity)
        {
            _outputDal.Delete(entity);
        }

        public List<Output> GetAll()
        {
            return _outputDal.GetAll().ToList();
        }

        public Output GetById(int id)
        {
            return _outputDal.GetById(id);
        }

        public void Update(Output entity)
        {
            _outputDal.Update(entity);
        }
    }
}
