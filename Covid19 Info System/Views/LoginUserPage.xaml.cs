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
            MyPanel.BackgroundColor = Color.FromRgba(252, 251, 252, 0.6);
           // this.BindingContext = new LoginViewModel();
        }

        private async void LoginButton(object sender, EventArgs e)
        {
            App.LoginUser = null;
            App.IsAdmin = false;
            loading.IsRunning = true;
            var email = UserEmail.Text;
            var password = UserPassword.Text;
            if(email=="admin" && password=="123456789")
            {
                App.IsAdmin = true;
                App.Current.MainPage = new AdminTabbedPage();
                loading.IsRunning = false;return;
            }

            UsersDataStore usersDataStore = new UsersDataStore();
            var users = await usersDataStore.CheckUserExist(email, password);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || users == null || !users.IsActive)
            {
               
                await DisplayAlert("Error", "Please check your login details ", "Okey");
                loading.IsRunning = false;
                return;
            }
            App.LoginUser = users;
            if(App.LoginUser.Role== "a User")
                 App.Current.MainPage = new UserTabbedPage();
            else App.Current.MainPage = new HomeTabPage();
            loading.IsRunning = false; return;
        }

        private async void ClosePageButton(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditorRegistrationPage());
        }
    }
}
