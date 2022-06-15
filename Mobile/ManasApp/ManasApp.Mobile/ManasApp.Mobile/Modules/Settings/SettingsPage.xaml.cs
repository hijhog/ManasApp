using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManasApp.Mobile.Modules.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            var viewModel = App.Container.Resolve<SettingsViewModel>();
            BindingContext = viewModel;
        }
    }
}