using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Create(Cart entity)
        {
            _cartDal.Create(entity);
        }

        public void Delete(Cart entity)
        {
            _cartDal.Delete(entity);
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetAll().ToList();
        }

        public Cart GetById(int id)
        {
            return _cartDal.GetById(id);
        }

        public void Update(Cart entity)
        {
            _cartDal.Update(entity);
        }
    }
}
