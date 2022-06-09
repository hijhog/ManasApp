using IdentityModel.Client;
using ManasApp.Mobile.Common.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Services
{
    public class AuthService
    {
        private DateTime _expires;

        public AuthService()
        {
            _expires = DateTime.Now;
        }

        public async Task Login(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var identityServerResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = $"{AppSettings.IdentityURL}/connect/token",
                    GrantType = "password",

                    ClientId = "manasapp.client",
                    ClientSecret = "manasapp_secret_key",
                    Scope = "myApi.read",

                    UserName = username,
                    Password = password
                });

                if (!identityServerResponse.IsError)
                {
                    AccessToken = identityServerResponse.AccessToken;
                    _expires = DateTime.Now.AddSeconds(identityServerResponse.ExpiresIn);
                }
            }
        }

        public bool IsLoggedIn { get => DateTime.Now < _expires; }
        private string AccessToken { get; set; }

        public async Task<string> GetAccessToken()
        {
            if (!IsLoggedIn)
            {
                using (var httpClient = new HttpClient())
                {
                    var identityServerResponse = await httpClient.RequestDeviceTokenAsync(new DeviceTokenRequest
                    {
                        Address = $"{AppSettings.IdentityURL}/connect/token",
                        GrantType = "client_credentials",

                        ClientId = "manasapp.client",
                        ClientSecret = "manasapp_secret_key",
                    });

                    if (!identityServerResponse.IsError)
                    {
                        AccessToken = identityServerResponse.AccessToken;
                        _expires = DateTime.Now.AddSeconds(identityServerResponse.ExpiresIn);
                    }
                    else
                    {
                        AccessToken = string.Empty;
                    }
                }
            }

            return AccessToken;
        }
    }
}
