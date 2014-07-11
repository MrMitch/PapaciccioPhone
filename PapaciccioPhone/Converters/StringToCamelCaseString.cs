using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.UI.Xaml.Data;

namespace PapaciccioPhone.Converters
{
    public class StringToCamelCaseString : IValueConverter
    {
        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = System.Convert.ToString(value) ?? String.Empty;
            var parts = str.Split(new[] {' '});
            var partsUpper = parts.Select(s => String.Format("{0}{1}", char.ToUpperInvariant(s[0]), s.Remove(0,1)));
            
            return String.Join(" ", partsUpper);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
