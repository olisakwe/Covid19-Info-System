using Covid19_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System.Views.Articles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleDetailPage : ContentPage
    {
        

        public ArticleDetailPage(ArticleModel article)
        {
            InitializeComponent();
            BindingContext = article;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}