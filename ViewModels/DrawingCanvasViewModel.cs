using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using drawingapp.net.Models;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;

namespace drawingapp.net.ViewModels;

public partial class DrawingCanvasViewModel : ViewModelBase
{
    [ObservableProperty]
    private Tool _currentTool = Tool.Pen;

    [ObservableProperty] 
    private Color _currentColor = Colors.Black;
    
    [ObservableProperty]
    private double _currentThickness = 4.0;

    public IReadOnlyList<Color> PaletteColors { get; } = new List<Color>
    {
        Colors.Black,
        Colors.White,
        Color.Parse("#E53935"), // Red
        Color.Parse("#FB8C00"), // 
        Color.Parse("#FDD835"), // Yellow 
        Color.Parse("#43A047"), // Green
        Color.Parse("#1E88E5"), // Blue
        Color.Parse("#8E24AA"), // Purple
    };

    [RelayCommand]
    private void SelectColor(Color color)
    {
        CurrentColor = color;
    }
    
    
}