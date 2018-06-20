using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_lab.ViewModels;

namespace final_lab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
          

        }
    }
}