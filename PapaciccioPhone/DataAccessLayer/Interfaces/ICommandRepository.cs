using System;
using System.Threading.Tasks;
using PapaciccioPhone.Models;
using PapaciccioPhone.ViewModels;

namespace PapaciccioPhone.DataAccessLayer.Interfaces
{
    public interface ICommandRepository
    {
        Task<CommandViewModel> GetCommand(DateTime date);

        Task<CommandViewModel> AddOrder(Order order, CommandViewModel command);

        Task<bool> DeleteCommand(CommandViewModel command);
    }
}
