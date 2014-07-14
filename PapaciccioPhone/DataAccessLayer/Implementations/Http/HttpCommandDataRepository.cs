using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;
using PapaciccioPhone.DataAccessLayer.Interfaces;

namespace PapaciccioPhone.DataAccessLayer.Implementations.Http
{
    public class HttpCommandDataRepository : HttpRepository, ICommandDataRepository
    {
        protected async Task<List<string>> GetApiData(string endpointName)
        {
            List<string> data = null;
            using (var client = new HttpClient())
            {
                string json;
                try
                {
                    json = await client.GetStringAsync(new Uri(String.Format("{0}/api/{1}", BaseAddress, endpointName)));
                }
                catch (Exception)
                {
                    return null;
                }

                if (!String.IsNullOrEmpty(json))
                {
                    data = JsonConvert.DeserializeObject<List<string>>(json);
                }
            }

            return data;
        }

        #region ICommandDataRepository Membres

        public Task<List<string>> GetSauces()
        {
            return GetApiData("sauces");
        }

        public Task<List<string>> GetToppings()
        {
            return GetApiData("toppings");
        }

        public Task<List<string>> GetSizes()
        {
            return GetApiData("sizes");
        }

        public Task<List<string>> GetPastas()
        {
            return GetApiData("pasta");
        }

        #endregion
    }
}
