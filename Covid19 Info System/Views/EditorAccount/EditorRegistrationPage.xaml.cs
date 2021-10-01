using Covid19_Info_System.ViewModels.UsersVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System.Views.EditorAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorRegistrationPage : ContentPage
    {
        UserViewModel userViewModel { get; set; }
        public EditorRegistrationPage()
        {
            InitializeComponent();
            MyPanel.BackgroundColor = Color.FromRgba(252, 251, 252, 0.6);
            BindingContext = userViewModel = new UserViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}