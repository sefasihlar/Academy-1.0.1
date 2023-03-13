using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IExampleService
    {
        void ekleme(string host,int mail,string Email);
        List<AppRole> appRoles();
    }
}
