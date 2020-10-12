using NewsAppMobile.Models;
using NewsAppMobile.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppMobile.ViewModels
{
    public class PopMenuViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public List<string> Categories { get; set; }
        
        public DelegateCommand FillListCommand { get; set; }
        public DelegateCommand<string> TapTopic { get; set; }
        public DelegateCommand<string> GetNewsTyped { get; set; }

        public string Topic { get; set; }

        private readonly IApiNewsService newsService;

        public readonly string[] strings = new[] {
        "Movies",
        "Sport",
        "Music",
        "Technology",        
        };

        public PopMenuViewModel(IApiNewsService apiNews)
        {
            newsService = apiNews;

            TapTopic = new DelegateCommand<string>(SelectTopic);

            GetNewsTyped = new DelegateCommand<string>(SearchTopic);

            FillListCommand = new DelegateCommand(async () => FillCategories());
            FillListCommand.Execute();
        }

        async Task FillCategories()
        {
            var filter = strings.ToList();
            Categories = filter;      
        }

        async void SelectTopic(string topic)
        {
            Topic = topic;
        }

        async void SearchTopic(string text)
        {
            var filter = strings.ToList();
            var topic = char.ToUpper(text[0]) + text.Substring(1);
            if (topic.Length >= 1)
            {
                var suggestions = filter.Where(elem => elem == topic).ToList();

                Categories.Clear();

                Categories = suggestions;
            }
            else if(string.IsNullOrEmpty(topic))
            {
                Categories = filter;
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            var param = new NavigationParameters();
            param.Add("Category", Topic);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
