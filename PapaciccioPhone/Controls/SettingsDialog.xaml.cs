using Windows.UI.Xaml.Controls;

// Pour en savoir plus sur le modèle d'élément Boîte de dialogue de contenu, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556

namespace PapaciccioPhone.Controls
{
    public sealed partial class SettingsDialog : ContentDialog
    {
        public SettingsDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
