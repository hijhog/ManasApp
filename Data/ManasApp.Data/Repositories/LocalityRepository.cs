using ManasApp.Data.Contract.Entities;
using ManasApp.Data.Contract.Repositories;
using System;
using System.Threading.Tasks;

namespace ManasApp.Data.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(AppDbContext context)
            :base(context)
        {
            
        }

        public async Task<Locality> GetWithDataStorageById(Guid id)
        {
            var entity = await _context.Localities.FindAsync(id);
            if(entity != null)
                _context.Entry(entity).Collection(x => x.StorageData).Load();
            return entity;
        }
    }
}
