using System;
using System.Globalization;
using Avalonia.Data.Converters;
using drawingapp.net.Models;

namespace drawingapp.net.ViewModels;

public class ToolConverter : IValueConverter
{
    public static readonly ToolConverter Instance = new();
    
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Tool currentTool && parameter is Tool targetTool)
        {
            return currentTool == targetTool;
        }

        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isChecked && isChecked && parameter is Tool targetTool)
        {
            return targetTool;
        }

        return Avalonia.Data.BindingOperations.DoNothing;
    }
}