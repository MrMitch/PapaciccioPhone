﻿using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using PapaciccioPhone.Common;
// Pour en savoir plus sur le modèle d'élément Page de base, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556
using PapaciccioPhone.Controls;
using PapaciccioPhone.ViewModels;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PapaciccioPhone.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class CommandPage : Page
    {
        /// <summary>
        /// Obtient le <see cref="NavigationHelper"/> associé à ce <see cref="Page"/>.
        /// </summary>
        private NavigationHelper navigationHelper;
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public CommandPageViewModel ViewModel { get; set; }

        private List<Color> _colors = new List<Color>()
        {
            Color.FromArgb(45,255,255,255),
            Windows.UI.Colors.Transparent
        };

        public List<Color> Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }

        public CommandPage()
        {
            ViewModel = new CommandPageViewModel();
            
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
            var commandDate = (DateTime) (e.NavigationParameter ?? e.PageState["date"]);
            await RefreshCommand(commandDate);
        }

        private async Task RefreshCommand(DateTime commandDate)
        {
            var command = await ViewModel.GetCommand(commandDate);

            if (command != null)
            {
                ViewModel.CommandViewModel = command;
            }
            else
            {
                if (commandDate.Date != DateTime.Today)
                {
                    var msg = new MessageDialog("Pas de commande pour cette date", "Oops");
                    msg.Commands.Add(new UICommand("Ok", uiCommand => Frame.Navigate(typeof(CommandPage), DateTime.Now)));
                    await msg.ShowAsync();
                }
            }

            if (ViewModel.CommandViewModel == null || ViewModel.CommandViewModel.OrderViewModels.Count == 0)
            {
                VisualStateManager.GoToState(RootPage, "NoOrderVisualState", true);
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
            if (ViewModel.CommandViewModel != null)
            {
                e.PageState["date"] = ViewModel.CommandViewModel.Date;                
            }
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

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var order = e.ClickedItem as OrderViewModel;
            order.Checked = !order.Checked;
        }

        private void RecapToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var border = VisualTreeHelper.GetChild(OrdersListView, 0);
            var scrollViewer = VisualTreeHelper.GetChild(border, 0) as ScrollViewer;

            scrollViewer.ChangeView(0, 0, null, false);
        }

        private async void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            await RefreshCommand(ViewModel.CommandViewModel.Date);
        }
    }
}
