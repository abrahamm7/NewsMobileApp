using NewsAppMobile.ViewModels;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NewsAppMobile.Views
{
    public class FeedNewsViewModel : BaseViewModel
    {      

        public FeedNewsViewModel(PageDialogService pageDialogService, INavigationService navigationService) :base(pageDialogService, navigationService)
        {

        }
    }
}
