using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using YogaMaster.Core;

namespace YogaMaster.Shared.Services
{

    public class ThemeService : IThemeService
    {
        IPreferences preferences;
        public ThemeService(IPreferences preferences)
        {
            this.preferences = preferences;
        }

        public int Theme
        {
            get => preferences.Get(Constants.Preferences.Theme, 1);
            set => preferences.Set(Constants.Preferences.Theme, value);
        }

        public void SetTheme()
        {
            switch (Theme)
            {
                //default
                //light
                case 0:
                case 1:
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            var nav = Application.Current.MainPage as Xamarin.Forms.NavigationPage;

            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
            {
                var c = (Color)Application.Current.Resources["NavigationPrimaryDark"];
                if (nav != null)
                {
                    nav.BarBackgroundColor = c;
                    nav.BarTextColor = Color.White;
                }
            }
            else
            {
                var c = (Color)Application.Current.Resources["NavigationPrimaryLight"];
                if (nav != null)
                {
                    nav.BarBackgroundColor = c;
                    nav.BarTextColor = Color.White;
                }
            }
        }
    }
   
}
