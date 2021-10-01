using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19_Info_System.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportCasePage : ContentPage
    {
        public ReportCasePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            IsLoading.IsRunning = true;
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                await DisplayAlert("error", "Please check your network connectionn", "Okay");
                IsLoading.IsRunning = false;
                return;
            }
            IsLoading.IsRunning = true;
            if (string.IsNullOrEmpty(message.Text))
            {
                await DisplayAlert("error", "Report can not empty", "Okay");
                IsLoading.IsRunning = false;
                return;
            }
                
            
            Thread.Sleep(2000);
            IsLoading.IsRunning = false;
            await DisplayAlert("Sucess", "Report Sent", "Okay");
            return;
        }
    }
}