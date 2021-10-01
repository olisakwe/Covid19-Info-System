using Covid19_Info_System.Models;
using Covid19_Info_System.Views.Admin.ManageEditor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Covid19_Info_System.ViewModels.UsersVM
{
    public class AllUsersViewModel:BaseViewModel
    {
        public ObservableCollection<UserModel> Users { get; }
        public Command LoadItemsCommand { get; }
        public Command<UserModel> ItemTapped { get; }

        private UserModel _selectedItem;
        public UserModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public AllUsersViewModel()
        {
            Title = "All Users";
            Users = new ObservableCollection<UserModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<UserModel>(OnItemSelected);
          //  EditItemCommand = new Command<UserModel>(EditArticlePage);

            //AddItemCommand = new Command(OnAddItem);
        }

        private async void OnItemSelected(UserModel user)
        {
            if (user == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await App.Current.MainPage.Navigation.PushModalAsync(new ManageEditorPage(user));
        }
        
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var items = await UserStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Users.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
