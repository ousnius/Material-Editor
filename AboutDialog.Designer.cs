namespace Material_Editor
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.aboutText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // aboutText
            // 
            this.aboutText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutText.BackColor = System.Drawing.SystemColors.Window;
            this.aboutText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutText.Location = new System.Drawing.Point(13, 13);
            this.aboutText.Name = "aboutText";
            this.aboutText.ReadOnly = true;
            this.aboutText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.aboutText.Size = new System.Drawing.Size(278, 53);
            this.aboutText.TabIndex = 0;
            this.aboutText.Text = "MATERIAL EDITOR\nby ousnius\nhttps://github.com/ousnius/Material-Editor";
            this.aboutText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.AboutText_LinkClicked);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(303, 78);
            this.Controls.Add(this.aboutText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox aboutText;
    }
}