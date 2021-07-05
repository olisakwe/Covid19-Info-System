using Covid19_Info_System.Models;
using Covid19_Info_System.Views.Articles;
using Covid19_Info_System.Views.Editor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Covid19_Info_System.ViewModels
{
   public class ArticlesViewModel:BaseViewModel
    {
        private ArticleModel _selectedItem;
        public ArticleModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public ObservableCollection<ArticleModel> Articles { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command EditItemCommand { get; }
        public bool IsAuth { get; set; }
        public Command<ArticleModel> ItemTapped { get; }
        public ArticlesViewModel()
        {
            Title = "All Articles";
            Articles = new ObservableCollection<ArticleModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            IsAuth = CheckUserAuth();
            ItemTapped = new Command<ArticleModel>(OnItemSelected);
            EditItemCommand = new Command<ArticleModel>(EditArticlePage);

            AddItemCommand = new Command(OnAddItem);
        }

        private bool CheckUserAuth()
        {
            if (App.LoginUser != null) return true;
            return false;
        }

        private async void OnItemSelected(ArticleModel Articles)
        {
            if (Articles == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.Navigation.PushModalAsync(new ArticleDetailPage(Articles));
        }
        private async void EditArticlePage(ArticleModel Articles)
        {
            if (Articles == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.Navigation.PushModalAsync(new EditPostPage(Articles));
        }
        private async void OnAddItem()
        {
             await Shell.Current.GoToAsync(nameof(AddNewPostPage));
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
                Articles.Clear();
                var items = await DataStoreArticles.GetItemsAsync(true);
                
                foreach (var item in items)
                {
                    var getAuthor = await UserStore.GetItemAsync(item.Author);
                    item.Author = getAuthor.Name;
                    Articles.Add(item);
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
