using NewsAppMobile.Models;
using Prism.Commands;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppMobile.ViewModels
{
    public class PopMenuViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public List<string> Categories { get; set; }
        
        public DelegateCommand FillListCommand { get; set; }
        public DelegateCommand<string> TapTopic { get; set; }

        public readonly string[] strings = new[] {
        "Movies",
        "Sport",
        "Music",
        "Technology",        
        };

        public PopMenuViewModel()
        {
            TapTopic = new DelegateCommand<string>(SelectTopic);

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

        }

    }
}
