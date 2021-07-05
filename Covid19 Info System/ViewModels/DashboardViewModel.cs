using Covid19_Info_System.Models;
using Covid19_Info_System.Services.CovidAPI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Entry = Microcharts.ChartEntry;

namespace Covid19_Info_System.ViewModels
{
    class DashboardViewModel
    {
        GetCasesServices Covidcases { get; set; }

        CovidCountryCaseModel summary { get; set; }
       
        public  DashboardViewModel()
        {
            Covidcases = new GetCasesServices();
        }

        public async Task<CovidCountryCaseModel> CovidSummaryAsync()
        {
             
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
               return summary = await Covidcases.GetCovidSummaryAsync();
            }
             return summary = null;
        }

        public async Task<Entry[]> LoadCountrySummaryChartAsync()
        {
            var summary = await CovidSummaryAsync();
            if (String.IsNullOrEmpty(summary?.ID.ToString()))
                    return new Entry[0];
                var entries = new[]
                 {
                     new Entry(summary.Global.NewConfirmed)
                     {
                         Label = "New Confirmed",
                         ValueLabel = summary.Global.NewConfirmed.ToString(),
                         Color = SKColor.Parse("#3498db")
                     },
                     new Entry(summary.Global.NewRecovered)
                     {
                         Label = "New Recoverded",
                         ValueLabel = summary.Global.NewRecovered.ToString(),
                         Color = SKColor.Parse("#77d065")
                     },
                     new Entry(summary.Global.NewDeaths)
                     {
                         Label = "New Deaths",
                         ValueLabel =summary.Global.NewDeaths.ToString(),
                         Color = SKColor.Parse("#9C0000")
                     },
                     };
            return entries;
        }

        public void OnAppearing()
        {
            //IsBusy = true;
            //SelectedItem = null;
        }
    }
}
