namespace ConsoleWpfAppTest;

internal class ImageEditorHelpers
{
    public static void OpenDialog(Uri imagePath)
    {
        ThreadHelpers.FromSta(() =>
        {
            var window = new ImageEditorWindow(imagePath);
            window.ShowDialog();
        }, wait: true);
    }
}
