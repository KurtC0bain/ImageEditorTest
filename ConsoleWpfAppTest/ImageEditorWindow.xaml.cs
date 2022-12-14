using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using CroppingImageLibrary;
using CroppingImageLibrary.Services;


namespace ConsoleWpfAppTest
{

    /// <summary>
    /// Interaction logic for ImageEditorWindow.xaml
    /// </summary>
    public partial class ImageEditorWindow : UserControl
    {
        private CropService? _service;

        private readonly Uri _path;
        private Bitmap _image;
        private int _angle;
        private bool _isSaved = true;
        private bool _isRendered;

        public ImageEditorWindow()
        {
                
        }

        public ImageEditorWindow(Uri imagePath)
        {
            InitializeComponent();

            _path = imagePath;

/*            SetImage(imagePath);
*/        }



/*        private void CropImage_Click(object sender, RoutedEventArgs e) => Crop();
*/
/*        private void RotateMinus90_Click(object sender, RoutedEventArgs e) => RotateImage(-90);
        private void RotatePlus90_Click(object sender, RoutedEventArgs e) => RotateImage(90);
*/
/*        private void Reset_Click(object sender, RoutedEventArgs e) => Reset();
*/
/*        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Save();
            this.SetDialogResult(true);
        }
*/
/*        private void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            if (this.SavingQuestion())
            {
                this.Save();
            }

            this.SetDialogResult(true);
        }
*/

/*        private void RotateImage(int angle)
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
*/
/*        private void Crop()
        {
            try
            {
                var cropArea = _service!.GetCroppedArea();

                var coef = _image.Height / cropArea.OriginalSize.Height;


                int realHeight = (int)(cropArea.CroppedRectAbsolute.Height * coef);
                int realWidth = (int)(cropArea.CroppedRectAbsolute.Width * coef);

                var cropRect = new System.Drawing.Rectangle((int)(cropArea.CroppedRectAbsolute.TopLeft.X * coef),
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
*/
/*        private void Reset()
        {
            SetImage(_path);
            this._angle = 0;

            this.UpdateLayout();
            UpdateCropServiceView();

            _isSaved = true;
        }
*/
/*        private byte[] GetImageBytes()
        {
            var bi = (BitmapImage)Img.Source;

            JpegBitmapEncoder jpg = new();
            jpg.Frames.Add(BitmapFrame.Create(bi));

            using var ms = new MemoryStream();
            jpg.Save(ms);

            return ms.ToArray();
        }
*/


/*        private void Save()
        {
            var bytes = this.GetImageBytes();

            this.ReleaseImageResources();

            _isSaved = true;

            File.WriteAllBytes($"{_path.AbsolutePath}.tmp", bytes);
        }
*/

        private bool SavingQuestion()
        {
            if (!_isSaved)
            {
                var msgBoxResult = MessageBox.Show("Зберегти зміни?", "Збереження",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (msgBoxResult == MessageBoxResult.Yes)
                {
                    return true;
                }
            }

            return false;
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


        /*protected override void OnContentRendered(EventArgs e)
        {
            _service = new CropService(Img);
            base.OnContentRendered(e);
            _isRendered = true;
        }*/

/*        private void SetImage(Uri imagePath)
        {
            _image = new Bitmap(imagePath.AbsolutePath);
            Img.Source = BitmapToSource(new Bitmap(_image));
        }

        private void UpdateCropServiceView()
        {
            AdornerLayer.GetAdornerLayer(Img)?.Remove(_service.Adorner);
            _service = new CropService(Img);
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

*/        
/*        private void Img_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_isRendered)
            {
                UpdateCropServiceView();
            }
        }
*/
        //private void SetDialogResult(bool success) => this.DialogResult = success;


        private void Window_Closed(object sender, EventArgs e)
        {
            File.Move($"{_path.AbsolutePath}.tmp", _path.AbsolutePath, overwrite: true);
        }
    }
}