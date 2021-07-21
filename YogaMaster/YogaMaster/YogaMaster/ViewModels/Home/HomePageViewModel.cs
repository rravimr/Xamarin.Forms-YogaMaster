using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials.Interfaces;
using YogaMaster.Core;
using YogaMaster.Shared;

namespace YogaMaster.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IPreferences preferences;
        private readonly IBrowser browser;
        private readonly IThemeService theme;

        public ICommand TimerStartCommand { get; }
        public HomePageViewModel(INavigationService navigation, IAnalytics analytics, IPreferences preferences, IBrowser browser,
                             IMessagingService messagingService, IThemeService theme) : base(navigation, analytics, messagingService)
        {
            Title = "Home";
            this.preferences = preferences;
            this.browser = browser;
            this.theme = theme;
        }

        }
}
