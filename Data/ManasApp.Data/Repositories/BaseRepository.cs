using ManasApp.Data.Contract.Models;
using ManasApp.Data.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ManasApp.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public async ValueTask AddAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public TEntity Get(object id)
        {
            return _table.Find(id);
        }

        public ValueTask<TEntity> GetAsync(object id)
        {
            return _table.FindAsync(id);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> predicate)
        {
            return _table.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _table;
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public PageViewModel<TEntity> GetPage(int pageIndex)
        {
            var pageVM = new PageViewModel<TEntity>
            {
                Count = _table.Count(),
                Page = pageIndex
            };

            pageVM.Data = _table.Skip(pageIndex * pageVM.PageSize).Take(pageVM.PageSize);

            return pageVM;

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
