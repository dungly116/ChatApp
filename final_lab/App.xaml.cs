using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using final_lab.Views;
using final_lab.ViewModels;
using System.Diagnostics;
using Plugin.Messaging;
namespace final_lab
{
    public partial class App : PrismApplication
    {
        public static object NotificationService { get; internal set; }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
		{
            InitializeComponent();
            //NavigationService.NavigateAsync(nameof(final_labPage));
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
            //await NavigationService.NavigateAsync($"{nameof(TabContainer)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<YouTubeSearch, YouTubeSearchViewModel>();            
            containerRegistry.RegisterForNavigation<VideoDetails, VideoDetailsViewModel>();
            containerRegistry.RegisterForNavigation<Feature, FeatureViewModel>();
            containerRegistry.RegisterForNavigation<HotVideo,HotVideoViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

        }

		protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
