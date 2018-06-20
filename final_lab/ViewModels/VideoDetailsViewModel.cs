using final_lab.Models;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using final_lab.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace final_lab.ViewModels
{
    class VideoDetailsViewModel : BindableBase, INavigationAware
    {
        private YoutubeItem _vid;
        public YoutubeItem Vid {
            get { return _vid; }
            set { SetProperty(ref _vid, value); }
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("videoKey")) {
                Vid = parameters["videoKey"] as YoutubeItem;

            }
        }
    }
}