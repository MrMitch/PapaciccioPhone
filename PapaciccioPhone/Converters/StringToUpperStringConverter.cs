using System;
using Windows.UI.Xaml.Data;

namespace PapaciccioPhone.Converters
{
    public class StringToUpperStringConverter : IValueConverter
    {
        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value as string ?? String.Empty).ToUpperInvariant() as string;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
