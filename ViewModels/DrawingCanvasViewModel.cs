using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using drawingapp.net.Models;

namespace drawingapp.net.ViewModels;

public partial class DrawingCanvasViewModel : ViewModelBase
{
    [ObservableProperty]
    private Tool _currentTool = Tool.Pen;

    [ObservableProperty] 
    private Color _currentColor = Colors.Black;
    
    [ObservableProperty]
    private double _currentThickness = 4.0;

}