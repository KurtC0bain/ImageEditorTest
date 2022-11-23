using ConsoleWpfAppTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;


namespace ConsoleWpfAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CustomBitmap> _images;

        private string[] files;

        public MainWindow(Uri path)
        {
            InitializeComponent();

            _images = new List<CustomBitmap>();

            files =
                Directory.GetFiles(path.AbsolutePath, "*.jpg", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                _images.Add(new CustomBitmap(file));
            }

            Img.Source = ImageEditorWindow.BitmapToSource(new Bitmap(files[0]));

        }


        private void OpenEditor(object sender, MouseButtonEventArgs e)
        {
            ImageEditorHelpers.OpenDialog(new Uri(files[0]));
        }
    }
}
