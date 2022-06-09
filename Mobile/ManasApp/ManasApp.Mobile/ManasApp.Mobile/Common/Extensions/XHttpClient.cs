using ManasApp.Mobile.Common.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Extensions
{
    public class XHttpClient
    {
        private readonly AuthService _authService;

        public XHttpClient(AuthService authService)
        {
            _authService = authService;
        }

        public async Task<HttpResponseMessage> GetWithTokenAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", await _authService.GetAccessToken());
                return await httpClient.GetAsync(url);
            }
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return httpClient.GetAsync(url);
            }
        }

        public async Task<HttpResponseMessage> PostWithTokenAsync<TObj>(string url, TObj obj)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await _authService.GetAccessToken());
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return await httpClient.PostAsync(url, content);
            }
        }

        public Task<HttpResponseMessage> PostAsync<TObj>(string url, TObj obj)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return httpClient.PostAsync(url, content);
            }
        }
    }
}
