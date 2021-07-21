using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using YogaMaster.ViewModels;

namespace YogaMaster.Shared.Services
{
    public static class ContainerExtension
    {
        public static IServiceProvider ConfigureServices(Action<ServiceCollection> configure = null)
        {
            var services = new ServiceCollection();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<TimerViewModel>();
            services.AddTransient<TimerExectuesViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IConnectivity, ConnectivityImplementation>();
            services.AddSingleton<IPreferences, PreferencesImplementation>();
            services.AddSingleton<IShare, ShareImplementation>();
            services.AddSingleton<IBrowser, BrowserImplementation>();
            services.AddSingleton<IAnalytics, AppCenterAnalyticsImplementation>();
            services.AddSingleton<IMessagingService, MessagingService>();
            services.AddSingleton<IThemeService, ThemeService>();

            configure?.Invoke(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.CreateScope();

            return serviceProvider;
        }
    }
}
