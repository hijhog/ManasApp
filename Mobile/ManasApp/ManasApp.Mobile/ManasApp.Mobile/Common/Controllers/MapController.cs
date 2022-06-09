using ManasApp.Mobile.Common.Models;
using ManasApp.Mobile.Data;
using ManasApp.Mobile.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Controllers
{
    public class MapController : IMapController
    {
        private readonly MapRepository _mapRepository;
        public MapController(AppDbContext context)
        {
            _mapRepository = context.MapRepository;
        }

        public async Task<Map> GetAsync(Guid id)
        {
            var entity = await _mapRepository.GetItemAsync(id);
            if(entity != null)
            {
                return new Map
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                };
            }

            return null;
        }
    }

    public interface IMapController
    {
        Task<Map> GetAsync(Guid id);
    }
}
