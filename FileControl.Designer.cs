namespace Material_Editor
{
    partial class FileControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLabel = new System.Windows.Forms.Label();
            this.btFile = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.textureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.materialFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.Location = new System.Drawing.Point(3, 3);
            this.lbLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(150, 13);
            this.lbLabel.TabIndex = 0;
            this.lbLabel.Text = "Label";
            // 
            // btFile
            // 
            this.btFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFile.Location = new System.Drawing.Point(427, 0);
            this.btFile.Name = "btFile";
            this.btFile.Size = new System.Drawing.Size(20, 20);
            this.btFile.TabIndex = 57;
            this.btFile.TabStop = false;
            this.btFile.Text = ".";
            this.btFile.UseVisualStyleBackColor = true;
            this.btFile.Click += new System.EventHandler(this.btFile_Click);
            // 
            // tbFile
            // 
            this.tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFile.Location = new System.Drawing.Point(165, 0);
            this.tbFile.MaxLength = 260;
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(256, 20);
            this.tbFile.TabIndex = 56;
            this.tbFile.TextChanged += new System.EventHandler(this.tbFile_TextChanged);
            // 
            // textureFileDialog
            // 
            this.textureFileDialog.DefaultExt = "dds";
            this.textureFileDialog.Filter = "Texture File (.dds)|*.dds";
            this.textureFileDialog.Title = "Choose a texture file...";
            // 
            // materialFileDialog
            // 
            this.materialFileDialog.DefaultExt = "bgsm";
            this.materialFileDialog.Filter = "Material File (*.bgsm;*.bgem)|*.bgsm;*.bgem";
            this.materialFileDialog.Title = "Choose a material file...";
            // 
            // FileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btFile);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.lbLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FileControl";
            this.Size = new System.Drawing.Size(450, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbLabel;
        private System.Windows.Forms.Button btFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.OpenFileDialog textureFileDialog;
        private System.Windows.Forms.OpenFileDialog materialFileDialog;
    }
}
