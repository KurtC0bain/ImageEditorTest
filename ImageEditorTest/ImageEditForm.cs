namespace ImageEditorTest
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public partial class ImageEditForm : Form, IDisposable
    {
        private readonly string _imagePath;

        public ImageEditForm(string imagePath)
        {
            InitializeComponent();

            _imagePath = imagePath;
            this.SetImage(imagePath);

            pictureBox1.Parent = this;
            panelCrop.Parent = pictureBox1;
            panelCrop.MovableAndDraggable();
        }

        private void buttonRotateMinus90_Click(object sender, EventArgs e) => this.RotateImage(RotateFlipType.Rotate270FlipNone);
        private void buttonRotatePlus90_Click(object sender, EventArgs e) => this.RotateImage(RotateFlipType.Rotate90FlipNone);
        private void buttonReset_Click(object sender, EventArgs e) => this.SetImage(_imagePath);

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var img = pictureBox1.Image;
            img.Save(_imagePath);
        }

        private void checkBoxCrop_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;

            pictureBox1.Cursor = checkbox.Checked ? Cursors.Cross : Cursors.Default;

            if (checkbox.Checked)
            {
                //CropImage(new Rectangle(panelCrop.Location, panelCrop.Size));
                CropImage(new Rectangle(panelCrop.Location.X, panelCrop.Location.Y, panelCrop.Size.Width, panelCrop.Size.Height));
            }
        }



        private void SetImage(string imagePath)
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = Image.FromFile(imagePath);
            this.UpdateInfo();
        }

        private void RotateImage(RotateFlipType rotateFlipType)
        {
            var currentImg = pictureBox1.Image;
            currentImg.RotateFlip(rotateFlipType);
            pictureBox1.Invalidate();

            this.UpdateInfo();
        }


        private void CropImage(Rectangle rect)
        {
            //var currentImg = pictureBox1.Image as Bitmap;
            Bitmap currentImg = new(pictureBox1.Image,
                                             pictureBox1.Width,
                                             pictureBox1.Height);
            if (currentImg is { })
            {
                try
                {
                    var newImg = currentImg.Clone(rect, currentImg.PixelFormat);
                    pictureBox1.Image = newImg;
                    currentImg.Dispose();

                    this.UpdateInfo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cropping error!");
                }
            }
        }

        private void UpdateInfo()
        {
            var img = pictureBox1.Image;

            //update info
            labelImageSize.Text = $"{img.Width}x{img.Height}";
        }


        public new void Dispose()
        {
            pictureBox1.Image?.Dispose();
            base.Dispose();

            GC.SuppressFinalize(this);
        }


    }
}
