using System.Drawing;

namespace TagsCloudLib.Abstractions;

public interface ICollisionDetector
{
    bool Intersects(Rectangle rectangle, IEnumerable<Rectangle> others);
}