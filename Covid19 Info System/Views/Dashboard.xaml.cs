using Covid19_Info_System.Models;
using Covid19_Info_System.ViewModels;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace Covid19_Info_System.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        Covid19CaseModel cases { get; set; }
        DashboardViewModel _viewModel;

        public Dashboard()
        {
            
            InitializeComponent();
            BindingContext = _viewModel = new DashboardViewModel();
            Init();
          //  



        }
        
        public async void  Init()
        {
            await LoadCountrySummaryChartAsync();
        }

        public async Task LoadCountrySummaryChartAsync()
        {
            var Worldentries = await _viewModel.LoadCountrySummaryChartAsync();
            var summary = await _viewModel.CovidSummaryAsync();
            ReportDate.Text = summary?.Date.Date.ToLongDateString();
            if (Worldentries.FirstOrDefault() == null)
            {
                ReportDate.Text = "Check Network";
               await DisplayAlert("Error", "Please Check your Network", "Okay");
            }
               
            chartView.Chart = new DonutChart() { Entries = Worldentries };
            chartViewTotalCase.Chart = new DonutChart() { Entries = Worldentries};
            loading.IsRunning = false;

        }
    }
}