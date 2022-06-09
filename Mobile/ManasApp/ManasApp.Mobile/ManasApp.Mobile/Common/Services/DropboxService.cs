using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ManasApp.Mobile.Common.Services
{
    public class DropboxService
    {
        private const string AppKeyDropboxtoken = "Dropbox_token";
        private const string ClientId = "i77cohaj1n7xueg";
        private const string RedirectUri = "https://www.anysite.se/";

        public Action OnAuthenticated;
        private string oauth2State;

        private string AccessToken { get; set; }

        public async Task Authorize()
        {
            if (string.IsNullOrWhiteSpace(this.AccessToken) == false)
            {
                // Already authorized
                this.OnAuthenticated?.Invoke();
                return;
            }

            if (this.GetAccessTokenFromSettings())
            {
                // Found token and set AccessToken 
                return;
            }

            // Run Dropbox authentication
            this.oauth2State = Guid.NewGuid().ToString("N");
            var authorizeUri = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, ClientId, new Uri(RedirectUri), this.oauth2State);
            var webView = new WebView { Source = new UrlWebViewSource { Url = authorizeUri.AbsoluteUri } };
            webView.Navigating += this.WebViewOnNavigating;
            var contentPage = new ContentPage { Content = webView };
            await Application.Current.MainPage.Navigation.PushModalAsync(contentPage);
        }

        private bool GetAccessTokenFromSettings()
        {
            try
            {
                if (!Application.Current.Properties.ContainsKey(AppKeyDropboxtoken))
                {
                    return false;
                }

                this.AccessToken = Application.Current.Properties[AppKeyDropboxtoken]?.ToString();
                if (this.AccessToken != null)
                {
                    this.OnAuthenticated.Invoke();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static async Task SaveDropboxToken(string token)
        {
            if (token == null)
            {
                return;
            }

            try
            {
                Application.Current.Properties.Add(AppKeyDropboxtoken, token);
                await Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                
            }
        }

        private async void WebViewOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            if (!e.Url.StartsWith(RedirectUri, StringComparison.OrdinalIgnoreCase))
            {
                // we need to ignore all navigation that isn't to the redirect uri.
                return;
            }

            try
            {
                var result = DropboxOAuth2Helper.ParseTokenFragment(new Uri(e.Url));

                if (result.State != this.oauth2State)
                {
                    return;
                }

                this.AccessToken = result.AccessToken;

                await SaveDropboxToken(this.AccessToken);
                this.OnAuthenticated?.Invoke();
            }
            catch (ArgumentException)
            {
                // There was an error in the URI passed to ParseTokenFragment
            }
            finally
            {
                e.Cancel = true;
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}
