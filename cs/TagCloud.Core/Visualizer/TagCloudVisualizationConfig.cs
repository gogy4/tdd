using System.Drawing;

namespace TagsCloudLib.Visualizer;

public class TagCloudVisualizationConfig
{
    public int CanvasWidth { get; set; } = 1500;
    public int CanvasHeight { get; set; } = 1500;

    public Color CanvasBackgroundColor { get; set; } = Color.White;
    public Color ShapeBorderColor { get; set; } = Color.Blue;
    public int ShapeBorderThickness { get; set; } = 2;

    public Color ShapeFillColor { get; set; } = Color.FromArgb(80, Color.CornflowerBlue);
    public bool ShapeUseFill { get; set; } = true;
}
