using ManasApp.Mobile.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }
        public SettingsViewModel(AuthService authService)
            :base(authService)
        {
            LoginCommand = new Command(async () => await GotoLogin()); 
        }

        private async Task GotoLogin()
        {
            await Shell.Current.GoToAsync("login");
        }
    }
}
