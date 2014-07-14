using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaciccioPhone.DataAccessLayer.Interfaces
{
    public interface ICommandDataRepository
    {
        Task<List<string>> GetSauces();

        Task<List<string>> GetToppings();

        Task<List<string>> GetSizes();

        Task<List<string>> GetPastas();
    }
}
