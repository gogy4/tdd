using System.Drawing;

namespace TagsCloudLib.Abstractions;

public abstract class CircularCloudLayouterBase(Point center)
{
    public Point Center { get; init; } = center;
    protected List<Rectangle> rectangles = [];
    public IEnumerable<Rectangle> Rectangles => rectangles;

    public abstract Rectangle PutNextRectangle(Size rectangleSize);
}