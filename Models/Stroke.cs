using Avalonia;
using System.Collections.Generic;
using Avalonia.Media;

namespace drawingapp.net.Models;

public class Stroke
{
    public List<Point> Points { get; }
    public Color Color { get;  }
    
    public double Thickness { get; }
    public bool IsEraser { get; }
    
    public Stroke(Color color, double thickness, bool isEraser = false)
    {
        Points = new List<Point>();
        Color = color;
        Thickness = thickness;
        IsEraser = isEraser;
    }

    public void AddPoint(Point point)
    {
        Points.Add(point);
    }
}