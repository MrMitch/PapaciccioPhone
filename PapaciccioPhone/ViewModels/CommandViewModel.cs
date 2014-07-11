using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PapaciccioPhone.Models;

namespace PapaciccioPhone.ViewModels
{
    [DataContract]
    public class CommandViewModel : BindableViewModel
    {
        [DataMember(Name = "date")]
        public int Timestamp { get; set; }

        private DateTime _date;
        [IgnoreDataMember]
        public DateTime Date
        {
            get
            {
                if (_date == null || _date.Equals(DateTime.MinValue))
                {
                    _date = (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(Timestamp);
                }

                return _date;
            }
        }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        private List<Order> _orders;
        [DataMember(Name = "orders")]
        public List<Order> Orders
        {
            get { return _orders; }
            set { SetValue(ref _orders, value); }
        }
        
    }
}
