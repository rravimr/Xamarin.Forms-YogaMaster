using System.ComponentModel;
using Xamarin.Forms;
using YogaMaster.ViewModels;

namespace YogaMaster.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}