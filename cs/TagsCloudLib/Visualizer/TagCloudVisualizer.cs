using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudLib.Visualizer;

public class TagCloudVisualizer
{
    public static void DrawRectangles(IEnumerable<Rectangle> rectangles, string outputPath, int width = 1500, 
        int height = 1500)
    {
        using var bitmap = new Bitmap(width, height);
        using var graphics = Graphics.FromImage(bitmap);

        graphics.Clear(Color.White);
        using var pen = new Pen(Color.Blue, 2);
        using var brush = new SolidBrush(Color.FromArgb(80, Color.CornflowerBlue));

        foreach (var rect in rectangles)
        {
            var shifted = Shift(rect, width / 2, height / 2);
            graphics.FillRectangle(brush, shifted);
            graphics.DrawRectangle(pen, shifted);
        }

        bitmap.Save(outputPath, ImageFormat.Png);
    }

    private static Rectangle Shift(Rectangle rect, int shiftX, int shiftY)
    {
        return new Rectangle(
            rect.X + shiftX,
            rect.Y + shiftY,
            rect.Width,
            rect.Height);
    }
}