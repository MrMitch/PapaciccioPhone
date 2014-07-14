using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PapaciccioPhone.Converters
{
    public class BooleanConverter : IValueConverter
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }

        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool) value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
