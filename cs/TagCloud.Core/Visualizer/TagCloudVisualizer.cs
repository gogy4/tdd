using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudLib.Visualizer;

public static class TagCloudVisualizer
{
    public static void DrawRectangles(IEnumerable<Rectangle> rectangles, string outputPath, 
        TagCloudVisualizationConfig config)
    {
        using var bitmap = new Bitmap(config.CanvasWidth, config.CanvasHeight);
        using var graphics = Graphics.FromImage(bitmap);

        graphics.Clear(config.CanvasBackgroundColor);

        using var pen = new Pen(config.ShapeBorderColor, config.ShapeBorderThickness);
        using var brush = new SolidBrush(config.ShapeFillColor);

        foreach (var rect in rectangles)
        {
            var shifted = Shift(rect, config.CanvasWidth / 2, config.CanvasHeight / 2);

            if (config.ShapeUseFill)
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