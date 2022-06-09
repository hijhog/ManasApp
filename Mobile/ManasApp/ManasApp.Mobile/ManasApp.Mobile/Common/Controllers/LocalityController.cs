using ManasApp.Mobile.Common.Extensions;
using ManasApp.Mobile.Common.Models;
using ManasApp.Mobile.Data;
using ManasApp.Mobile.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Controllers
{
    public class LocalityController : ILocalityController
    {
        private readonly AppDbContext _context;
        private readonly LocalityRepository _localityRepository;
        public LocalityController(AppDbContext context)
        {
            _context = context;
            _localityRepository = context.LocalityRepository;
        }
        public async Task<IEnumerable<Locality>> GetLocalitiesAsync()
        {
            var list = (await _localityRepository.GetItemsAsync())
                .Select(x=>new Locality 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.Description.GetShortText(),
                    MapId = !string.IsNullOrEmpty(x.MapId) ? Guid.Parse(x.MapId) : (Guid?)null
                });

            return list;
        }

        public async Task<Locality> GetLocality(Guid id)
        {
            var entity = await _localityRepository.GetItemAsync(id);
            if(entity != null)
            {
                return new Locality
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    MapId = !string.IsNullOrEmpty(entity.MapId) ? Guid.Parse(entity.MapId) : (Guid?)null
                };
            }

            return null;
        }

        public async Task<IEnumerable<Locality>> GetScrollLocalitiesAsync(string searchText, int page)
        {
            var entities = await _localityRepository.GetNextItemsAsync(searchText, page);
            return entities.Select(x => new Locality
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MapId = !string.IsNullOrEmpty(x.MapId) ? Guid.Parse(x.MapId) : (Guid?)null
            });
        }
    }

    public interface ILocalityController
    {
        Task<IEnumerable<Locality>> GetLocalitiesAsync();
        Task<IEnumerable<Locality>> GetScrollLocalitiesAsync(string searchText, int page);
        Task<Locality> GetLocality(Guid id);
    }
}
