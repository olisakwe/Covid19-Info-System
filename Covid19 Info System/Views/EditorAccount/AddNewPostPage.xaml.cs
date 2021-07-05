using Covid19_Info_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System.Views.Editor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPostPage : ContentPage
    {
        AddNewPostViewModel _viewModel { get; set; }
        public AddNewPostPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AddNewPostViewModel();

            AuthorId.Text = App.LoginUser.Id;
        }
    }
}