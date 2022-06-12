using ManasApp.Mobile.Common.Extensions;
using ManasApp.Mobile.Common.Models;
using ManasApp.Mobile.Data;
using ManasApp.Mobile.Data.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Controllers
{
    public class MapController : IMapController
    {
        private readonly MapRepository _mapRepository;
        private readonly XHttpClient _http;
        public MapController(AppDbContext context, XHttpClient xHttpClient)
        {
            _mapRepository = context.MapRepository;
            _http = xHttpClient;
        }

        public async Task<Map> GetAsync(Guid id)
        {
            var response = await _http.GetWithTokenAsync($"{AppSettings.WebApiURL}/api/map/get?id={id}");
            var json = await response.Content.ReadAsStringAsync();
            var operationResult = JsonConvert.DeserializeObject<OperationResult<Map>>(json);

            return operationResult.Result;
        }
    }

    public interface IMapController
    {
        Task<Map> GetAsync(Guid id);
    }
}
