using Covid19_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Covid19_Info_System.ViewModels.UsersVM
{
    public class UserViewModel:BaseViewModel
    {
        private string userID;
        private string name;
        private string email;
        private string phone;
        private string password;
        private string role;

        public UserViewModel()
        {
            RegisterCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => RegisterCommand.ChangeCanExecute();
        }
        public string UserID
        {
            get => userID;
            set => SetProperty(ref userID, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string Role
        {
            get => role;
            set => SetProperty(ref role, value);
        } 


        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(phone)
                && !String.IsNullOrWhiteSpace(password);
        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnSave()
        {
            var isActive = false;
            if (!App.IsAdmin) { this.role = "a User"; }
            else { this.role = "editor"; }
            UserModel user = new UserModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = this.Name,
                Phone = this.Phone,
                Date = DateTime.Now,
                Password = this.password,
                Email = this.Email,
                IsActive = true,
                Role = this.role
            };
            
            await UserStore.AddItemAsync(user);

            // This will pop the current page off the navigation stack
            //also check the response and login user
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
