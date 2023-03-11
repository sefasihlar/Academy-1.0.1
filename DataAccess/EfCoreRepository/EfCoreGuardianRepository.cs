using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EfCoreRepository
{
    public class EfCoreGuardianRepository : EfCoreGenericRepository<Guardian, AcademyContext>, IGuardianDal
    {

    }
}
