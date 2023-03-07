﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCoreRepository
{
	public class EfCoreAppRoleRepository : EfCoreGenericRepository<AppRole, AcademyContext>, IAppRoleDal
	{
	   
	}
}
