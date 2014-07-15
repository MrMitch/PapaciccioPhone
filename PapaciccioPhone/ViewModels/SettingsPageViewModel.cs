using System;
using Windows.Storage;
using PapaciccioPhone.Common;

namespace PapaciccioPhone.ViewModels
{
    public class SettingsPageViewModel : BindableViewModel
    {
        private string _serverAddress;
        public string ServerAddress
        {
            get { return _serverAddress; }
            set
            {
                SetValue(ref _serverAddress, value);
                SubmitSettingsCommand.RaiseCanExecuteChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
                SubmitSettingsCommand.RaiseCanExecuteChanged();
            }
        }
        
        private RelayCommand _submitSettingsCommand;
        public RelayCommand SubmitSettingsCommand
        {
            get
            {
                if (_submitSettingsCommand == null)
                {
                    _submitSettingsCommand = new RelayCommand(
                        () =>
                        {
                            SaveServerAddress(ServerAddress);
                            ApplicationData.Current.LocalSettings.Values["name"] = _name;

                            NavigationService.GoToCommandPage(DateTime.Today);
                        },
                        () => !String.IsNullOrEmpty(ServerAddress)
                            && !String.IsNullOrWhiteSpace(ServerAddress)
                            && !String.IsNullOrEmpty(Name)
                            && !String.IsNullOrWhiteSpace(Name)
                    );
                }
                return _submitSettingsCommand;
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
