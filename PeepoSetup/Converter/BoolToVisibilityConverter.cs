using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PeepoSetup.Converter;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var isVisible = (bool)value;

        return isVisible ? Visibility.Visible : Visibility.Hidden;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        
    }
}