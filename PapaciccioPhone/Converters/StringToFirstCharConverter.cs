using System;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace PapaciccioPhone.Converters
{
    public class StringToFirstCharConverter : IValueConverter
    {
        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value as string ?? string.Empty).ToUpperInvariant().FirstOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
