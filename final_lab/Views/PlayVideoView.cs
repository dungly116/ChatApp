using System;

using Xamarin.Forms;

namespace final_lab.Views
{
    public class PlayVideoView : ContentPage
    {
        public PlayVideoView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

