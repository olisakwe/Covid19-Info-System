using Covid19_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Covid19_Info_System.ViewModels.ArticleVM
{
    public class EditViewModel : BaseViewModel
    {
        private string title;
        private string content;
        private string author;
        private string postid;
        public EditViewModel()
        {
            SaveCommand = new Command(OnUpdate, ValidateSave);
            DeleteCommand = new Command(OnDelete, ()=> !String.IsNullOrWhiteSpace(postid)) ;

            //CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            this.PropertyChanged +=
                (_, __) => DeleteCommand.ChangeCanExecute();
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
        public string PostId
        {
            get => postid;
            set => SetProperty(ref postid, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(author)
                && !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(content)
                && !String.IsNullOrWhiteSpace(postid);
        }

        private async void OnUpdate()
        {
            var getArticle = await DataStoreArticles.GetItemAsync(postid);
            getArticle.Author = Author;
            getArticle.Content = content;
            getArticle.Title = ArticleTitle;
            getArticle.Date = DateTime.Now;

            await DataStoreArticles.UpdateItemAsync(getArticle);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {

            await DataStoreArticles.DeleteItemAsync(PostId);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
