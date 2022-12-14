using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleWpfAppTest.mvvm.UserControls
{
    /// <summary>
    /// Interaction logic for ImageControll.xaml
    /// </summary>
    public partial class ImageControll : UserControl
    {
        private readonly Uri _path;
        private Bitmap _image;

        public ImageControll(Uri imagePath)
        {
            this.InitializeComponent();
            _path = imagePath;

            SetImage(_path);

        }

        public ImageControll()
        {
                
        }

        private void SetImage(Uri imagePath)
        {
            _image = new Bitmap(imagePath.AbsolutePath);
            Img.Source = BitmapToSource(new Bitmap(_image));
        }

        private static BitmapImage BitmapToSource(Bitmap src)
        {
            var ms = new MemoryStream();
            src.Save(ms, ImageFormat.Jpeg);

            var image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

    }
}
