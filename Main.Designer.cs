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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializeToJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.layoutGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageMaterial = new System.Windows.Forms.TabPage();
            this.layoutMaterial = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageEffect = new System.Windows.Forms.TabPage();
            this.layoutEffect = new System.Windows.Forms.TableLayoutPanel();
            this.textureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listVersion = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.listMatType = new System.Windows.Forms.ComboBox();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageMaterial.SuspendLayout();
            this.tabPageEffect.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
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
            this.serializeToJSONToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // serializeToJSONToolStripMenuItem
            // 
            this.serializeToJSONToolStripMenuItem.CheckOnClick = true;
            this.serializeToJSONToolStripMenuItem.Name = "serializeToJSONToolStripMenuItem";
            this.serializeToJSONToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.serializeToJSONToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.serializeToJSONToolStripMenuItem.Text = "Serialize to JSON";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Material/Effect File (.bgsm; .bgem)|*.bgsm;*.bgem";
            this.openFileDialog.Title = "Choose a material file...";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Material/Effect File (.bgsm; .bgem)|*.bgsm;*.bgem";
            this.saveFileDialog.Title = "Save material file to...";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageMaterial);
            this.tabControl.Controls.Add(this.tabPageEffect);
            this.tabControl.Location = new System.Drawing.Point(0, 53);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(624, 531);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.AutoScroll = true;
            this.tabPageGeneral.Controls.Add(this.layoutGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 26);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Size = new System.Drawing.Size(616, 501);
            this.tabPageGeneral.TabIndex = 2;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.ToolTipText = "Affects both BGSM and BGEM files.";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            this.tabPageGeneral.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TabScroll);
            // 
            // layoutGeneral
            // 
            this.layoutGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutGeneral.AutoSize = true;
            this.layoutGeneral.ColumnCount = 1;
            this.layoutGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutGeneral.Location = new System.Drawing.Point(3, 3);
            this.layoutGeneral.Name = "layoutGeneral";
            this.layoutGeneral.RowCount = 1;
            this.layoutGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutGeneral.Size = new System.Drawing.Size(610, 495);
            this.layoutGeneral.TabIndex = 1;
            // 
            // tabPageMaterial
            // 
            this.tabPageMaterial.AutoScroll = true;
            this.tabPageMaterial.Controls.Add(this.layoutMaterial);
            this.tabPageMaterial.Location = new System.Drawing.Point(4, 26);
            this.tabPageMaterial.Name = "tabPageMaterial";
            this.tabPageMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMaterial.Size = new System.Drawing.Size(616, 501);
            this.tabPageMaterial.TabIndex = 0;
            this.tabPageMaterial.Text = "Material";
            this.tabPageMaterial.ToolTipText = "Affects only BGSM files.";
            this.tabPageMaterial.UseVisualStyleBackColor = true;
            this.tabPageMaterial.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TabScroll);
            // 
            // layoutMaterial
            // 
            this.layoutMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutMaterial.AutoSize = true;
            this.layoutMaterial.ColumnCount = 1;
            this.layoutMaterial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutMaterial.Location = new System.Drawing.Point(3, 3);
            this.layoutMaterial.Name = "layoutMaterial";
            this.layoutMaterial.RowCount = 1;
            this.layoutMaterial.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaterial.Size = new System.Drawing.Size(550, 495);
            this.layoutMaterial.TabIndex = 1;
            // 
            // tabPageEffect
            // 
            this.tabPageEffect.AutoScroll = true;
            this.tabPageEffect.Controls.Add(this.layoutEffect);
            this.tabPageEffect.Location = new System.Drawing.Point(4, 26);
            this.tabPageEffect.Name = "tabPageEffect";
            this.tabPageEffect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEffect.Size = new System.Drawing.Size(616, 501);
            this.tabPageEffect.TabIndex = 1;
            this.tabPageEffect.Text = "Effect";
            this.tabPageEffect.ToolTipText = "Affects only BGEM files.";
            this.tabPageEffect.UseVisualStyleBackColor = true;
            this.tabPageEffect.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TabScroll);
            // 
            // layoutEffect
            // 
            this.layoutEffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutEffect.AutoSize = true;
            this.layoutEffect.ColumnCount = 1;
            this.layoutEffect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutEffect.Location = new System.Drawing.Point(3, 3);
            this.layoutEffect.Name = "layoutEffect";
            this.layoutEffect.RowCount = 1;
            this.layoutEffect.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutEffect.Size = new System.Drawing.Size(550, 495);
            this.layoutEffect.TabIndex = 1;
            // 
            // textureFileDialog
            // 
            this.textureFileDialog.DefaultExt = "dds";
            this.textureFileDialog.Filter = "Texture File (.dds)|*.dds";
            this.textureFileDialog.Title = "Choose a texture file...";
            // 
            // listVersion
            // 
            this.listVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listVersion.FormattingEnabled = true;
            this.listVersion.Location = new System.Drawing.Point(7, 26);
            this.listVersion.Name = "listVersion";
            this.listVersion.Size = new System.Drawing.Size(89, 25);
            this.listVersion.TabIndex = 3;
            this.listVersion.SelectedIndexChanged += new System.EventHandler(this.listVersion_SelectedIndexChanged);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Info";
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // listMatType
            // 
            this.listMatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listMatType.FormattingEnabled = true;
            this.listMatType.Items.AddRange(new object[] {
            "Material (*.bgsm)",
            "Effect (*.bgem)"});
            this.listMatType.Location = new System.Drawing.Point(102, 26);
            this.listMatType.Name = "listMatType";
            this.listMatType.Size = new System.Drawing.Size(148, 25);
            this.listMatType.TabIndex = 4;
            this.listMatType.SelectedIndexChanged += new System.EventHandler(this.listMatType_SelectedIndexChanged);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontToolStripMenuItem.Text = "Font...";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(624, 586);
            this.Controls.Add(this.listMatType);
            this.Controls.Add(this.listVersion);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 260);
            this.Name = "Main";
            this.Text = "Material Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Closing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeBegin += new System.EventHandler(this.Main_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageMaterial.ResumeLayout(false);
            this.tabPageMaterial.PerformLayout();
            this.tabPageEffect.ResumeLayout(false);
            this.tabPageEffect.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMaterial;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog textureFileDialog;
        private System.Windows.Forms.ToolStripMenuItem serializeToJSONToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel layoutGeneral;
        private System.Windows.Forms.TabPage tabPageEffect;
        private System.Windows.Forms.TableLayoutPanel layoutEffect;
        private System.Windows.Forms.TableLayoutPanel layoutMaterial;
        private System.Windows.Forms.ComboBox listVersion;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox listMatType;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
    }
}

