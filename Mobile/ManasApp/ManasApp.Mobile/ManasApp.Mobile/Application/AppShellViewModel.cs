
using ManasApp.Mobile.Common.Services;
using ManasApp.Mobile.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Mobile
{
    public class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel(AuthService authService)
            : base(authService)
        {

        }
    }
}
