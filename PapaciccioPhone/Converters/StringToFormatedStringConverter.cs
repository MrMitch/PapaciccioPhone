using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PapaciccioPhone.Converters
{
    public class StringToFormatedStringConverter : IValueConverter
    {
        public string Format { get; set; }

        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return String.Format(Format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
