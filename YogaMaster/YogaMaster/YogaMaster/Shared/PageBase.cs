using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using YogaMaster.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using YogaMaster.Core;

namespace YogaMaster.Shared
{
    public class PageBase : ContentPage { }

    public class PageBase<TViewModel> : PageBase
    {
        private IAnalytics analytics;
        public TViewModel ViewModel { get; set; }
        public PageBase()
        {
            BindingContext = ViewModel = Container.Instance.ServiceProvider.GetRequiredService<TViewModel>();
            analytics = Container.Instance.ServiceProvider.GetRequiredService<IAnalytics>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            analytics.TrackEvent(Constants.Analytics.Events.PageOpened,
                new Dictionary<string, string>
                {
                    { Constants.Analytics.Properties.PageName, this.GetType().Name }
                });



        }
    }
 }
