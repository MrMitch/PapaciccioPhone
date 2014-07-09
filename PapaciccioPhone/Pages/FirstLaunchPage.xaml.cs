using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d’élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556
using PapaciccioPhone.Common;
using PapaciccioPhone.ViewModels;

namespace PapaciccioPhone.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class FirstLaunchPage : Page
    {
        public FirstLaunchPageViewModel ViewModel { get; set; }

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
                            ViewModel.SaveServerAddress(ViewModel.ServerAddress);
                            Frame.Navigate(typeof (CommandPage));
                        },
                        () => !String.IsNullOrEmpty(ViewModel.ServerAddress) 
                            && !String.IsNullOrWhiteSpace(ViewModel.ServerAddress)
                    );
                }
                return _submitServerAddressCommand;
            }
        }

        public FirstLaunchPage()
        {
            ViewModel = new FirstLaunchPageViewModel();
            this.InitializeComponent();
        }
        
        private void ValidateButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
