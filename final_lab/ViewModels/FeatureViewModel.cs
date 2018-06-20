using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using final_lab.Views;
using final_lab.Models;
using System.Collections.ObjectModel;

namespace final_lab.ViewModels
{
    class FeatureViewModel: BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        public DelegateCommand NavToYouTube { get; set; }
        public DelegateCommand<HotTopic> VideoTappedCommand { get; set; }
        private ObservableCollection<HotTopic> _videos;
        public ObservableCollection<HotTopic> Videos
        {
            get { return _videos; }
            set { SetProperty(ref _videos, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }


        public FeatureViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Title = "Trending KeyWords";
            AddHotTopic searchResults = new AddHotTopic();
            Videos = new ObservableCollection<HotTopic>(searchResults.GetHotTopic());
            NavToYouTube = new DelegateCommand(OnNavigateToYoutube);

            VideoTappedCommand = new DelegateCommand<HotTopic>(OnVideoTapped);
        }
        private async void OnNavigateToYoutube()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
            
            await  NavigationService.NavigateAsync(nameof(YouTubeSearch));
        }
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }

        public virtual void Destroy()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }
        private void OnVideoTapped(HotTopic item)
        {
            ShowIsBusySpinner = true;
            var navParams = new NavigationParameters();
            navParams.Add("videoKey", item);
            Debug.WriteLine("=================================");
            NavigationService.NavigateAsync(nameof(HotVideo), navParams);
            ShowIsBusySpinner = false;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnVideoTapped)}; {_videos}");
        }
    }
}
