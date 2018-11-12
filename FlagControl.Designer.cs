namespace Material_Editor
{
    partial class FlagControl
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
            this.checkedList = new System.Windows.Forms.CheckedListBox();
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
            // checkedList
            // 
            this.checkedList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedList.ColumnWidth = 150;
            this.checkedList.FormattingEnabled = true;
            this.checkedList.Location = new System.Drawing.Point(165, 0);
            this.checkedList.MultiColumn = true;
            this.checkedList.Name = "checkedList";
            this.checkedList.Size = new System.Drawing.Size(282, 94);
            this.checkedList.TabIndex = 1;
            this.checkedList.SelectedIndexChanged += new System.EventHandler(this.checkedList_SelectedIndexChanged);
            // 
            // FlagControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedList);
            this.Controls.Add(this.lbLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FlagControl";
            this.Size = new System.Drawing.Size(450, 95);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbLabel;
        private System.Windows.Forms.CheckedListBox checkedList;
    }
}
