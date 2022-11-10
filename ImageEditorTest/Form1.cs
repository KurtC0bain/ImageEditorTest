namespace ImageEditorTest
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void open_editor_btn_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\img1.jpg");

            if (!File.Exists(path))
            {
                MessageBox.Show(this.AsWin32Window(), $"Зображення за шляхом {path} не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var imageEditForm = new ImageEditForm(path)
            {
                Text = $"{Application.ProductName} - Редагування зображення {path}"
            };
            imageEditForm.ShowDialog(this.AsWin32Window());
        }
    }
}