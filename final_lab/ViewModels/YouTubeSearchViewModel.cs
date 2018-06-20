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
using System.Collections.Specialized;
using System.ComponentModel;

namespace final_lab.ViewModels
{
    class YouTubeSearchViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IPageDialogService _page;
        //public DelegateCommand NavToContainer { get; set; }
        public DelegateCommand<YoutubeItem> VideoTappedCommand { get; set; }
        public DelegateCommand Search_Clicked { get; set; }
        public DelegateCommand PullToRefreshCommand { get; set; }

        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }

        private ObservableCollection<YoutubeItem> _videos;
        public ObservableCollection<YoutubeItem> Videos
        {
            get { return _videos; }
            set { SetProperty(ref _videos, value); }
        }
        private YoutubeItem _selectedPerson;
        public YoutubeItem SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
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

        public YouTubeSearchViewModel(INavigationService navigationService, IPageDialogService page)
        {
            _page = page;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

            _navigationService = navigationService;
           // NavToContainer = new DelegateCommand(OnNavigateToTabContainer);
            Title = "YouTube";
            VideoTappedCommand = new DelegateCommand<YoutubeItem>(OnVideoTapped);          
            Search_Clicked = new DelegateCommand(OnSearchClicked);
            PullToRefreshCommand = new DelegateCommand(OnPullToRefresh);
            RefreshVideoList();

        }
        private async void OnPullToRefresh()
        {           
            await RefreshVideoList();
        }
        private async Task RefreshVideoList()
        {
           // Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshPeopleList)}");

            ShowIsBusySpinner = true;
            Debug.WriteLine("=======", ShowIsBusySpinner);
            SearchResults searchResults = new SearchResults();
            Videos = new ObservableCollection<YoutubeItem>(searchResults.GetResults("Dog"));
            ShowIsBusySpinner = false;
        }

        private void  OnSearchClicked()
        {
            ShowIsBusySpinner = true;
            Debug.WriteLine("=======", ShowIsBusySpinner);
            SearchResults searchResults = new SearchResults();
            Videos = new ObservableCollection<YoutubeItem>(searchResults.GetResults(SearchBarText));
            ShowIsBusySpinner = false;
        }


        private async void OnNavigateToTabContainer()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToTabContainer)}");

           // _navigationService.NavigateAsync(nameof(TabContainer));
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
               // Debug.WriteLine("fhcjksahfkjsdhfkjhsakjlfhskja");

            }
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }

        private  void OnVideoTapped(YoutubeItem item)
        {
            // var navParams = new NavigationParameters();
            //navParams.Add("videoKey", item);
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