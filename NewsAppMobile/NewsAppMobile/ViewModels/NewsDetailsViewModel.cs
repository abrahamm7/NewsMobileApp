using NewsAPI.Models;
using NewsAppMobile.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppMobile.ViewModels
{
    public class NewsDetailsViewModel: BaseViewModel
    {
        
        public Article Article { get; set; } = new Article();

        public string Title { get; set; }

        public NewsDetailsViewModel(PageDialogService pageDialogService, INavigationService navigationService, IApiNewsService apiNewsService) : base(pageDialogService, navigationService)
        {

        }

        public override void Initialize(INavigationParameters parameters)
        {           

        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                Article.Title = parameters.GetValue<string>("DataTitle");
                SetTitle(Article.Title);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
        }

        public async Task SetTitle(string news)
        {
            Title = news;
        }
    }
}
