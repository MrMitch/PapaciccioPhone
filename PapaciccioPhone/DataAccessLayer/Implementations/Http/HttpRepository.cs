using System;
using Windows.Storage;

namespace PapaciccioPhone.DataAccessLayer.Implementations.Http
{
    public abstract class HttpRepository
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
    }
}
