using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using final_lab.Views;
using Xamarin.Forms;
using final_lab.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Services;

namespace final_lab.ViewModels
{
    class HotVideoViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IPageDialogService _page;

        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }

        private HotTopic _vid;
        public HotTopic Vid
        {
            get { return _vid; }
            set { SetProperty(ref _vid, value); }
        }
        //public DelegateCommand NavToContainer { get; set; }
        public DelegateCommand<YoutubeItem> VideoTappedCommand { get; set; }
        public DelegateCommand Search_Clicked { get; set; }

        private ObservableCollection<YoutubeItem> _videos;
        public ObservableCollection<YoutubeItem> Videos
        {
            get { return _videos; }
            set { SetProperty(ref _videos, value); }
        }

        private string _searchBarText;
        public string SearchBarText
        {
            get { return _searchBarText; }
            set { SetProperty(ref _searchBarText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public HotVideoViewModel (INavigationService navigationService, IPageDialogService page)
        {
            _page=page;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");
            _navigationService = navigationService;
            VideoTappedCommand = new DelegateCommand<YoutubeItem>(OnVideoTapped);
           
        }
      
     
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

            if (parameters.ContainsKey("videoKey"))
            {
                ShowIsBusySpinner = true;
                Vid = parameters["videoKey"] as HotTopic;
                string search = Vid.Title;
                SearchResults searchResults = new SearchResults();
                Videos = new ObservableCollection<YoutubeItem>(searchResults.GetResults(SearchBarText));
                ShowIsBusySpinner = false;

            }           
        }
        private void OnVideoTapped(YoutubeItem item)
        {
            // var navParams = new NavigationParameters();
            //navParams.Add("videoKey", item)
            //_navigationService.NavigateAsync(nameof(VideoDetails), navParams);


            IActionSheetButton Yes = ActionSheetButton.CreateButton("Yes", new DelegateCommand(() => {
                Task.Run(() => { Device.OpenUri(new Uri(item.Url)); });
            }));
            IActionSheetButton No = ActionSheetButton.CreateButton("No", new DelegateCommand(() => { Debug.WriteLine("No"); }));
            _page.DisplayActionSheetAsync("Using third party app for watching video!", Yes, No);

            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnVideoTapped)}; {_videos}");
        }

    }
}