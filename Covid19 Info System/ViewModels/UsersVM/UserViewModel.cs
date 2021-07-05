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
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            UserModel user = new UserModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = this.Name,
                Phone = this.Phone,
                Date = DateTime.Now,
                Password= this.password,
                Email = this.Email,
                IsActive = false,
                IsAdmin = false
            };
            
            await UserStore.AddItemAsync(user);

            // This will pop the current page off the navigation stack
            //also check the response and login user
            await Shell.Current.GoToAsync("..");
        }
    }
}
