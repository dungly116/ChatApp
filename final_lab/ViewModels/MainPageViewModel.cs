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
using Plugin.Messaging;
using Xamarin.Forms;
using final_lab.Views;
using Prism.Services;

namespace final_lab.ViewModels
{
    class MainPageViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        IPageDialogService _page;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

      

        public DelegateCommand NavToFeature { get; set; }
        public DelegateCommand SendEmail { get; set; }

      

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public object CoreMethods { get; private set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _page = dialogService;
            NavigationService = navigationService;
            Title = "Home";
            NavToFeature = new DelegateCommand(OnNavigateToFeature);
            SendEmail = new DelegateCommand(ReadyForEmail);
        }
        private async void OnNavigateToFeature()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToFeature)}");
            bool key = (UserName == "1"&&Password=="1");
            if (key)
                await NavigationService.NavigateAsync(nameof(Feature));
            else {
              await _page.DisplayAlertAsync("Incorrect Password or UserName", null, "OK");
            }
        }

       

        private async void ReadyForEmail()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(ReadyForEmail)}");

            Device.OpenUri(new Uri("mailto:dungly113@gmail.com"));

            // await NavigationService.NavigateAsync(nameof(YouTubeSearch));
        }
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            //Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            //Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            //Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }

        public virtual void Destroy()
        {
            //Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToYoutube)}");
        }
    }
}
