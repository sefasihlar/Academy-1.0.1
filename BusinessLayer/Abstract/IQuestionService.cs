using BusinessLayer.GenericService;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IQuestionService : IGenericService<Question>
    {
    }
}
