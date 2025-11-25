using System.Drawing;
using TagsCloudLib.Abstractions;

namespace TagsCloudLib.Implementations;

public class ArchimedeanSpiral(Point center) : ISpiral
{
    private double angle;
    private const double SpiralStep = 0.2;
    private const double RadiusStep = 0.5;

    public Point GetNextPoint()
    {
        angle += SpiralStep;
        var radius = RadiusStep * angle;
        var x = (int)(center.X + radius * Math.Cos(angle));
        var y = (int)(center.Y + radius * Math.Sin(angle));
        return new Point(x, y);
    }
}