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

            // Замечание от maxkatz6 (Maintainer of Avalonia): https://github.com/AvaloniaUI/Avalonia/discussions/17790
            // You set null background for most of your cells, as I understand.
            // As I mentioned above, null background is not hit - testable.You need to set Transparent at least.

            return status switch
            {
                "Rejected" => Brushes.Red,
                _ => Brushes.Transparent
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
