using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFreamwork
{
    public class EfCoreClassRepository : EfCoreGenericRepository<Class, AcademyContext>, IClassDal
    {
    }
}
