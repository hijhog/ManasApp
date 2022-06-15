using ManasApp.Data.Contract.Entities;
using System;
using System.Threading.Tasks;

namespace ManasApp.Data.Contract.Repositories
{
    public interface ILocalityRepository : IBaseRepository<Locality>
    {
        Task<Locality> GetWithDataStorageById(Guid id);
    }
}
