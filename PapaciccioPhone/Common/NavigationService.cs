using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using PapaciccioPhone.Pages;

namespace PapaciccioPhone.Common
{
    public static class NavigationService
    {
        public static Frame Frame { get; set; }

        public static bool CanGoBack()
        {
            return Frame.CanGoBack;
        }

        public static bool CanGoForward()
        {
            return Frame.CanGoBack;
        }

        public static void GoBack()
        {
            if (CanGoBack())
            {
                Frame.GoBack();                
            }
        }

        public static void GoForward()
        {
            if (CanGoForward())
            {
                Frame.GoForward();
            }
        }

        public static bool GoToCommandPage(DateTime date)
        {
            return Frame.Navigate(typeof (CommandPage), date);
        }

        public static bool GoToSettingsPage()
        {
            return Frame.Navigate(typeof(SettingsPage));
        }

        public static bool GoToNewOrderPage()
        {
            return Frame.Navigate(typeof(NewOrderPage));
        }
    }
}
