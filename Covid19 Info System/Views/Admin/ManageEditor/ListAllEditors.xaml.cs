using Covid19_Info_System.ViewModels.UsersVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System.Views.Admin.ManageEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAllEditors : ContentPage
    {
        private AllUsersViewModel _viewModel;

        AllUsersViewModel _viewModle { get; set; }
        public ListAllEditors()
        {
            InitializeComponent();
            BindingContext = _viewModle = new AllUsersViewModel();
        }

        protected override void OnAppearing()
        {
            BindingContext = _viewModel = new AllUsersViewModel();
            base.OnAppearing();
            //if (App.LoginUser != null)
            //{
            //    AddButton.IsVisible = true;

            //}
            //else AddButton.IsVisible = false;

            //this.Title = _viewModel.Title;
            _viewModel.OnAppearing();
        }
    }
}