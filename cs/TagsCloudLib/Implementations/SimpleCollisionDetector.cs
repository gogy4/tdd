using System.Drawing;
using TagsCloudLib.Abstractions;

namespace TagsCloudLib.Implementations;

public class SimpleCollisionDetector : ICollisionDetector
{
    public bool Intersects(Rectangle rectangle, IEnumerable<Rectangle> others)
    {
        return others.Any(r => r.IntersectsWith(rectangle));
    }
}