using System.Collections.Generic;
using PapaciccioPhone.Common;
using PapaciccioPhone.DataAccessLayer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PapaciccioPhone.ViewModels
{
    public class CommandPageViewModel : BindableViewModel
    {
        private CommandViewModel _commandViewModel;
        public CommandViewModel CommandViewModel
        {
            get { return _commandViewModel; }
            set { SetValue(ref _commandViewModel, value); }
        }

        private bool _processing;
        public bool Processing
        {
            get { return _processing; }
            set { SetValue(ref _processing, value); }
        }

        public async Task<CommandViewModel> GetCommand(DateTime commandDate)
        {
            Processing = true;
            var command = await RepositoryFactory.CommandRepository.GetCommand(commandDate);

            if (command == null)
            {
                return null;
            }

            var vm = new CommandViewModel()
            {
                Command = command,
                OrderViewModels = command.Orders.Select(o => new OrderViewModel(){Order = o}).ToList()
            };

            var recap = new Dictionary<string, int>(); 
            foreach (var order in vm.Command.Orders)
            {
                var name = String.Join(" ", order.Size.ToUpper(), order.Pasta);
                if (!recap.ContainsKey(name))
                {
                    recap.Add(name, 0);
                }

                recap[name]++;
            }

            vm.Recap = recap.Select(kv => new CommandViewModel.RecapEntry() {Name = kv.Key, Value = kv.Value}).ToList();

            Processing = false;

            return vm;
        }
    }
}
