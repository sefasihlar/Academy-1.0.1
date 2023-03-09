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
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _userDal;

		public AppUserManager(IAppUserDal userDal)
		{
			_userDal = userDal;
		}

		public void Create(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> GetAll()
		{
			return _userDal.GetAll().ToList();
		}

		public AppUser GetById(int id)
		{
			return _userDal.GetById(id);
		}

		public List<AppUser> ListTogether()
		{
			return _userDal.ListTogether().ToList();
		}

		public void Update(AppUser entity)
		{
			throw new NotImplementedException();
		}
	}
}
