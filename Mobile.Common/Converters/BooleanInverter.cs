using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Mobile.Common.Converters
{
    public class BooleanInverter : IValueConverter
    {
        public static BooleanInverter Instance { get; } = new BooleanInverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        private object Convert(object value)
        {
            return (value is bool b) ? !b : value;
        }
    }
}
