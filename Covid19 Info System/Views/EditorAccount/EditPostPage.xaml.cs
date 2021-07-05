using Covid19_Info_System.Models;
using Covid19_Info_System.ViewModels.ArticleVM;
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
    public partial class EditPostPage : ContentPage
    {
        EditViewModel _viewModel {get;set;}
        public EditPostPage(ArticleModel articles)
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new EditViewModel();
            postTitle.Text = articles.Title;
            PostId.Text = articles.Id;
            PostIdm.Text = articles.Author;
            PostAuthorId.Text = articles.Author;
            content.Text = articles.Content;
        }

       
    }
}