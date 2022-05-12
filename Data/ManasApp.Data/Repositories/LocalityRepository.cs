using ManasApp.Data.Contract.Entities;
using ManasApp.Data.Contract.Repositories;

namespace ManasApp.Data.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(AppDbContext context)
            :base(context)
        {
            
        }
    }
}
