using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Win32;
using CroppingImageLibrary.Services;
using System.Windows.Documents;

namespace ConsoleWpfAppTest
{
    /// <summary>
    /// Interaction logic for ImageEditorWindow.xaml
    /// </summary>
    public partial class ImageEditorWindow : Window
    {
        private readonly Bitmap _originalImage;
        private Bitmap _editedImage;

        private CropService? _service;

        private int _angle;

        public ImageEditorWindow(Uri imagePath)
        {
            InitializeComponent();

            _originalImage = new Bitmap(imagePath.AbsolutePath);

            _editedImage = new Bitmap(_originalImage);
            Img.Source = BitmapToSource(new Bitmap(_editedImage));
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

        protected override void OnContentRendered(EventArgs e)
        {
            _service = new(Img);

            base.OnContentRendered(e);
        }

        private void CropImage_Click(object sender, RoutedEventArgs e) => Crop();

        private void RotateMinus90_Click(object sender, RoutedEventArgs e) => RotateImage(-90);
        private void RotatePlus90_Click(object sender, RoutedEventArgs e) => RotateImage(90);

        private void Reset_Click(object sender, RoutedEventArgs e) => Reset();

        private void Save_Click(object sender, RoutedEventArgs e) => Save();
        private void RotateImage(int angle)
        {
            if (angle == -90)
            {
                if (this._angle <= 0)
                {
                    this._angle = 270;
                }
                else
                {
                    this._angle -= 90;
                }
            }
            else if (angle == 90)
            {
                if (this._angle >= 270)
                {
                    this._angle = 0;
                }
                else
                {
                    this._angle += 90;
                }
            }

            var bmp = new Bitmap(_originalImage);

            switch (this._angle)
            {
                case 90:
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 180:
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 270:
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            _editedImage = bmp;

            Img.Source = BitmapToSource(_editedImage);
            this.UpdateLayout();

            AdornerLayer.GetAdornerLayer(Img).Remove(_service.Adorner);
            _service = new(Img);
        }

        private void Crop()
        {
            var cropArea = _service!.GetCroppedArea();

            var cropRect = new Rectangle((int)cropArea.CroppedRectAbsolute.X,
                (int)cropArea.CroppedRectAbsolute.Y, (int)cropArea.CroppedRectAbsolute.Width,
                (int)cropArea.CroppedRectAbsolute.Height);

            var target = new Bitmap(cropRect.Width, cropRect.Height);

            using (var g = Graphics.FromImage(target))
            {
                g.DrawImage(_originalImage, new System.Drawing.Rectangle(0, 0, target.Width, target.Height),
                    cropRect,
                    GraphicsUnit.Pixel);
            }

            var dlg = new SaveFileDialog
            {
                FileName = "TestCropping",
                DefaultExt = ".png",
                Filter = "Image png (.png)|*.png"
            };

            bool? result = dlg.ShowDialog();

            if (result != true)
                return;

            string filename = dlg.FileName;
            target.Save(filename);

            _editedImage = target;
            Img.Source = BitmapToSource(_editedImage);
        }


        private void Reset()
        {
            Img.Source = BitmapToSource(new Bitmap(_originalImage));
            this._angle = 0;
        }

        private void Save()
        {
            BitmapImage bi = (BitmapImage)Img.Source;
            SaveFileDialog save = new()
            {
                Title = "Save picture as ",
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp",
                FileName = "croped_image"
            };
            if (save.ShowDialog() == true)
            {
                JpegBitmapEncoder jpg = new();
                jpg.Frames.Add(BitmapFrame.Create(bi));
                using Stream stm = File.Create(save.FileName);
                jpg.Save(stm);
            }

        }
    }
}