using ManasApp.Data.Contract.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ManasApp.Data.Contract.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        ValueTask AddAsync(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(object id);
        ValueTask<TEntity> GetAsync(object id);
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> predicate);
        IQueryable<TEntity> GetAll();
        void Delete(TEntity entity);

        PageViewModel<TEntity> GetPage(int pageIndex);

        Task SaveChangesAsync();
    }
}
