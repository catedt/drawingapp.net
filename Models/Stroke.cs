using Avalonia;
using System.Collections.Generic;

namespace drawingapp.net.Models;

public class Stroke
{
    public List<Point> Points { get; }
    public double Thickness { get; }

    public Stroke(double thickness)
    {
        Points = new List<Point>();
        Thickness = thickness;
    }

    public void AddPoint(Point point)
    {
        Points.Add(point);
    }
}