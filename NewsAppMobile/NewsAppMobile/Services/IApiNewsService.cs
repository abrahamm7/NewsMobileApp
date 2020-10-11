using NewsAppMobile.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppMobile.Services
{
    public interface IApiNewsService
    {
        [Get("/newsapi.org/v2/everything")]
        Task<News> GetNews();

        [Get("/newsapi.org/v2/everything")]
        Task<News> GetSpecifiedNews(string topic);

        
    }
}
