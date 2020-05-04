using System;
using System.Globalization;
using System.Windows.Data;

namespace DSSW.Client.Converters
{
    /// <summary>
    /// 用于反转布尔值的值转换器
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class ReverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
