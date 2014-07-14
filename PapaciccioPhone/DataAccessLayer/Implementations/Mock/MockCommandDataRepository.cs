using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using PapaciccioPhone.DataAccessLayer.Interfaces;

namespace PapaciccioPhone.DataAccessLayer.Implementations.Mock
{
    public class MockCommandDataRepository : ICommandDataRepository
    {
        #region ICommandDataRepository Membres

        public async Task<List<string>> GetSauces()
        {
            await Task.Delay(1000);
            
            var jsonFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/DummyData/sauces.json"));
            var json = await FileIO.ReadTextAsync(jsonFile);

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        public Task<List<string>> GetToppings()
        {
            return Task.FromResult(new List<string>(){"gruyère", "parmesan"});
        }

        public Task<List<string>> GetSizes()
        {
            return Task.FromResult(new List<string>() { "petit", "normal", "maxi" });
        }

        public Task<List<string>> GetPastas()
        {
            return Task.FromResult(new List<string>(){"penne", "fusilli", "farfalle", "spaghetti"});
        }

        #endregion
    }
}
