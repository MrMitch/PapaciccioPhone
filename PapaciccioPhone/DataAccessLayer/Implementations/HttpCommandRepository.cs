using Newtonsoft.Json;
using PapaciccioPhone.DataAccessLayer.Interfaces;
using PapaciccioPhone.Models;
using PapaciccioPhone.Models.ApiResponses;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http;

namespace PapaciccioPhone.DataAccessLayer.Implementations
{
    public class HttpCommandRepository : ICommandRepository
    {
        private string _baseAddress;
        public string BaseAddress
        {
            get
            {
                if (String.IsNullOrEmpty(_baseAddress))
                {
                    _baseAddress = ApplicationData.Current.RoamingSettings.Values["serverAddress"] as string ?? String.Empty;
                }
                return _baseAddress;
            }
        }

        public async Task<Command> GetCommand(DateTime date)
        {
            Command command = null;

            using (var client = new HttpClient())
            {
                string json = String.Empty;
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
