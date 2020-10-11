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
        public bool WelcomeMessage { get; set; }
        public DelegateCommand GetNewsCommand { get; set; }
        public DelegateCommand<object> ShareNewsCommand { get; set; }
        public DelegateCommand OpenMenuPop { get; set; }
        public DelegateCommand<string> GetNewsTyped { get; set; }
        public IEnumerable<Article> News { get; set; }

        public FeedNewsViewModel(PageDialogService pageDialogService, INavigationService navigationService, IApiNewsService apiNewsService) :base(pageDialogService, navigationService)
        {
            newsService = apiNewsService;

            ShareNewsCommand = new DelegateCommand<object>(ShareNews);

            OpenMenuPop = new DelegateCommand(async () => ShowPop());

            GetNewsTyped = new DelegateCommand<string>(SearchNews);

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

        async void SearchNews(string text)
        {
            if (text.Length >= 1)
            {
                var suggestions = News.Where(elem => elem.Title == text || elem.Author == text || elem.Description == text).ToList();

                var newlist = News.ToList();

                newlist.Clear();

                News = suggestions;
            }
        }
       
        async void ShowPop()
        {
            await NavigationService.NavigateAsync(Links.PopMenuPage);
        }

        async void ShareNews(object obj)
        {
            var news = obj as Article;
            await Share.RequestAsync(new ShareTextRequest { Title = $"{news.Title}", Text = $"{news.Url}" });
        }


    }
}
