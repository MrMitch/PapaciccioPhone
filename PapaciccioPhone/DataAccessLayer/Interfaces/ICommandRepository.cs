using PapaciccioPhone.Models;
using System;
using System.Threading.Tasks;

namespace PapaciccioPhone.DataAccessLayer.Interfaces
{
    public interface ICommandRepository
    {
        Task<Command> GetCommand(DateTime date);

        Task<Command> AddOrder(Order order, Command command);

        Task<bool> DeleteCommand(Command command);
    }
}
