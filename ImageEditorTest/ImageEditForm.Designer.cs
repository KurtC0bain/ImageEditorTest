namespace ImageEditorTest
{
    partial class ImageEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelImageSize = new System.Windows.Forms.Label();
            this.buttonRotateMinus90 = new System.Windows.Forms.Button();
            this.buttonRotatePlus90 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanelActions = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxCrop = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panelCrop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelImageSize
            // 
            this.labelImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelImageSize.AutoSize = true;
            this.labelImageSize.BackColor = System.Drawing.SystemColors.Control;
            this.labelImageSize.Location = new System.Drawing.Point(0, 561);
            this.labelImageSize.Name = "labelImageSize";
            this.labelImageSize.Size = new System.Drawing.Size(61, 15);
            this.labelImageSize.TabIndex = 1;
            this.labelImageSize.Text = "1920x1080";
            // 
            // buttonRotateMinus90
            // 
            this.buttonRotateMinus90.Location = new System.Drawing.Point(0, 2);
            this.buttonRotateMinus90.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.buttonRotateMinus90.Name = "buttonRotateMinus90";
            this.buttonRotateMinus90.Size = new System.Drawing.Size(75, 25);
            this.buttonRotateMinus90.TabIndex = 2;
            this.buttonRotateMinus90.Text = "Rotate -90";
            this.buttonRotateMinus90.UseVisualStyleBackColor = true;
            this.buttonRotateMinus90.Click += new System.EventHandler(this.buttonRotateMinus90_Click);
            // 
            // buttonRotatePlus90
            // 
            this.buttonRotatePlus90.Location = new System.Drawing.Point(82, 2);
            this.buttonRotatePlus90.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.buttonRotatePlus90.Name = "buttonRotatePlus90";
            this.buttonRotatePlus90.Size = new System.Drawing.Size(75, 25);
            this.buttonRotatePlus90.TabIndex = 2;
            this.buttonRotatePlus90.Text = "Rotate +90";
            this.buttonRotatePlus90.UseVisualStyleBackColor = true;
            this.buttonRotatePlus90.Click += new System.EventHandler(this.buttonRotatePlus90_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(325, 2);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 25);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanelActions
            // 
            this.tableLayoutPanelActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelActions.ColumnCount = 5;
            this.tableLayoutPanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelActions.Controls.Add(this.checkBoxCrop, 2, 0);
            this.tableLayoutPanelActions.Controls.Add(this.buttonRotatePlus90, 1, 0);
            this.tableLayoutPanelActions.Controls.Add(this.buttonRotateMinus90, 0, 0);
            this.tableLayoutPanelActions.Controls.Add(this.buttonSave, 4, 0);
            this.tableLayoutPanelActions.Controls.Add(this.buttonReset, 3, 0);
            this.tableLayoutPanelActions.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelActions.Location = new System.Drawing.Point(325, 554);
            this.tableLayoutPanelActions.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelActions.Name = "tableLayoutPanelActions";
            this.tableLayoutPanelActions.RowCount = 1;
            this.tableLayoutPanelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelActions.Size = new System.Drawing.Size(400, 30);
            this.tableLayoutPanelActions.TabIndex = 3;
            // 
            // checkBoxCrop
            // 
            this.checkBoxCrop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCrop.AutoSize = true;
            this.checkBoxCrop.Location = new System.Drawing.Point(164, 2);
            this.checkBoxCrop.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.checkBoxCrop.Name = "checkBoxCrop";
            this.checkBoxCrop.Size = new System.Drawing.Size(43, 25);
            this.checkBoxCrop.TabIndex = 4;
            this.checkBoxCrop.Text = "Crop";
            this.checkBoxCrop.UseVisualStyleBackColor = true;
            this.checkBoxCrop.CheckedChanged += new System.EventHandler(this.checkBoxCrop_CheckedChanged);

            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(237, 2);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 25);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // panelCrop
            // 
            this.panelCrop.BackColor = System.Drawing.Color.Transparent;
            this.panelCrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCrop.Location = new System.Drawing.Point(297, 178);
            this.panelCrop.Name = "panelCrop";
            this.panelCrop.Size = new System.Drawing.Size(200, 100);
            this.panelCrop.TabIndex = 0;
            // 
            // ImageEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 584);
            this.Controls.Add(this.panelCrop);
            this.Controls.Add(this.tableLayoutPanelActions);
            this.Controls.Add(this.labelImageSize);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "ImageEditForm";
            this.Text = "ImageEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanelActions.ResumeLayout(false);
            this.tableLayoutPanelActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelImageSize;
        private Button buttonRotateMinus90;
        private Button buttonRotatePlus90;
        private Button buttonSave;
        private TableLayoutPanel tableLayoutPanelActions;
        private CheckBox checkBoxCrop;
        private Panel panelCrop;
        private Button buttonReset;
    }
}