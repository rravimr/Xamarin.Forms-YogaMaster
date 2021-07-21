using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using YogaMaster.Core;
using YogaMaster.Shared;

namespace YogaMaster.ViewModels
{
    public class TimerExectuesViewModel : ViewModelBase
    {
        private string _timerText;

        private int _inHaleText;

        private int _holdText;

        private int _exHaleText;
        public TimerExectuesViewModel(INavigationService navigation, IAnalytics analytics, IPreferences preferences, IBrowser browser,
                             IMessagingService messagingService, IThemeService theme) : base(navigation, analytics, messagingService)
        {
            Title = "Start Timer ";

        }


        public int InHale { get; set; }

        public int ExHale { get; set; }

        public int Hold { get; set; }

        public int Minutes { get; set; }

        public string TimerText
        {
            get => _timerText;
            set => SetProperty(ref _timerText, value);
        }

        public int InHaleText
        {
            get => _inHaleText;
            set => SetProperty(ref _inHaleText, value);
        }

        public int HoldText
        {
            get => _holdText;
            set => SetProperty(ref _holdText, value);
        }

        public int ExHaleText
        {
            get => _exHaleText;
            set => SetProperty(ref _exHaleText, value);
        }

        public override async Task InitializeAsync(object parameter)
        {
            Dictionary<string, int> keyValuePairs = parameter as Dictionary<string, int>;
            if (keyValuePairs != null)
            {
                InHale = keyValuePairs[nameof(InHale)];
                ExHale = keyValuePairs[nameof(ExHale)];
                Hold = keyValuePairs[nameof(Hold)];
                Minutes = keyValuePairs[nameof(Minutes)];
            }
            await base.InitializeAsync(parameter);
            int TotalSec = 0;
            int CountSec = 0;
            bool inHaleRunning = true;
            bool holdRunning = false;
            bool exHaleRunning = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TotalSec = TotalSec + 1;
                CountSec = CountSec + 1;
                if (CountSec <= InHale && inHaleRunning)
                {
                    HoldText = 0;
                    ExHaleText = 0;
                    InHaleText = CountSec;
                    if(CountSec == InHale)
                    {
                        holdRunning = true;
                        inHaleRunning = false;
                        exHaleRunning = false;
                        CountSec = 0;
                    }
                }
                else if(CountSec <= Hold && holdRunning)
                {
                    InHaleText = 0;
                    ExHaleText = 0;
                    HoldText = CountSec;
                    if (CountSec == Hold)
                    {
                        exHaleRunning = true;
                        inHaleRunning = false;
                        holdRunning = false;
                        CountSec = 0;
                    }
                }
                else if (CountSec <= ExHale && exHaleRunning)
                {
                    InHaleText = 0;
                    HoldText = 0;
                    ExHaleText = CountSec;
                    if (CountSec == ExHale)
                    {
                        inHaleRunning = true;
                        holdRunning = false;
                        exHaleRunning = false;
                        CountSec = 0;
                    }
                }
                TimeSpan _TimeSpan = TimeSpan.FromSeconds(TotalSec);
                TimerText = string.Format("{0:00}:{1:00}", _TimeSpan.Minutes, _TimeSpan.Seconds);
                if (_TimeSpan.Minutes >= Minutes)
                {
                    return false;
                }
                return true;
            });

        }

    }
}
