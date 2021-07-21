using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YogaMaster.Core.Services;
using YogaMaster.Shared;
using YogaMaster.Shared.Services;
using YogaMaster.Views;

namespace YogaMaster
{
    public partial class App : Application
    {
        private IPreferences preferences;
        private IThemeService theme;

        public App() : this(null) { }
        public App(Action<ServiceCollection> configure)
        
        {
            InitializeComponent();

            Container.Instance.ServiceProvider
              = ContainerExtension.ConfigureServices(configure);

            preferences = Container.Instance.ServiceProvider.GetRequiredService<IPreferences>();
            theme = Container.Instance.ServiceProvider.GetRequiredService<IThemeService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            theme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            theme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                theme.SetTheme();
            });
        }
    }
}
