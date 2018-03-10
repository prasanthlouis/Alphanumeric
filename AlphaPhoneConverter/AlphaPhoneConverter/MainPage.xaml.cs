using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace AlphaPhoneConverter
{
    //Whole program in one clas file. WOOT!
    public partial class MainPage : ContentPage
    {
        private Entry entry;
        public MainPage()
        {
            InitializeComponent();
            var stackLayout = new StackLayout();
            var label = new Label
            {
                Text = "Please enter an alphanumeric string",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 20)
            };
            stackLayout.Children.Add(label);
            entry = new Entry();
            stackLayout.Children.Add(entry);
            var translateButton = new Button();
            translateButton.Text = "Translate";
            translateButton.Clicked += Translate;
            translateButton.Margin = new Thickness(0, 0, 0, 20);
            var callButton = new Button();
            callButton.Text = "Call";
            callButton.Clicked += Call;
            stackLayout.Children.Add(translateButton);
            stackLayout.Children.Add(callButton);
            var scrollViewer = new ScrollView
            {
                Content = stackLayout,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Content = scrollViewer;



        }

        private void Call(object sender, EventArgs e)
        {
            var url = new NSUrl("tel:" + entry.Text);

            // Use URL handler with tel: prefix to invoke Apple's Phone app,
            // otherwise show an alert dialog

            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
        }

        private void Translate(object sender, EventArgs e)
        {
            var notification = new UINotificationFeedbackGenerator();
            notification.Prepare();

            // Trigger feedback
            notification.NotificationOccurred(UINotificationFeedbackType.Error);
            var input = entry.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                entry.Text = string.Empty;
                return;
            }
            else
            {
                input = input.ToUpperInvariant();
            }

            var newNumber = new StringBuilder();
            foreach (var character in input)
            {
                if (" -0123456789".Contains(character))
                {
                    newNumber.Append(character);
                }
                else
                {
                    var result = ExtensionMethods.TranslateToNumber(character);
                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                }
                // otherwise we've skipped a non-numeric char
            }
            entry.Text = newNumber.ToString();
        }

    }
    public static class ExtensionMethods
    {
        public static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        public static int? TranslateToNumber(char c)
        {
            if ("ABC".Contains(c))
            {
                return 2;
            }
            else if ("DEF".Contains(c))
            {
                return 3;
            }
            else if ("GHI".Contains(c))
            {
                return 4;
            }
            else if ("JKL".Contains(c))
            {
                return 5;
            }
            else if ("MNO".Contains(c))
            {
                return 6;
            }
            else if ("PQRS".Contains(c))
            {
                return 7;
            }
            else if ("TUV".Contains(c))
            {
                return 8;
            }
            else if ("WXYZ".Contains(c))
            {
                return 9;
            }
            return null;
        }
    }
}
