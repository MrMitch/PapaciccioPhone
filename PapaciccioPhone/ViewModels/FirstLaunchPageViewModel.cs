using System;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using PapaciccioPhone.Common;
using PapaciccioPhone.Pages;

namespace PapaciccioPhone.ViewModels
{
    public class FirstLaunchPageViewModel : BindableViewModel
    {
        private string _serverAddress;
        public string ServerAddress
        {
            get { return _serverAddress; }
            set
            {
                SetValue(ref _serverAddress, value);
                SubmitServerAddressCommand.RaiseCanExecuteChanged();
            }
        }

        public Frame Frame { get; set; }

        private RelayCommand _submitServerAddressCommand;
        public RelayCommand SubmitServerAddressCommand
        {
            get
            {
                if (_submitServerAddressCommand == null)
                {
                    _submitServerAddressCommand = new RelayCommand(
                        () =>
                        {
                            SaveServerAddress(ServerAddress);
                            //Frame.Navigate(typeof(CommandPage), DateTime.Now);
                            Frame.Navigate(typeof(CommandPage), new DateTime(2014, 7, 10));
                        },
                        () => !String.IsNullOrEmpty(ServerAddress)
                            && !String.IsNullOrWhiteSpace(ServerAddress)
                    );
                }
                return _submitServerAddressCommand;
            }
        }
        
        public void SaveServerAddress(string address)
        {
            var cleanAddress = (address ?? String.Empty).Trim().TrimEnd(new []{'/'});
            if (!cleanAddress.StartsWith("http://") && !cleanAddress.StartsWith("https://"))
            {
                cleanAddress = "http://" + cleanAddress;
            }

            ApplicationData.Current.RoamingSettings.Values["serverAddress"] = cleanAddress.ToLowerInvariant();
        }

    }
}
