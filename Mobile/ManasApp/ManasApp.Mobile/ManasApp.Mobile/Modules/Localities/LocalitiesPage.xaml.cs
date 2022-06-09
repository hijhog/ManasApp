using Autofac;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManasApp.Mobile.Modules.Localities
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalitiesPage : ContentPage
    {
        private readonly LocalitiesViewModel viewModel;
        
        public LocalitiesPage()
        {
            InitializeComponent();
            viewModel = App.Container.Resolve<LocalitiesViewModel>();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.InitialLocalities();
        }

        private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            await viewModel.SearchLocalities(e.NewTextValue);
        }
    }
}