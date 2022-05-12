
using Autofac;
using ManasApp.Mobile.Modules.Localities;
using System.Reflection;
using Xamarin.Forms;

namespace ManasApp.Mobile
{
    public partial class App : Application
    {
        public static IContainer Container;

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterType<LocalitiesViewModel>();

            Container = builder.Build();


            MainPage = new AppShell();
        }
    }
}
