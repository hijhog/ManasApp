using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManasApp.Mobile.Modules.Map
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly MapViewModel viewModel;
        public MapPage()
        {
            InitializeComponent();

            viewModel = App.Container.Resolve<MapViewModel>();
            viewModel.Map = myMap;
            BindingContext = viewModel;
        }
    }
}