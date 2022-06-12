using ManasApp.Mobile.Common.Extensions;
using ManasApp.Mobile.Common.Models;
using ManasApp.Mobile.Data;
using ManasApp.Mobile.Data.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Controllers
{
    public class LocalityController : ILocalityController
    {
        private readonly AppDbContext _context;
        private readonly LocalityRepository _localityRepository;
        private readonly XHttpClient _http;
        public LocalityController(AppDbContext context, XHttpClient http)
        {
            _context = context;
            _localityRepository = context.LocalityRepository;
            _http = http;
        }
        public async Task<IEnumerable<Locality>> GetLocalitiesAsync()
        {
            var list = (await _localityRepository.GetItemsAsync())
                .Select(x=>new Locality 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    MapId = !string.IsNullOrEmpty(x.MapId) ? Guid.Parse(x.MapId) : (Guid?)null
                });

            return list;
        }

        public async Task<Locality> GetLocality(Guid id)
        {
            var response = await _http.GetWithTokenAsync($"{AppSettings.WebApiURL}/api/locality/get?id={id}");
            var json = await response.Content.ReadAsStringAsync();
            var entity = JsonConvert.DeserializeObject<OperationResult<Locality>>(json);

            return entity.Result;
        }

        public async Task<IEnumerable<Locality>> GetScrollLocalitiesAsync(string searchText, int page)
        {
            var response = await _http.GetWithTokenAsync($"{AppSettings.WebApiURL}/api/locality/getsearch?searchText={searchText}&page={page}");
            var json = await response.Content.ReadAsStringAsync();
            var pageVM = JsonConvert.DeserializeObject<PageViewModel<Locality>>(json);
            return pageVM.Data.Select(x => new Locality
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MapId = x.MapId
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
