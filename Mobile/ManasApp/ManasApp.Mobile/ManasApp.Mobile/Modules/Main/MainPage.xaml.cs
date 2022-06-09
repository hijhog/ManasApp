using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManasApp.Mobile.Modules.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = App.Container.Resolve<MainViewModel>();

            BindingContext = viewModel;
        }
    }
}