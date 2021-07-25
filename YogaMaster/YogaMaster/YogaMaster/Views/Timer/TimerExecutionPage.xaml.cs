using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YogaMaster.Shared;
using YogaMaster.ViewModels;

namespace YogaMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(InHale), nameof(InHale))]
    [QueryProperty(nameof(ExHale), nameof(ExHale))]
    [QueryProperty(nameof(Hold), nameof(Hold))]
    [QueryProperty(nameof(Minutes), nameof(Minutes))]
    public partial class TimerExecutionPage : PageBase<TimerExectuesViewModel>
    {

        public string InHale { get; set; }
        public string ExHale { get; set; }

        public string Hold { get; set; }

        public string Minutes { get; set; }

        public TimerExecutionPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Dictionary<string, int> TimerValues = new Dictionary<string, int>
            {
                {nameof(InHale), Convert.ToInt32(InHale) },
                {nameof(ExHale), Convert.ToInt32(ExHale) },
                { nameof(Hold), Convert.ToInt32(Hold)},
                {nameof(Minutes), Convert.ToInt32(Minutes) },
            };
            await ViewModel.InitializeAsync(TimerValues);
        }
        protected override async void OnDisappearing()
        {
            await ViewModel.ExecuteTimerStopCommand();
            base.OnDisappearing();
        }

    }
}