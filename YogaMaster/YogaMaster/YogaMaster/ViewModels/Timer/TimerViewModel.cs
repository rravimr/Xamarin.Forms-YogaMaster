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
    public class TimerViewModel : ViewModelBase
    {
        private readonly IPreferences preferences;
        private readonly IBrowser browser;
        private readonly IThemeService theme;
        private int _inHale = 1;
        private int _exHale = 1;
        private int _hold = 1;
        private int _minutes = 1;

        public ICommand TimerStartCommand { get; }
        public TimerViewModel(INavigationService navigation, IAnalytics analytics, IPreferences preferences, IBrowser browser,
                             IMessagingService messagingService, IThemeService theme) : base(navigation, analytics, messagingService)
        {
            Title = "Timer";
            TimerStartCommand = new AsyncCommand(ExecuteTimerStartCommand);
            this.preferences = preferences;
            this.browser = browser;
            this.theme = theme;
        }

        private async Task ExecuteTimerStartCommand()
        {
            Dictionary<string, string> TimerValues = new Dictionary<string, string>
            {
                {nameof(InHale), InHale.ToString() },
                {nameof(ExHale), ExHale.ToString() },
                { nameof(Hold), Hold.ToString()},
                {nameof(Minutes), Minutes.ToString() },
            };
            await navigation.GoToAsync(Constants.Navigation.Paths.TimerExecutes, TimerValues);
        }

        public int InHale
        {
            get => _inHale;
            set => SetProperty(ref _inHale, value);
        }
        public int ExHale
        {
            get => _exHale;
            set => SetProperty(ref _exHale, value);
        }
        public int Hold
        {
            get => _hold;
            set => SetProperty(ref _hold, value);
        }
        public int Minutes
        {
            get => _minutes;
            set => SetProperty(ref _minutes, value);
        }

    }
}
