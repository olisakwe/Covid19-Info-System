using Covid19_Info_System.ViewModels;
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
    public partial class ArticlesPage : ContentPage
    {
        ArticlesViewModel _viewModel;
        public ArticlesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ArticlesViewModel();
        }
        protected override void OnAppearing()
        {
            BindingContext = _viewModel = new ArticlesViewModel();
            base.OnAppearing();
            if (App.LoginUser != null && App.LoginUser.Role != "a User")
            {
                AddButton.IsVisible = true;
                


            } 
            else AddButton.IsVisible = false;

            this.Title = _viewModel.Title;
            _viewModel.OnAppearing();
        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        //public override void OnAppearingAsync()
        //{
        //    base.OnAppearing();

        //}
    }
}