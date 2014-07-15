using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
using Windows.Graphics.Display;

namespace PapaciccioPhone.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPageViewModel ViewModel { get; set; }

        public SettingsPage()
        {
            ViewModel = new SettingsPageViewModel()
            {
                Name = ApplicationData.Current.LocalSettings.Values["name"] as string,
                ServerAddress = ApplicationData.Current.RoamingSettings.Values["serverAddress"] as string ?? "papaciccio.appsdeck.eu"
            };

            this.InitializeComponent();
        }
    }
}
