using Covid19_Info_System.Interfaces;
using Covid19_Info_System.Models;
using Covid19_Info_System.Services;
using Covid19_Info_System.Views;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System
{
    public partial class App : Application
    {
        public static SQLite.SQLiteAsyncConnection database;
        public static UserModel LoginUser { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new LoginUserPage();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ArticlesDataStore>();
            DependencyService.Register<UsersDataStore>();
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTableAsync<ArticleModel>();
            database.CreateTableAsync<UserModel>();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
