using Prism;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NewsAppMobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, INavigatedAware, IInitialize
    {
        public event PropertyChangedEventHandler PropertyChanged;
        

        public IPageDialogService PageDialogService { get; set; }
        public INavigationService NavigationService { get; set; }
        

        public void Initialize(INavigationParameters parameters)
        {
            
        }

        public BaseViewModel(PageDialogService pageDialogService, INavigationService navigationService)
        {
            PageDialogService = pageDialogService;
            NavigationService = navigationService;           
        }

        public async Task<bool> HasInternetConnection(bool sendMessage = false)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                if (sendMessage)
                {
                    await App.Current.MainPage.DisplayAlert(Constants.ErrorMessages.NoInternet, Constants.ErrorMessages.Description, Constants.ErrorMessages.Confirm);

                }
                return false;
            }
        }

        public async Task ShowMessage(string title, string message, string cancel, string accept = null)
        {
            await PageDialogService.DisplayAlertAsync(title, message, accept, cancel);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //Nothing for now//
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //Nothing for now//
        }
    }
}
