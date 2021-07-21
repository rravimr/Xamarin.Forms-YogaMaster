using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YogaMaster.Shared
{

    public class ViewModelBase : BaseViewModel
    {

        public ICommand CloseViewCommand { get; set; }

        protected INavigationService navigation;
        protected IAnalytics analytics;
        protected IMessagingService messagingService;

        public ViewModelBase(INavigationService navigation, IAnalytics analytics, IMessagingService messagingService)
        {
            CloseViewCommand = new AsyncCommand(ExecuteCloseViewCommand);
            this.navigation = navigation;
            this.analytics = analytics;
            this.messagingService = messagingService;
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(0);
        }

        private async Task ExecuteCloseViewCommand()
        {
            await navigation.GoBackAsync();
        }
    }
}
