using BusinessLayer.GenericService;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IClassService : IGenericService<Class>
    {
        List<Class> GetWithBranchList();

        ClassBranch GetByIdWithBrances(int id);

        void Update(Class entity, int[] branchIds);
    }
}
