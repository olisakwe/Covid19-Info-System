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
        public CovidCountryCaseModel summary { get; private set; }

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
            GetCountries();
        }

        public async Task LoadCountrySummaryChartAsync()
        {
            var Worldentries = await _viewModel.LoadCountrySummaryChartAsync();
            var TotalCountry=await _viewModel.LoadCountrySummaryTotal();
             summary = await _viewModel.CovidSummaryAsync();
            ReportDate.Text = summary?.Date.Date.ToLongDateString();
            if (Worldentries.FirstOrDefault() == null)
            {
                ReportDate.Text = "Check Network";
               await DisplayAlert("Error", "Please Check your Network", "Okay");
            }
               
            chartView.Chart = new DonutChart() { Entries = Worldentries };
            chartViewTotalCase.Chart = new DonutChart() { Entries = TotalCountry };
            loading.IsRunning = false;

        }

        private async void SelectCourtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = sender as Picker;
            var selectedCountry = item.SelectedItem.ToString();
            ReportDate.Text = summary?.Date.Date.ToLongDateString();

            if (String.IsNullOrEmpty(summary?.ID.ToString()))
            {
                ReportDate.Text = "Check Network";
                await DisplayAlert("Error", "Please Check your Network", "Okay");
                return;
            }
            foreach (var caseItem in summary.Countries)
            {
                if (caseItem.CountryName == selectedCountry)
                {
                    var entries = new[]
                    {
                     new Entry(caseItem.NewConfirmed)
                     {
                         Label = "New Confirmed",
                         ValueLabel = caseItem.NewConfirmed.ToString(),
                         Color = SKColor.Parse("#1A153D")
                     },
                     new Entry(caseItem.NewRecovered)
                     {
                         Label = "New Recoverded",
                         ValueLabel = caseItem.NewDeaths.ToString(),
                         Color = SKColor.Parse("#00CC0E")
                     },
                     new Entry(caseItem.NewDeaths)
                     {
                         Label = "New Deaths",
                         ValueLabel =caseItem.NewDeaths.ToString(),
                         Color = SKColor.Parse("#FF0000")
                     },
                     };
                    chartView.Chart = new DonutChart() { Entries = entries };
                    //new case
                    var Totalentries = new[]
                   {
                     new Entry(caseItem.TotalConfirmed)
                     {
                         Label = "Total Confirmed",
                         ValueLabel = caseItem.TotalConfirmed.ToString(),
                         Color = SKColor.Parse("#3498db")
                     },
                     new Entry(caseItem.TotalRecovered)
                     {
                         Label = "Total Recoverded",
                         ValueLabel = caseItem.TotalRecovered.ToString(),
                         Color = SKColor.Parse("#77d065")
                     },
                     new Entry(caseItem.TotalDeaths)
                     {
                         Label = "Total Deaths",
                         ValueLabel =caseItem.TotalDeaths.ToString(),
                         Color = SKColor.Parse("#FF0000")
                     },
                     };
                    chartViewTotalCase.Chart = new DonutChart() { Entries = Totalentries };
                    loading.IsRunning = false;
                }
            }
            
            //if (Worldentries.FirstOrDefault() == null)
            //{
            //    ReportDate.Text = "Check Network";
            //    await DisplayAlert("Error", "Please Check your Network", "Okay");
            //}

        }

        private void GetCountries()
        {
            List<string> coutries = new List<string>();
            foreach (var item in summary.Countries)
            {
                coutries.Add(item.CountryName);
            }
            SelectCourtry.ItemsSource = coutries;
        }
    }
}