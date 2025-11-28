using System.Drawing;

namespace TagsCloudLib.Visualizer;

public class TagCloudVisualizationConfig
{
    public int Width { get; set; } = 1500;
    public int Height { get; set; } = 1500;

    public Color BackgroundColor { get; set; } = Color.White;
    public Color BorderColor { get; set; } = Color.Blue;
    public int BorderThickness { get; set; } = 2;

    public Color FillColor { get; set; } = Color.FromArgb(80, Color.CornflowerBlue);
    public bool UseFill { get; set; } = true;
}
