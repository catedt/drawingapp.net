using Avalonia.Controls;
using Avalonia.Media;

namespace drawingapp.net.Views;

public class DrawingCanvas : Control
{

    static DrawingCanvas()
    {
        
    }

    public override void Render(DrawingContext context)
    {
        context.FillRectangle(Brushes.White, Bounds);
    }
    
}