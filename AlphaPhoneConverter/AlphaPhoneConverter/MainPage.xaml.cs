using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlphaPhoneConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var stackLayout = new StackLayout();
            var label = new Label
            {
                Text = "Please enter an alphanumeric string",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            stackLayout.Children.Add(label);
            var entry = new Entry();
            stackLayout.Children.Add(entry);
            var scrollViewer = new ScrollView
            {
                Content = stackLayout,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };


            
        }
    }
}
