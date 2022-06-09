using ManasApp.Mobile.Common.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly DropboxService _dropboxService;
        private readonly AuthService _authService;

        public Command DropboxGetCommand { get; set; }
        public Command LoginCommand { get; set; }
        public MainViewModel(
            DropboxService dropboxService,
            AuthService authService)
        {
            _dropboxService = dropboxService;
            _authService = authService;

            DropboxGetCommand = new Command(async () => await DropboxGet());
            LoginCommand = new Command(async () => await Login());
        }

        private async Task DropboxGet()
        {
            await _dropboxService.Authorize();

            var url = "https://www.dropbox.com/s/3wxhw0o1r8u2z1h/photo_2022-05-12_16-22-55.jpg?dl=0";

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(url);
                var json = result.Content.ReadAsStringAsync();
            }

        }

        private async Task Login()
        {
            await _authService.Login("admin", "12345");
        }
    }
}
