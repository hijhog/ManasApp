using ManasApp.Mobile.Common.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using ManasApp.Mobile.Common.Extensions;

namespace ManasApp.Mobile.Modules.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        public LoginViewModel(AuthService authService)
            :base(authService)
        {
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                SetProperty(ref _login, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                SetProperty(ref _password, value);
            }
        }

        private async Task LoginAsync()
        {
            var result = await _authService.Login(Login, Password);
            if (result.Success)
            {
                IsLoggedIn = true;
                UserName = Login;
                Shell.Current.ClearStackNavigation();
                await Shell.Current.GoToAsync("///main");
                _toastService.Show("Вы успешно вошли!");
            }
            else
            {
                _toastService.Show("Неверный логин или пароль");
            }
        }
    }
}
