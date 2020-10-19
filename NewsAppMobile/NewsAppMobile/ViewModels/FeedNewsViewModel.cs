using NewsAppMobile.AppResources;
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
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace NewsAppMobile.Views
{
    public class FeedNewsViewModel : BaseViewModel
    {      
        private readonly IApiNewsService newsService;
        public DelegateCommand GetNewsCommand { get; set; }
        public DelegateCommand<object> ShareNewsCommand { get; set; }
        public DelegateCommand<object> TapNews { get; set; }
        public DelegateCommand OpenMenuPop { get; set; }

        public string ParameterTopic { get; set; }
       
        public IEnumerable<Article> News { get; set; }

        public FeedNewsViewModel(PageDialogService pageDialogService, INavigationService navigationService, IApiNewsService apiNewsService) :base(pageDialogService, navigationService )
        {
            newsService = apiNewsService;

            ShareNewsCommand = new DelegateCommand<object>(ShareNews);

            TapNews = new DelegateCommand<object>(SelectNews);

            OpenMenuPop = new DelegateCommand(async () => ShowPop());

            GetNewsCommand = new DelegateCommand(async () => GetNews());
            GetNewsCommand.Execute();
        }

        public override void Initialize(INavigationParameters parameters)
        {
            
        }

        public async Task GetNews()
        {
            try
            {
                if (await HasInternetConnection(true))
                {
                    RestService.For<IApiNewsService>(Links.ApiUrl);
                    var request = await newsService.GetNews();
                    News = request.Articles.ToList();
                }
                else
                {
                    await ShowMessage("", AppResourcesFile.NoInternet, AppResourcesFile.Confirm);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await ShowMessage("", AppResourcesFile.GeneralError, AppResourcesFile.Confirm);
            }
        }        
       
        public async void ShowPop()
        {
            await NavigationService.NavigateAsync(Links.PopMenuPage);
        }

        public async void ShareNews(object obj)
        {
            var news = obj as Article;
            await Share.RequestAsync(new ShareTextRequest { Title = $"{news.Title}", Text = $"{news.Url}" });
        }

        public async void SelectNews(object obj)
        {            
            var data = obj as Article;
            await Browser.OpenAsync(data.Url);            
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            ParameterTopic = parameters.GetValue<string>("Category");
            if (ParameterTopic != null)
            {
                await GetSpecifiedNews(ParameterTopic);
            }
            
        }

        public async Task GetSpecifiedNews(string category)
        {
            try
            {
                if (await HasInternetConnection(true))
                {
                    RestService.For<IApiNewsService>(Links.ApiUrl);
                    var request = await newsService.GetSpecifiedNews(category);
                    News = request.Articles.ToList();
                }
                else
                {
                    await ShowMessage("", AppResourcesFile.NoInternet, AppResourcesFile.Confirm);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await ShowMessage("", AppResourcesFile.GeneralError, AppResourcesFile.Confirm);
            }
        }

    }
}
