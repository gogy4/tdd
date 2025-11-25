using System.Drawing;
using TagsCloudLib.Abstractions;

namespace TagsCloudLib.Implementations;

public class CircularCloudLayouter(Point center, ISpiral spiral, ICollisionDetector collisionDetector, 
    ICenterShifter centerShifter) : CircularCloudLayouterBase(center)
{
    public override Rectangle PutNextRectangle(Size size)
    {
        if (size.Width <= 0 || size.Height <= 0)
        {
            throw new ArgumentException("Rectangle size must be greater than zero");
        }

        var rectangle = FindFreeRectangle(size);
        rectangle = centerShifter.ShiftToCenter(rectangle, Center, rectangles);
        rectangles.Add(rectangle);
        return rectangle;
    }

    private Rectangle FindFreeRectangle(Size size)
    {
        while (true)
        {
            var point = spiral.GetNextPoint();
            var rectangle = CreateRectangleCenteredAt(point, size);
            if (!collisionDetector.Intersects(rectangle, rectangles))
            {
                return rectangle;
            }
        }
    }

    private static Rectangle CreateRectangleCenteredAt(Point center, Size size)
    {
        return new Rectangle(center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
    }
}