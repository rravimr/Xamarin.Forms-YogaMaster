using System;
using System.Collections.Generic;
using Xamarin.Forms;
using YogaMaster.Core;
using YogaMaster.ViewModels;
using YogaMaster.Views;

namespace YogaMaster
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(Constants.Navigation.Paths.TimerExecutes, typeof(TimerExecutionPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
