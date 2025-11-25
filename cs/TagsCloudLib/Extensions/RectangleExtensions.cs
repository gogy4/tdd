using System.Drawing;

namespace TagsCloudLib.Extensions;

public static class RectangleExtensions
{
    public static Point Center(this Rectangle rectangle)
    {
        return new Point(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
    }
}