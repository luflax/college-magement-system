using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace College_Management_System.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T GetById(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
