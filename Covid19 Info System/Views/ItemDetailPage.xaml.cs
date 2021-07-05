using Covid19_Info_System.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Covid19_Info_System.Views
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