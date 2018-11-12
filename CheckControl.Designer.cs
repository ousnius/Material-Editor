namespace Material_Editor
{
    partial class CheckControl
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
            this.check = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            // check
            // 
            this.check.Location = new System.Drawing.Point(165, 3);
            this.check.Margin = new System.Windows.Forms.Padding(0);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(55, 13);
            this.check.TabIndex = 1;
            this.check.UseVisualStyleBackColor = true;
            this.check.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // CheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.check);
            this.Controls.Add(this.lbLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CheckControl";
            this.Size = new System.Drawing.Size(450, 21);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbLabel;
        private System.Windows.Forms.CheckBox check;
    }
}
