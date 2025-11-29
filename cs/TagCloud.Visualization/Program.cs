using System.Drawing;
using TagsCloudLib.Implementations;
using TagsCloudLib.Visualizer;


class Program
{
    private static readonly Random Random = new();
    private static TagCloudVisualizationConfig config;

    static void Main()
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var folderName = Path.Combine(desktopPath, "results");
        Directory.CreateDirectory(folderName);
        config = new TagCloudVisualizationConfig
        {
            CanvasWidth = 3000,
            CanvasHeight = 3000,
            CanvasBackgroundColor = Color.Black,
            ShapeBorderColor = Color.Cyan,    
            ShapeBorderThickness = 3,
            ShapeFillColor = Color.FromArgb(80, Color.Cyan)
        };
        GenerateExample("cloud1", 100, folderName);
        GenerateExample("cloud2", 250, folderName);
        GenerateExample("cloud3", 1000, folderName);

        Console.WriteLine($"Изображения сохранены по пути {folderName}");
    }


    private static void GenerateExample(string fileName, int count, string folderName)
    {
        var center = new Point(0, 0);
        var spiral = new ArchimedeanSpiral(center);
        var centerShifter = new CenterShifter();
        var layouter = new CircularCloudLayouter(center, spiral, centerShifter);

        for (var i = 0; i < count; i++)
        {
            var size = new Size(
                Random.Next(5, 50),  
                Random.Next(5, 50));

            layouter.PutNextRectangle(size);
        }

        var path = Path.Combine(folderName, $"{fileName}_success.png");
        TagCloudVisualizer.DrawRectangles(layouter.Rectangles, path, config);
    }

}