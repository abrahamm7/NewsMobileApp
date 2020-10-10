using NewsAppMobile.NavigationLinks;
using NewsAppMobile.Services;
using NewsAppMobile.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace NewsAppMobile
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) 
        {
        
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri(Links.FeedPageLink, UriKind.Relative));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages//
            containerRegistry.RegisterForNavigation<FeedNewsPage, FeedNewsViewModel>();
            containerRegistry.RegisterForNavigation<PopMenu>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //Services//
            containerRegistry.Register<IApiNewsService, ApiNewsService>();
            //containerRegistry.Register<IDeviceOrientation>();


        }
    }
}
