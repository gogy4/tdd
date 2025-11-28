using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudLib.Visualizer;

public static class TagCloudVisualizer
{
    public static void DrawRectangles(IEnumerable<Rectangle> rectangles, string outputPath, 
        TagCloudVisualizationConfig config)
    {
        using var bitmap = new Bitmap(config.Width, config.Height);
        using var graphics = Graphics.FromImage(bitmap);

        graphics.Clear(config.BackgroundColor);

        using var pen = new Pen(config.BorderColor, config.BorderThickness);
        using var brush = new SolidBrush(config.FillColor);

        foreach (var rect in rectangles)
        {
            var shifted = Shift(rect, config.Width / 2, config.Height / 2);

            if (config.UseFill)
            {
                graphics.FillRectangle(brush, shifted);
            }

            graphics.DrawRectangle(pen, shifted);
        }

        bitmap.Save(outputPath, ImageFormat.Png);
    }

    private static Rectangle Shift(Rectangle rect, int shiftX, int shiftY)
    {
        return new Rectangle(rect.X + shiftX, rect.Y + shiftY, rect.Width, rect.Height);
    }
}