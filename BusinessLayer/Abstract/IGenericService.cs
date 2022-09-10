using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        void Add(T entity);
        T GetById(int id);
        void Delete(T entity);
        void Update(T entity);
    }
}
