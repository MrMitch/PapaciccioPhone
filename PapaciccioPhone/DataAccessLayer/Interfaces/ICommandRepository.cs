using PapaciccioPhone.Models;
using System;
using System.Threading.Tasks;

namespace PapaciccioPhone.DataAccessLayer.Interfaces
{
    public interface ICommandRepository
    {
        Task<Command> GetCommand(DateTime date);

        Task<bool> AddOrder(Order order, DateTime date);

        Task<bool> DeleteCommand(Command command);
    }
}
