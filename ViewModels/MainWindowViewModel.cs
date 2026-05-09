using CommunityToolkit.Mvvm.ComponentModel;

namespace drawingapp.net.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private DrawingCanvasViewModel _canvas = new();
    // {
        // CurrentColor = Avalonia.Media.Colors.Red,
        // CurrentThickness = 1.0
    // };
}
