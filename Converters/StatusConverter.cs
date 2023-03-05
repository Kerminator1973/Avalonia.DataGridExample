using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace Avalonia.DataGridExample.Converters
{
    public class StatusConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var status = value as string;

            return status switch
            {
                "Rejected" => Brushes.Red,
                _ => Brushes.Green
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
