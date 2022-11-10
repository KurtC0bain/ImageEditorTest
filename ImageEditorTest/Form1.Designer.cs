namespace ImageEditorTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.open_editor_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open_editor_btn
            // 
            this.open_editor_btn.Location = new System.Drawing.Point(76, 12);
            this.open_editor_btn.Name = "open_editor_btn";
            this.open_editor_btn.Size = new System.Drawing.Size(85, 23);
            this.open_editor_btn.TabIndex = 0;
            this.open_editor_btn.Text = "Open editor";
            this.open_editor_btn.UseVisualStyleBackColor = true;
            this.open_editor_btn.Click += new System.EventHandler(this.open_editor_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 47);
            this.Controls.Add(this.open_editor_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button open_editor_btn;
    }
}