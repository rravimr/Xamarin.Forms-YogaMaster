using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class SettingsPage : PageBase<SettingsViewModel>
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}