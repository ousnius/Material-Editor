namespace Material_Editor
{
    partial class ColorControl
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
            this.btColor = new System.Windows.Forms.Button();
            this.lbLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // btColor
            // 
            this.btColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btColor.BackColor = System.Drawing.Color.White;
            this.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btColor.Location = new System.Drawing.Point(165, 0);
            this.btColor.Margin = new System.Windows.Forms.Padding(0);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(282, 20);
            this.btColor.TabIndex = 1;
            this.btColor.UseVisualStyleBackColor = false;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.Location = new System.Drawing.Point(3, 3);
            this.lbLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(150, 13);
            this.lbLabel.TabIndex = 0;
            this.lbLabel.Text = "Label";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // ColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.lbLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ColorControl";
            this.Size = new System.Drawing.Size(450, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btColor;
        private System.Windows.Forms.Label lbLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}
