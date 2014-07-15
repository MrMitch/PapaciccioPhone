using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using PapaciccioPhone.Common;
using PapaciccioPhone.DataAccessLayer;
using PapaciccioPhone.Models;

namespace PapaciccioPhone.ViewModels
{
    public class NewOrderPageViewModel : BindableViewModel
    {
        private bool _processing;
        public bool Processing
        {
            get { return _processing; }
            set { SetValue(ref _processing, value); }
        }

        private List<string> _availablePasta;
        public List<string> AvailablePasta
        {
            get { return _availablePasta; }
            set { SetValue(ref _availablePasta, value); }
        }

        private List<string> _availableSizes;
        public List<string> AvailableSizes
        {
            get { return _availableSizes; }
            set { SetValue(ref _availableSizes, value); }
        }

        private List<string> _availableSauces;
        public List<string> AvailableSauces
        {
            get { return _availableSauces; }
            set { SetValue(ref _availableSauces, value); }
        }

        private List<string> _availableToppings;
        public List<string> AvailableToppings
        {
            get { return _availableToppings; }
            set { SetValue(ref _availableToppings, value); }
        }


        private string _pasta;
        public string Pasta
        {
            get { return _pasta; }
            set { SetValue(ref _pasta, value); }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set { SetValue(ref _size, value); }
        }

        private List<string> _sauces;
        public List<string> Sauces
        {
            get { return _sauces; }
            set { SetValue(ref _sauces, value); }
        }

        private List<string> _toppings;
        public List<string> Toppings
        {
            get { return _toppings; }
            set { SetValue(ref _toppings, value); }
        }

        public RelayCommand SubmitOrderCommand { get; set; }

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(NavigationService.GoBack);
                }
                return _cancelCommand;
            }
        }


        public Order Order { get; set; }

        public async Task FetchApiData()
        {
            Processing = true;
            var repo = RepositoryFactory.CommandDataRepository;

            var pasta = await repo.GetPastas();
            var sauces = await repo.GetSauces();
            var sizes = await repo.GetSizes();
            var toppings = await repo.GetToppings();

            AvailablePasta = pasta;
            AvailableSauces = sauces;
            AvailableSizes = sizes;
            AvailableToppings = toppings;

            Processing = false;
        }

        public async Task SaveOrder(Order order)
        {
            var jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("lastOrder.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(jsonFile, JsonConvert.SerializeObject(order));
        }

        public async Task<Order> GetLastOrder()
        {
            try
            {
                var jsonFile = await ApplicationData.Current.LocalFolder.GetFileAsync("lastOrder.json");
                var json = await FileIO.ReadTextAsync(jsonFile);

                return JsonConvert.DeserializeObject<Order>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> SubmitOrder(Order order)
        {
            Processing = true;

            try
            {
                order.Name = ApplicationData.Current.LocalSettings.Values["name"] as string;
                var status = await RepositoryFactory.CommandRepository.AddOrder(order, DateTime.Today);
                Processing = false;
                
                return status;
            }
            catch (Exception)
            {
                Processing = false;
                return false;
            }
        }
    }
}
