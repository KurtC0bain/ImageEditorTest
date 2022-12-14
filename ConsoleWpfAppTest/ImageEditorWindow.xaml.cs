using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Win32;
using System.Windows.Documents;

using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;
using FontFamily = System.Windows.Media.FontFamily;
using CroppingImageLibrary.Services;


namespace ConsoleWpfAppTest
{
    /// <summary>
    /// Interaction logic for ImageEditorWindow.xaml
    /// </summary>
    public partial class ImageEditorWindow : Window
    {
        private CropService? _service;

        private readonly Uri _path;
        private Bitmap _image;
        private int _angle;
        private bool _isSaved = true;
        private bool _isRendered = false;


        public ImageEditorWindow(Uri imagePath)
        {
            Closing += OnWindowClosing;

            InitializeComponent();

            _path = imagePath;

            SetImage(imagePath);
        }



        private void CropImage_Click(object sender, RoutedEventArgs e) => Crop();

        private void RotateMinus90_Click(object sender, RoutedEventArgs e) => RotateImage(-90);
        private void RotatePlus90_Click(object sender, RoutedEventArgs e) => RotateImage(90);

        private void Reset_Click(object sender, RoutedEventArgs e) => Reset();

        private void Save_Click(object sender, RoutedEventArgs e) => Save();

        private void OnWindowClosing(object sender, CancelEventArgs e) => ExitWithoutSaving(e);




        private void RotateImage(int angle)
        {
            ChangeAngle(angle);

            switch (angle)
            {
                case 90:
                    _image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case -90:
                    _image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            Img.Source = BitmapToSource(_image);
            this.UpdateLayout();

            UpdateCropServiceView();

            _isSaved = false;
        }

        private void Crop()
        {
            try
            {
                var cropArea = _service!.GetCroppedArea();

                var coef = _image.Height / cropArea.OriginalSize.Height;
                

                int realHeight = (int)(cropArea.CroppedRectAbsolute.Height * coef);
                int realWidth = (int)(cropArea.CroppedRectAbsolute.Width * coef);

                var cropRect = new Rectangle((int)(cropArea.CroppedRectAbsolute.TopLeft.X * coef),
                    (int)(cropArea.CroppedRectAbsolute.TopLeft.Y * coef), realWidth,
                    realHeight);

                var target = new Bitmap(cropRect.Width, cropRect.Height);

                using (var g = Graphics.FromImage(target))
                {
                    g.DrawImage(_image, new System.Drawing.Rectangle(0, 0, target.Width, target.Height),
                        cropRect,
                        GraphicsUnit.Pixel);
                }

                _image = new Bitmap(target);
                Img.Source = BitmapToSource(_image);

                this.UpdateLayout();

                UpdateCropServiceView();

                _isSaved = false;


            }
            catch (Exception e)
            {
                MessageBox.Show("Crop error!");
            }
        }

        private void Reset()
        {
            SetImage(_path);
            this._angle = 0;

            this.UpdateLayout();
            UpdateCropServiceView();

            _isSaved = true;
        }

        private void Save()
        {
            BitmapImage bi = (BitmapImage)Img.Source;

            JpegBitmapEncoder jpg = new();
            jpg.Frames.Add(BitmapFrame.Create(bi));


            using MemoryStream ms = new();
            jpg.Save(ms);

            ReleaseImageResources();


            File.WriteAllBytes(_path.AbsolutePath, ms.ToArray());

            _isSaved = true;
            this.Close();
        }

        private void ExitWithoutSaving(CancelEventArgs e)
        {
            if (!_isSaved)
            {
                if (MessageBox.Show("Exit without saving?",
                        "Close",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                    Visibility = Visibility.Hidden;
                }
                else
                {
                    Save();
                }
            }
        }

        private void ChangeAngle(int angle)
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
        }


        protected override void OnContentRendered(EventArgs e)
        {
            _service = new(Img);
            base.OnContentRendered(e);
            _isRendered = true;
        }

        private void SetImage(Uri imagePath)
        {
            _image = new Bitmap(imagePath.AbsolutePath);
            Img.Source = BitmapToSource(new Bitmap(_image));
        }

        private void UpdateCropServiceView()
        {
            AdornerLayer.GetAdornerLayer(Img)?.Remove(_service.Adorner);
            _service = new(Img);
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

        private void ReleaseImageResources()
        {
            Img.Source = null;
            this.UpdateLayout();
            GC.Collect();
        }

        private void Img_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_isRendered)
            {
                UpdateCropServiceView();
            }
        }
    }
}