
using Autofac;
using ManasApp.Mobile.Common.Controllers;
using ManasApp.Mobile.Common.Extensions;
using ManasApp.Mobile.Common.Interfaces;
using ManasApp.Mobile.Common.Services;
using ManasApp.Mobile.Data;
using ManasApp.Mobile.Modules.Localities;
using ManasApp.Mobile.Modules.Localities.LocalityDetails;
using ManasApp.Mobile.Modules.Login;
using ManasApp.Mobile.Modules.Main;
using ManasApp.Mobile.Modules.Map;
using ManasApp.Mobile.Modules.Settings;
using SQLite;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace ManasApp.Mobile
{
    public partial class App : Application
    {
        public static IContainer Container;
        public static AppDbContext Context;

        public App()
        {
            InitializeComponent();

            ConfigureApp();

            MainPage = Container.Resolve<AppShell>();
        }

        private void ConfigureApp()
        {
            RegisterRoutes();
            ConfigureContainer();

            ConfigureDatabase();
        }

        #region Database
        private void ConfigureDatabase()
        {
            if(Context == null)
            {
                var factoryDb = Container.Resolve<Func<SQLiteAsyncConnection, AppDbContext>>();
                Context = factoryDb(DependencyService.Get<IDBInterface>().CreateConnection());
            }
        }
        #endregion

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("localitydetails", typeof(LocalityDetailsPage));
            Routing.RegisterRoute("maps", typeof(MapPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("main", typeof(MainPage));
        }

        #region Container
        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterType<AppDbContext>().AsSelf().SingleInstance();

            builder.RegisterType<LocalitiesViewModel>();
            builder.RegisterType<LocalityDetailsViewModel>();
            builder.RegisterType<MapViewModel>();
            builder.RegisterType<SettingsViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<AppShell>();

            builder.RegisterType<LocalityController>()
                .As<ILocalityController>();
            builder.RegisterType<MapController>()
                .As<IMapController>();

            builder.RegisterType<AuthService>().SingleInstance();
            builder.RegisterType<DropboxService>().SingleInstance();
            builder.RegisterType<XHttpClient>();

            Container = builder.Build();
        }
        #endregion
    }
}
