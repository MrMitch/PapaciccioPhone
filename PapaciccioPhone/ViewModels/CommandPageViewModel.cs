using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaciccioPhone.ViewModels
{
    public class CommandPageViewModel : BindableViewModel
    {
        private CommandViewModel _command;
        public CommandViewModel Command
        {
            get { return _command; }
            set { SetValue(ref _command, value); }
        }

        private bool _processing;
        public bool Processing
        {
            get { return _processing; }
            set { SetValue(ref _processing, value); }
        }


    }
}
