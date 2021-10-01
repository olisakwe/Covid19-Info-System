using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminTabbedPage : TabbedPage
    {
        public AdminTabbedPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            this.logout();
            //  base.OnBackButtonPressed();
            return true;
        }
        async void logout()
        {
            var response = await DisplayAlert("info", "do you want to logout?", "Yes", "No");
            if (response)
            {
                App.Current.MainPage = new LoginUserPage();
                return;
            }
        }
    }
}