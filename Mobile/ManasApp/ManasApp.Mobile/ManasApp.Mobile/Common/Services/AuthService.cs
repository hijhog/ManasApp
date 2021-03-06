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
        public string UserName { get; private set; }

        public AuthService()
        {
            _expires = DateTime.Now;
        }

        public async Task<OperationResult> Login(string username, string password)
        {
            var result = new OperationResult();
            UserName = username;
            try
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
                        result.Success = true;
                    }
                    else
                    {
                        result.ErrorMessage = identityServerResponse.Error;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public bool IsLoggedIn { get => DateTime.Now < _expires; }
        private string AccessToken { get; set; }

        public async Task<string> GetAccessToken()
        {
            try
            {
                if (!IsLoggedIn)
                {
                    using (var httpClient = new HttpClient())
                    {
                        var identityServerResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                        {
                            Address = $"{AppSettings.IdentityURL}/connect/token",
                            GrantType = "password",

                            ClientId = "manasapp.client",
                            ClientSecret = "manasapp_secret_key",

                            UserName = "admin",
                            Password = "12345"
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

            }
            catch(Exception ex)
            {

            }
            

            return AccessToken;
        }
    }
}
