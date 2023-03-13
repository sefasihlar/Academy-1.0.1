using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Example : IExampleService
    {
        public List<AppRole> appRoles()
        {
            return  new List<AppRole>();
        }

        public void ekleme()
        {
            throw new NotImplementedException();
        }

        public void ekleme(string host, int mail, string Email)
        {
            throw new NotImplementedException();
        }
    }
}

