using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

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

            panelCrop.Visible = false;
        }

        /// <summary>
        /// Event handlers
        /// </summary>
        /// <param name="sender">obejct which invokes action</param>
        /// <param name="e">parameters</param>
        private void buttonRotateMinus90_Click(object sender, EventArgs e) => this.RotateImage(270);
        private void buttonRotatePlus90_Click(object sender, EventArgs e) => this.RotateImage(90);

        private void buttonReset_Click(object sender, EventArgs e) => this.ResetImage();

        private void buttonSave_Click(object sender, EventArgs e) => this.SaveImage();

        private void checkBoxCrop_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;

            pictureBox1.Cursor = checkbox.Checked ? Cursors.Cross : Cursors.Default;

            if(checkbox.Checked)
            {
                panelCrop.Visible = true;
            }
            else if(panelCrop.Visible)
            {
                CropImage(new Rectangle(panelCrop.Location.X, panelCrop.Location.Y, panelCrop.Size.Width, panelCrop.Size.Height));

                panelCrop.Size = new Size(pictureBox1.Width, pictureBox1.Height);
                panelCrop.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);

                checkbox.Checked = !checkbox.Checked;
            }
        }


        /// <summary>
        /// Editor methods
        /// </summary>
        private void SetImage(string imagePath)
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = Image.FromFile(imagePath);
            this.UpdateInfo();
        }
        private void SaveImage()
        {
            var currentImg = pictureBox1.Image;

            SaveFileDialog sf = new();
            sf.FileName = "croped_image";
            sf.Filter = "JPG(*.JPG)|*.jpg";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                currentImg.Save(sf.FileName);
            }

        }
        private void ResetImage()
        {
            this.SetImage(_imagePath);

            panelCrop.Visible = false;
            checkBoxCrop.Checked = false;

            panelCrop.Location = new Point(297, 178);
            panelCrop.Size = new Size(200, 100);
        }

        private void RotateImage(int angle)
        {
/*                       var currentImg = pictureBox1.Image;
                pictureBox1.Image = currentImg.RotateFlip(rotateFlipType);
*/

   
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            int w = bmp.Width;

            int h = bmp.Height;

            Bitmap tempImg = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(tempImg);

            g.DrawImageUnscaled(bmp, 1, 1);

            g.Dispose();

            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(0f, 0f, w, h));

            Matrix mtrx = new Matrix();

            mtrx.Rotate(angle);

            RectangleF rct = path.GetBounds(mtrx);

            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height));

            g = Graphics.FromImage(newImg);

            g.TranslateTransform(-rct.X, -rct.Y);

            g.RotateTransform(angle);

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.DrawImageUnscaled(tempImg, 0, 0);

            g.Dispose();

            tempImg.Dispose();

            pictureBox1.Image = newImg;
            pictureBox1.Invalidate();

            this.UpdateInfo();
        }

        private void CropImage(Rectangle rect)
        {
            Bitmap currentImg = new(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
            if (currentImg is { })
            {
                try
                {
                    var newImg = currentImg.Clone(rect, currentImg.PixelFormat);
                    pictureBox1.Image = newImg;
                    currentImg.Dispose();

                    panelCrop.Size = newImg.Size;

                    UpdateInfo();
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
