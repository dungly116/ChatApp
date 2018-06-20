using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Xamarin.Forms;
using Prism.Mvvm;

namespace final_lab.Models
{
    public class HotTopic : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }      
    }
}