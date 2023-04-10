using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories
{
    public class EFRepositoryBase<TEntity,TContext> : IRepository<TEntity>
        where TEntity : class,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;     //ekle
                context.SaveChanges(); 
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context= new())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context= new())
            {
               return  context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context= new())
            {
                context.Entry(entity).State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
