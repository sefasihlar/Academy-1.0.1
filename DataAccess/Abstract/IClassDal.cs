using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IClassDal : IGenericDal<Class>
    {
        Class GetByIdWithBrances(int id);
        List<Class> GetWithBranchList();
        void Update(Class entity, int[] branchIds);
    }
}
