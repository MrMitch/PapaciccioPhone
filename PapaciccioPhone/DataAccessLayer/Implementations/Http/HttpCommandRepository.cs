using System;
using System.Net;
using System.Text;
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
                    json = await client.GetStringAsync(new Uri(String.Format("{0}/{1}/{2}?cache={3}", BaseAddress, "api/commands", date.ToString("yyyy-MM-dd"), Guid.NewGuid())));
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

        public async Task<bool> AddOrder(Order order, DateTime date)
        {
            var uri = new Uri(String.Format("{0}/api/commands/{1}?cache={2}", BaseAddress, date.ToString("yyyy-MM-dd"), Guid.NewGuid()));
            var success = false;

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(order);
                using (var response = await client.PostAsync(uri, new HttpStringContent(json)))
                {
                    response.EnsureSuccessStatusCode();
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var commandResponse = JsonConvert.DeserializeObject<CommandResponse>(responseJson);

                    if (commandResponse != null)
                    {
                        success = !commandResponse.Error;
                    }
                }
                
            }

            return success;
            /*
            var req = WebRequest.CreateHttp(uri);
            using (var stream = await req.GetRequestStreamAsync())
            {
                var json = JsonConvert.SerializeObject(order);
                var requestBody = Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(requestBody, 0, requestBody.Length);                
            }
            
            using (var response = await req.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            {
                var resp = JsonConvert.DeserializeObject<CommandResponse>(stream.Rea)

            }
            */
        }

        public Task<bool> DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
