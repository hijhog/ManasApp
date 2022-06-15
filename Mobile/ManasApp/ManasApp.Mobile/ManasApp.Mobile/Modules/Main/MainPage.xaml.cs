using Autofac;
using ManasApp.Mobile.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

            (sender as Button).IsEnabled = true;
        }
    }
}