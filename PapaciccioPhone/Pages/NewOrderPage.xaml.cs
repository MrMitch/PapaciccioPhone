using Windows.UI.Popups;
using PapaciccioPhone.Common;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page de base, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556
using PapaciccioPhone.Models;
using PapaciccioPhone.ViewModels;

namespace PapaciccioPhone.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class NewOrderPage : Page
    {
        /// <summary>
        /// Obtient le <see cref="NavigationHelper"/> associé à ce <see cref="Page"/>.
        /// </summary>
        private NavigationHelper navigationHelper;
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public NewOrderPageViewModel ViewModel { get; set; }

        //private TranslateTransform _pastFlipViewTranslateTransform = new TranslateTransform();

        public NewOrderPage()
        {
            ViewModel = new NewOrderPageViewModel()
            {
                SubmitOrderCommand = new RelayCommand(async () =>
                {
                    var order = new Order()
                    {
                        Pasta = ViewModel.Pasta,
                        Size = ViewModel.Size, 
                        Sauces = SaucesListBox.SelectedItems.Cast<string>().ToList(),
                        Toppings = ToppingsListView.SelectedItems.Cast<string>().ToList()
                    };

                    var success = await ViewModel.SubmitOrder(order);

                    if (success)
                    {
                        await ViewModel.SaveOrder(order);
                        NavigationService.GoBack();
                    }
                    else
                    {
                        var msg = new MessageDialog("La commande n'a pas pu être enregistrée", "Erreur");
                        msg.Commands.Add(new UICommand("OK", command => NavigationService.GoBack()));

                        await msg.ShowAsync();
                    }
                })
            };

            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }


        /// <summary>
        /// Remplit la page à l'aide du contenu passé lors de la navigation. Tout état enregistré est également
        /// fourni lorsqu'une page est recréée à partir d'une session antérieure.
        /// </summary>
        /// <param name="sender">
        /// La source de l'événement ; en général <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Données d'événement qui fournissent le paramètre de navigation transmis à
        /// <see cref="Frame.Navigate(Type, Object)"/> lors de la requête initiale de cette page et
        /// un dictionnaire d'état conservé par cette page durant une session
        /// antérieure.  L'état n'aura pas la valeur Null lors de la première visite de la page.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            await ViewModel.FetchApiData();
            var lastOrder = await ViewModel.GetLastOrder();

            if (lastOrder != null)
            {
                ViewModel.Pasta = lastOrder.Pasta;
                ViewModel.Size = lastOrder.Size;


                if (lastOrder.Sauces != null)
                {
                    var sauces = ViewModel.AvailableSauces.FindAll(s => lastOrder.Sauces.Contains(s));

                    foreach (var sauce in sauces)
                    {
                        SaucesListBox.SelectedItems.Add(sauce);
                    } 
                }

                if (lastOrder.Toppings != null)
                {
                    var toppings = ViewModel.AvailableToppings.FindAll(t => lastOrder.Toppings.Contains(t));

                    foreach (var topping in toppings)
                    {
                        ToppingsListView.SelectedItems.Add(topping);
                    }
                }
            }
        }

        /// <summary>
        /// Conserve l'état associé à cette page en cas de suspension de l'application ou de
        /// suppression de la page du cache de navigation.  Les valeurs doivent être conformes aux
        /// exigences en matière de sérialisation de <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">La source de l'événement ; en général <see cref="NavigationHelper"/></param>
        /// <param name="e">Données d'événement qui fournissent un dictionnaire vide à remplir à l'aide de l'
        /// état sérialisable.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            
        }

        #region Inscription de NavigationHelper

        /// <summary>
        /// Les méthodes fournies dans cette section sont utilisées simplement pour permettre
        /// NavigationHelper pour répondre aux méthodes de navigation de la page.
        /// <para>
        /// La logique spécifique à la page doit être placée dans les gestionnaires d'événements pour  
        /// <see cref="NavigationHelper.LoadState"/>
        /// et <see cref="NavigationHelper.SaveState"/>.
        /// Le paramètre de navigation est disponible dans la méthode LoadState 
        /// en plus de l'état de page conservé durant une session antérieure.
        /// </para>
        /// </summary>
        /// <param name="e">Fournit des données pour les méthodes de navigation et
        /// les gestionnaires d'événements qui ne peuvent pas annuler la requête de navigation.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void PastaListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;

            if (listbox.SelectedItems.Count > 3)
            {
                foreach (var addedItem in e.AddedItems)
                {
                    listbox.SelectedItems.Remove(addedItem);
                }
            }
        }
    }
}
