using ConsoleWpfAppTest;
using System.IO;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\img1.jpg");

ImageEditorHelpers.OpenDialog(new Uri(path, UriKind.Absolute));


Console.ReadLine();