using NewsAppMobile.Models;
using NewsAppMobile.NavigationLinks;
using NewsAppMobile.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppMobile.Services
{
    public class ApiNewsService : IApiNewsService 
    {
        public async Task<News> GetNews()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(Links.NewsUrl);
                return JsonConvert.DeserializeObject<News>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }

        public async Task<News> GetSpecifiedNews(string topic)
        {
            Links links = new Links(topic);
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(links.SpecifiedNews);
                return JsonConvert.DeserializeObject<News>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }
    }
}
