using ManasApp.Mobile.Common.Interfaces;
using ManasApp.Mobile.Common.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly AuthService _authService;
        protected readonly IToastService _toastService;

        public BaseViewModel(AuthService authService)
        {
            _authService = authService;
            _toastService = DependencyService.Get<IToastService>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get
            {
                return _authService.IsLoggedIn;
            }
            set
            {
                _isLoggedIn = value;
                SetProperty(ref _isLoggedIn, value);
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                SetProperty(ref _userName, value);
            }
        }

        protected void SetProperty<Type>(ref Type field, Type val, [CallerMemberName] string propertyName = null)
        {
            field = val;
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
