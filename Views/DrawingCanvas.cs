using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using drawingapp.net.Models;

namespace drawingapp.net.Views;

public class DrawingCanvas : Control
{
    private readonly List<Stroke> _strokes = new();

    private Stroke? _currentStroke;
    
    public IBrush StrokeBrush { get; set; } = Brushes.Black;
    public double StrokeThickness { get; set; } = 4.0;
    
    public DrawingCanvas()
    {
        Focusable = true;
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        _currentStroke = new Stroke(thickness: StrokeThickness);
        _currentStroke.AddPoint(e.GetPosition(this));
        
        InvalidateVisual();

        e.Pointer.Capture(this);
        
        e.Handled = true;
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);

        if (_currentStroke == null) return;
        
        _currentStroke.AddPoint(e.GetPosition(this));
        InvalidateVisual();
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);

        if (_currentStroke == null) return;
        
        _strokes.Add(_currentStroke);
        _currentStroke = null;
        
        InvalidateVisual();
        e.Pointer.Capture(null);
    }

    public override void Render(DrawingContext context)
    {
        context.FillRectangle(Brushes.White, Bounds);

        foreach (var stroke in _strokes)
        {
            DrawStroke(context, stroke);
        }

        if (_currentStroke != null)
        {
            DrawStroke(context, _currentStroke);
        }
    }

    private void DrawStroke(DrawingContext context, Stroke stroke)
    {
        if (stroke.Points.Count < 2) return;

        var pen = new Pen(StrokeBrush, stroke.Thickness)
        {
            LineCap = PenLineCap.Round,
            LineJoin = PenLineJoin.Round,
        };
        
        var geometry = new StreamGeometry();
        using (var ctx = geometry.Open())
        {
            ctx.BeginFigure(stroke.Points[0], isFilled: false);
            for (int i = 1; i < stroke.Points.Count; i++)
            {
                ctx.LineTo(stroke.Points[i]);
            }
            ctx.EndFigure(isClosed: false);
        }
        
        context.DrawGeometry(brush: null, pen: pen, geometry : geometry);
    }
    
}