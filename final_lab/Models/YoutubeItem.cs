﻿using System;
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
    public class YoutubeItem : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { SetProperty(ref author, value); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        private Image thumbnail;
        public Image Thumbnail
        {
            get { return thumbnail; }
            set { SetProperty(ref thumbnail, value); }
        }
    }
}