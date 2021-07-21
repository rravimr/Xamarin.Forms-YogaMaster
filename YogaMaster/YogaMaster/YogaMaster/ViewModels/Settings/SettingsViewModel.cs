﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials.Interfaces;
using YogaMaster.Core;
using YogaMaster.Shared;

namespace YogaMaster.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IPreferences preferences;
        private readonly IBrowser browser;
        private readonly IThemeService theme;
        public SettingsViewModel(INavigationService navigation, IAnalytics analytics, IPreferences preferences, IBrowser browser,
                             IMessagingService messagingService, IThemeService theme) : base(navigation, analytics, messagingService)
        {
            Title = "Settings";
            this.preferences = preferences;
            this.browser = browser;
            this.theme = theme;
        }

        public int Theme
        {
            get => preferences.Get(Constants.Preferences.Theme, 0);
            set
            {
                preferences.Set(Constants.Preferences.Theme, value);
                theme.SetTheme();
            }
        }

        public bool UseSystem
        {
            get => Theme == 0;
            set
            {
                if (!value)
                    return;
                Theme = 0;
            }
        }

        public bool UseLight
        {
            get => Theme == 1;
            set
            {
                if (!value)
                    return;
                Theme = 1;
            }
        }

        public bool UseDark
        {
            get => Theme == 2;
            set
            {
                if (!value)
                    return;
                Theme = 2;
            }
        }

        public bool Analytics
        {
            get => preferences.Get(Constants.Preferences.Analytics, true);
            set
            {
                _ = analytics.SetEnabledAsync(value);
                preferences.Set(Constants.Preferences.Analytics, value);
            }
        }

    }
}
