using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EfCoreGenericRepository<T, TContext> : IGenericDal<T>
        where T : class
        where TContext : DbContext,new()
    {
        public virtual void Create(T entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using(var _context = new TContext())
            {
                return filter == null
                    ? _context.Set<T>().ToList()
                    : _context.Set<T>().Where(filter);

            }
        }

        public virtual T GetById(int id)
        {
            using (var _context = new TContext())
            {
                return _context.Set<T>().Find(id);
            }

        }

        public virtual T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var _context = new TContext())
            {
                return _context.Set<T>().Where(filter).SingleOrDefault();
            }
        }

        public  virtual void  Update(T entity)
        {
            using (var _context = new TContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
