using Covid19_Info_System.Models;
using Covid19_Info_System.Services;
using Covid19_Info_System.ViewModels;
using Covid19_Info_System.Views.EditorAccount;
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
    public partial class LoginUserPage : ContentPage
    {
        public LoginUserPage()
        {
            InitializeComponent();
           // this.BindingContext = new LoginViewModel();
        }

        private async void LoginButton(object sender, EventArgs e)
        {
            var email = UserEmail.Text;
            var password = UserPassword.Text;

            UsersDataStore usersDataStore = new UsersDataStore();
            var users = await usersDataStore.CheckUserExist(email, password);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || users == null)
            {
                await DisplayAlert("Error", "Please check your login details", "Okey");
                return;
            }
            App.LoginUser = users;
            await Shell.Current.GoToAsync($"//{nameof(HomeTabPage)}");



        }

        private async void ClosePageButton(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new EditorRegistrationPage());
        }
    }
}
