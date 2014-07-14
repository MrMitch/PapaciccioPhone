using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http;
using Newtonsoft.Json;
using PapaciccioPhone.DataAccessLayer.Interfaces;
using PapaciccioPhone.Models;
using PapaciccioPhone.Models.ApiResponses;

namespace PapaciccioPhone.DataAccessLayer.Implementations.Http
{
    public class HttpCommandRepository : HttpRepository, ICommandRepository
    {
        public async Task<Command> GetCommand(DateTime date)
        {
            Command command = null;

            using (var client = new HttpClient())
            {
                string json;
                try
                {
                    json = await client.GetStringAsync(new Uri(String.Format("{0}/{1}/{2}", BaseAddress, "api/commands", date.ToString("yyyy-MM-dd"))));
                }
                catch (Exception)
                {
                    return null;
                }

                if (!String.IsNullOrEmpty(json))
                {
                    var response = JsonConvert.DeserializeObject<CommandResponse>(json);

                    if (!response.Error)
                    {
                        command = response.Command;
                    }
                }
            }

            return command;
        }

        public Task<Command> AddOrder(Order order, Command command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
