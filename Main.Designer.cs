namespace Material_Editor
{
    partial class Main
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btColor1 = new System.Windows.Forms.Button();
            this.lbColor1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbColor2 = new System.Windows.Forms.Label();
            this.btColor2 = new System.Windows.Forms.Button();
            this.lbSpecularStrength = new System.Windows.Forms.Label();
            this.numSpecularStrength = new System.Windows.Forms.NumericUpDown();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecularStrength)).BeginInit();
            this.tablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(434, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Shader Material|*.bgsm";
            this.openFileDialog.Title = "Choose a material file...";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Shader Material|*.bgsm";
            this.saveFileDialog.Title = "Save material file to...";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // btColor1
            // 
            this.btColor1.BackColor = System.Drawing.Color.Black;
            this.btColor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btColor1.Location = new System.Drawing.Point(140, 4);
            this.btColor1.Name = "btColor1";
            this.btColor1.Size = new System.Drawing.Size(266, 24);
            this.btColor1.TabIndex = 3;
            this.btColor1.UseVisualStyleBackColor = false;
            this.btColor1.Click += new System.EventHandler(this.btColor1_Click);
            // 
            // lbColor1
            // 
            this.lbColor1.AutoSize = true;
            this.lbColor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbColor1.Location = new System.Drawing.Point(4, 1);
            this.lbColor1.Name = "lbColor1";
            this.lbColor1.Size = new System.Drawing.Size(129, 30);
            this.lbColor1.TabIndex = 2;
            this.lbColor1.Text = "Unknown Color 1";
            this.lbColor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel.Controls.Add(this.lbSpecularStrength, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btColor2, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lbColor2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btColor1, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lbColor1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.numSpecularStrength, 1, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(410, 218);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // lbColor2
            // 
            this.lbColor2.AutoSize = true;
            this.lbColor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbColor2.Location = new System.Drawing.Point(4, 32);
            this.lbColor2.Name = "lbColor2";
            this.lbColor2.Size = new System.Drawing.Size(129, 30);
            this.lbColor2.TabIndex = 4;
            this.lbColor2.Text = "Unknown Color 2";
            this.lbColor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btColor2
            // 
            this.btColor2.BackColor = System.Drawing.Color.Black;
            this.btColor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btColor2.Location = new System.Drawing.Point(140, 35);
            this.btColor2.Name = "btColor2";
            this.btColor2.Size = new System.Drawing.Size(266, 24);
            this.btColor2.TabIndex = 5;
            this.btColor2.UseVisualStyleBackColor = false;
            this.btColor2.Click += new System.EventHandler(this.btColor2_Click);
            // 
            // lbSpecularStrength
            // 
            this.lbSpecularStrength.AutoSize = true;
            this.lbSpecularStrength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSpecularStrength.Location = new System.Drawing.Point(4, 63);
            this.lbSpecularStrength.Name = "lbSpecularStrength";
            this.lbSpecularStrength.Size = new System.Drawing.Size(129, 30);
            this.lbSpecularStrength.TabIndex = 6;
            this.lbSpecularStrength.Text = "Specular Strength";
            this.lbSpecularStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSpecularStrength
            // 
            this.numSpecularStrength.AutoSize = true;
            this.numSpecularStrength.DecimalPlaces = 5;
            this.numSpecularStrength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSpecularStrength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSpecularStrength.Location = new System.Drawing.Point(140, 66);
            this.numSpecularStrength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSpecularStrength.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numSpecularStrength.Name = "numSpecularStrength";
            this.numSpecularStrength.Size = new System.Drawing.Size(266, 20);
            this.numSpecularStrength.TabIndex = 7;
            this.numSpecularStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tablePanel
            // 
            this.tablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel.AutoScroll = true;
            this.tablePanel.Controls.Add(this.tableLayoutPanel);
            this.tablePanel.Location = new System.Drawing.Point(0, 27);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(434, 229);
            this.tablePanel.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 255);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "Main";
            this.Text = "Material Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecularStrength)).EndInit();
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btColor1;
        private System.Windows.Forms.Label lbColor1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btColor2;
        private System.Windows.Forms.Label lbColor2;
        private System.Windows.Forms.Label lbSpecularStrength;
        private System.Windows.Forms.NumericUpDown numSpecularStrength;
        private System.Windows.Forms.Panel tablePanel;

    }
}

