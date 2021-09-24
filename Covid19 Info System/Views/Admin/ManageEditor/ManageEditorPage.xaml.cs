using Covid19_Info_System.Models;
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
    public partial class ManageEditorPage : ContentPage
    {
        private UserModel currentUser;

        public ManageEditorPage(UserModel user)
        {
            InitializeComponent();
            currentUser = user;
            Name.Text = user.Name;
            Email.Text = user.Email;
            Phone.Text = user.Phone;
            Password.Text = user.Password;
            Date.Text = user.Date.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var name = Name.Text;var phone = Name.Text; var password = Password.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) 
                || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Please Fill all Field", "Okay");
                return;
            }
            currentUser.Name = name;
            currentUser.Phone = phone;
            currentUser.Password = password;
            App.database.UpdateAsync(currentUser);
            DisplayAlert("Success", "User Update was Successfull", "Okay");
            App.Current.MainPage.Navigation.PopAsync();
            return;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            currentUser.IsActive = false;
            App.database.UpdateAsync(currentUser);
            DisplayAlert("Success", "User De-activated", "Okay");
            App.Current.MainPage.Navigation.PopAsync();
            return;
        }
    }
}