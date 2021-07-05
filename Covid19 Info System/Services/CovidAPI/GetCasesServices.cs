using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using Covid19_Info_System.Models;
using Newtonsoft.Json;
using Covid19_Info_System.Helper;

namespace Covid19_Info_System.Services.CovidAPI
{
    class GetCasesServices
    {
        
        HttpClient client { get; set; }
        public GetCasesServices()
        {
            client = new HttpClient();
            
        }

        public async Task<CovidCountryCaseModel> GetCovidSummaryAsync()
        {
             CovidCountryCaseModel repositories=new CovidCountryCaseModel();
           
            try
            {
                HttpResponseMessage response = await client.GetAsync(APIs.CovidAPISummary);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<CovidCountryCaseModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return repositories;
        }
    }
}
