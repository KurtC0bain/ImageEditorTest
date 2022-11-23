using ConsoleWpfAppTest;
using System.IO;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");

ThreadHelpers.FromSta(() =>
{
    var window = new MainWindow(new Uri(path));
    window.ShowDialog();
}, wait: true);


Console.ReadLine();