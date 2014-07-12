using PapaciccioPhone.Models;
using System;
using System.Collections.Generic;

namespace PapaciccioPhone.ViewModels
{
    public class CommandViewModel : BindableViewModel
    {
        public class RecapEntry
        {
            public string Name { get; set; }

            public int Value { get; set; }
        }

        public Command Command { get; set; }

        public List<OrderViewModel> OrderViewModels { get; set; }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                if (_date == null || _date.Equals(DateTime.MinValue))
                {
                    _date = (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(Command.Timestamp);
                }

                return _date;
            }
        }

        public List<RecapEntry> Recap { get; set; }
    }
}
