using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public void Create(CartItem entity)
        {
            _cartItemDal.Create(entity);
        }

        public void Delete(CartItem entity)
        {
            _cartItemDal.Delete(entity);
        }

        public List<CartItem> GetAll()
        {
            return _cartItemDal.GetAll().ToList();
        }

        public CartItem GetById(int id)
        {
            return _cartItemDal.GetById(id);
        }

        public void Update(CartItem entity)
        {
            _cartItemDal.Update(entity);
        }
    }
}
