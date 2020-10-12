using NewsAppMobile.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAppMobile.ViewModels
{
    public class NewsDetailsViewModel: BaseViewModel
    {
        public NewsDetailsViewModel(PageDialogService pageDialogService, INavigationService navigationService, IApiNewsService apiNewsService) : base(pageDialogService, navigationService)
        {

        }
    }
}
