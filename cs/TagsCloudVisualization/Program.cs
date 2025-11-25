using System.Drawing;
using TagsCloudLib.Implementations;
using TagsCloudLib.Visualizer;


class Program
{
    static void Main()
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var folderName = Path.Combine(desktopPath, "results");
        Directory.CreateDirectory(folderName);
        
        GenerateExample("cloud1.png", new Size(20, 20), 100, folderName);
        GenerateExample("cloud2.png", new Size(5, 15), 250, folderName);
        GenerateExample("cloud3.png", new Size(10, 40), 1000, folderName);

        Console.WriteLine($"Изображения сохранены по пути {folderName}");
    }

    private static void GenerateExample(string fileName, Size size, int count, string folderName)
    {
        var center = new Point(0, 0);
        var spiral = new ArchimedeanSpiral(center);
        var collisionDetector = new SimpleCollisionDetector();
        var centerShifter = new CenterShifter();
        var layouter = new CircularCloudLayouter(center, spiral, collisionDetector, centerShifter);

        for (var i = 0; i < count; i++)
        {
            layouter.PutNextRectangle(size);
        }
        
        var path = Path.Combine(folderName, $"{fileName}_success.png");
        
        TagCloudVisualizer.DrawRectangles(layouter.Rectangles, path);
    }
}