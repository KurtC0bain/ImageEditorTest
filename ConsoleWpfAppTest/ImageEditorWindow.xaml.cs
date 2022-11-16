using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;

namespace ConsoleWpfAppTest
{
    /// <summary>
    /// Interaction logic for ImageEditorWindow.xaml
    /// </summary>
    public partial class ImageEditorWindow : Window
    {
        private readonly Bitmap OriginalImage;
        private Bitmap EditedImage;

        private readonly Adorner _resizeAdorner;
        private readonly Uri _imagePath;

        private int angle = 0;
        private bool initializeResizer = true;

        public ImageEditorWindow(Uri imagePath)
        {
            InitializeComponent();
            _resizeAdorner = new ResizeAdorner(cropRectangle);
            _imagePath = imagePath;

            OriginalImage = new Bitmap(imagePath.AbsolutePath);
            EditedImage = new Bitmap(OriginalImage);
            img.Source = BitmapToSource(new Bitmap(OriginalImage));
        }

        private static BitmapImage BitmapToSource(Bitmap src)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            src.Save(ms, ImageFormat.Jpeg);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            CropVisibilityChange();
            base.OnContentRendered(e);
        }

        private void CropImage_Click(object sender, RoutedEventArgs e) => Crop();

        private void RotateMinus90_Click(object sender, RoutedEventArgs e) => RotateImage(-90);
        private void RotatePlus90_Click(object sender, RoutedEventArgs e) => RotateImage(90);

        private void Reset_Click(object sender, RoutedEventArgs e) => Reset();

        private void Save_Click(object sender, RoutedEventArgs e) => Save();

        private void CropVisibilityChange()
        {
            if (initializeResizer)
            {
                cropRectangle.Visibility = Visibility.Visible;
                AdornerLayer.GetAdornerLayer(img).Add(_resizeAdorner);

                cropRectangle.Height = img.ActualHeight - 5;
                cropRectangle.Width = img.ActualWidth - 5;

                initializeResizer = false;
            }
        }

        private void RotateImage(int angle)
        {
            if (angle == -90)
            {
                if (this.angle <= 0)
                {
                    this.angle = 270;
                }
                else
                {
                    this.angle -= 90;
                }
            }
            else if (angle == 90)
            {
                if (this.angle >= 270)
                {
                    this.angle = 0;
                }
                else
                {
                    this.angle += 90;
                }
            }

            Bitmap bmp = new Bitmap(OriginalImage);

            switch (this.angle)
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

            EditedImage = bmp;
            img.Source = BitmapToSource(EditedImage);
        }

        private void Crop()
        {
        }

        private void Reset()
        {
            do
            {
                RotateImage(90);
            } while (this.angle != 0);
        }

        private void Save()
        {
            BitmapImage bi = (BitmapImage)img.Source;
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