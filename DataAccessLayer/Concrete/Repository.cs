using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepositoryDal<T> where T:class
    {
        Context context = new Context();
        DbSet<T> _object;
        public Repository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T p)
        {
            var entity = context.Entry(p);
            entity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            return _object.FirstOrDefault(filter);
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            var entity = context.Entry(p);
            entity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var entity = context.Entry(p);
            entity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
