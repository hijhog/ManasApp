using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ManasApp.Mobile.Common.Converters
{
    public class GuidNullOrEmptyBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = value as Guid?;
            return s.HasValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
