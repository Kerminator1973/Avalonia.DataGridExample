using System;
using Avalonia.Media;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.DataGridExample.Converter;

public class StatusConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null) throw new Exception();
        
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