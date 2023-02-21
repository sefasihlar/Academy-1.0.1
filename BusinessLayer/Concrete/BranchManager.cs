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
	public class BranchManager : IBranchService
	{
		private readonly IBranchDal _branchDal;

		public BranchManager(IBranchDal branchDal)
		{
			_branchDal = branchDal;
		}

		public void Create(Branch entity)
		{
			_branchDal.Create(entity);
		}

		public void Delete(Branch entity)
		{
			_branchDal.Delete(entity);
		}

		public List<Branch> GetAll()
		{
			return _branchDal.GetAll().ToList();
		}

		public Branch GetById(int id)
		{
			return _branchDal.GetById(id);
		}

        public List<Branch> GetWithClassList()
        {
            return _branchDal.GetWithClassList().ToList();
        }

        public void Update(Branch entity)
		{
			_branchDal.Update(entity);
		}
	}
}
