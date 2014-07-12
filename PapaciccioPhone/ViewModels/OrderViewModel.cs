using PapaciccioPhone.Models;
using System;
using System.Linq;

namespace PapaciccioPhone.ViewModels
{
    public class OrderViewModel : BindableViewModel
    {
        public Order Order { get; set; }

        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set { SetValue(ref _checked, value); }
        }

        public string ToppingsAbbreviation
        {
            get
            {
                if (Order.Toppings == null)
                {
                    return String.Empty;
                }
                return String.Join(" & ", Order.Toppings.Select(s => s.ToUpperInvariant()[0]));
            }
        }
    }
}
