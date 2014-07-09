using System;
using Windows.Storage;
using PapaciccioPhone.Common;

namespace PapaciccioPhone.ViewModels
{
    public class FirstLaunchPageViewModel : BindableViewModel
    {
        public string ServerAddress { get; set; }

        public void SaveServerAddress(string address)
        {
            ApplicationData.Current.RoamingSettings.Values["serverAddress"] = address;
        }
        
    }
}
