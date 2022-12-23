using System.IO;
using ConsoleWpfAppTest;

namespace ConsoleWpfAppTest;

public static class ImageEditorHelpers
{
    public static bool OpenDialog(Uri imagePath)
    {
        var result = false;

        if (!File.Exists(imagePath.AbsolutePath))
        {
            throw new ArgumentException("File not found", nameof(imagePath));
        }

        ThreadHelpers.FromSta(() =>
        {
            var window = new MainWindow(imagePath);
            result = window.ShowDialog() ?? false;
        }, wait: true);

        return result;
    }
}
