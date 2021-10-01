using Covid19_Info_System.Models;
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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirm", "are you sure you want to reset", "Yes", "No");
            if (result)
            {
                await App.database.DropTableAsync<ArticleModel>();
                await App.database.DropTableAsync<UserModel>();

                await App.database.CreateTableAsync<ArticleModel>();
                await App.database.CreateTableAsync<UserModel>();
                App.Current.MainPage = new LoginUserPage();
            }
        }
    }
}