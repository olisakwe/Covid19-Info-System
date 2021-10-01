using Covid19_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Covid19_Info_System.ViewModels
{
    public class AddNewPostViewModel:BaseViewModel
    {
        private string title;
        private string content;
        private string author;
        public AddNewPostViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public string ArticleTitle
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(author)
                && !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(content);
        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ArticleModel newItem = new ArticleModel()
            {
                Id = Guid.NewGuid().ToString(),
                Author = Author,
                Content = Content,
                Date = DateTime.Now,
                Title=ArticleTitle,
                isActive=true
            };

                await DataStoreArticles.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
