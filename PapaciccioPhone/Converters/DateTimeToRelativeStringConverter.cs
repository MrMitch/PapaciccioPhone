using System;
using Windows.UI.Xaml.Data;

namespace PapaciccioPhone.Converters
{
    public class DateTimeToRelativeStringConverter : IValueConverter
    {
        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime) value;
            var span = DateTime.Now.Subtract(date);

            if (span.Days > 1)
            {
                return date.ToString("dddd dd MMMM yyyy");
            }
            
            if(span.Days == 1)
            {
                return "hier";
            }

            return "aujourd'hui";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
