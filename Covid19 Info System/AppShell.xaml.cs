using Covid19_Info_System.ViewModels;
using Covid19_Info_System.Views;
using Covid19_Info_System.Views.Articles;
using Covid19_Info_System.Views.Editor;
using Covid19_Info_System.Views.EditorAccount;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Covid19_Info_System
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ArticlesPage), typeof(ArticlesPage));
            Routing.RegisterRoute(nameof(ArticleDetailPage), typeof(ArticleDetailPage));
            Routing.RegisterRoute(nameof(AddNewPostPage), typeof(AddNewPostPage));
            Routing.RegisterRoute(nameof(EditPostPage), typeof(EditPostPage));
            Routing.RegisterRoute(nameof(EditorRegistrationPage), typeof(EditorRegistrationPage));
            Routing.RegisterRoute(nameof(LoginUserPage), typeof(LoginUserPage));
            //Routing.RegisterRoute(nameof(HomeTabPage), typeof(HomeTabPage));
            
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomeTabPage");
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            if (App.LoginUser == null)
            {
               
                BrowseMenu.FlyoutItemIsVisible = false;
                ArticlesAbout.FlyoutItemIsVisible = false;
                LogoutMenu.FlyoutItemIsVisible = false;
            }
            else 
                { LoginMenu.FlyoutItemIsVisible = false;
                BrowseMenu.FlyoutItemIsVisible = true;
                ArticlesAbout.FlyoutItemIsVisible = true;
                LogoutMenu.FlyoutItemIsVisible = true;
            }
      
           
        }
    }
}
