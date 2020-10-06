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
        [Get("/newsapi.org/v2/everything?apiKey=2b6d74babe00414b91370d5e0bd85b35&q=tecnology")]
        Task<News> GetNews();
    }
}
