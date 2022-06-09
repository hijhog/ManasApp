using ManasApp.Mobile.Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Data.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly SQLiteAsyncConnection _database;
        protected readonly AsyncTableQuery<TEntity> _table;
        public BaseRepository(SQLiteAsyncConnection database)
        {
            _database = database;
            _table = database.Table<TEntity>();
        }

        public Task<List<TEntity>> GetItemsAsync()
        {
            return _table.ToListAsync();
        }
        public Task<TEntity> GetItemAsync(Guid id)
        {
            return _database.GetAsync<TEntity>(id);
        }
        public Task<int> DeleteItemAsync(Guid id)
        {
            return _database.DeleteAsync<TEntity>(id);
        }
        public Task<int> SaveItemAsync(TEntity item)
        {
            if (item.Id != Guid.Empty)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public async Task<List<TEntity>> GetNextItemsAsync(string searchText, int page, int pageSize = 15)
        {
            var all = await _table.ToListAsync();
            if (!string.IsNullOrEmpty(searchText))
            {
                return all.Where(x => x.Name.Contains(searchText.ToUpper()))
                             .Skip((page - 1) * pageSize)
                                    .Take(pageSize).ToList();
            }

            return all.Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
        }
    }
}
