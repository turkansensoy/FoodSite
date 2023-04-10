using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<T> 
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T Get(Expression<Func<T,bool>> filter);

    }
}
