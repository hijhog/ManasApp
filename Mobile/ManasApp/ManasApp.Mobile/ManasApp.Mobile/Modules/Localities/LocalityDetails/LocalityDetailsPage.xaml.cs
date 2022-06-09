using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManasApp.Mobile.Modules.Localities.LocalityDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalityDetailsPage : ContentPage
    {
        private LocalityDetailsViewModel viewModel;
        public LocalityDetailsPage()
        {
            InitializeComponent();
            viewModel = App.Container.Resolve<LocalityDetailsViewModel>();
            BindingContext = viewModel;
        }
    }
}