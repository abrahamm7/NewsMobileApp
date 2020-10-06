using NewsAppMobile.Models;
using NewsAppMobile.NavigationLinks;
using NewsAppMobile.Services;
using NewsAppMobile.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppMobile.Views
{
    public class FeedNewsViewModel : BaseViewModel
    {      
        private readonly IApiNewsService newsService;
        public DelegateCommand GetNewsCommand { get; set; }
        public IEnumerable<Article> News { get; set; }

        public FeedNewsViewModel(PageDialogService pageDialogService, INavigationService navigationService, IApiNewsService apiNewsService) :base(pageDialogService, navigationService)
        {
            newsService = apiNewsService;
            GetNewsCommand = new DelegateCommand(async () => GetNews());
            GetNewsCommand.Execute();
        }

        async Task GetNews()
        {
            try
            {
                if (await HasInternetConnection(true))
                {
                    RestService.For<IApiNewsService>(Links.ApiUrl);
                    var request = await newsService.GetNews();
                    News = request.Articles.ToList();
                }                             
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await ShowMessage("Error","An error occured", "Ok");
            }
        }

        
    }
}
