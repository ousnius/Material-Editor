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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            serializeToJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            colorDialog = new System.Windows.Forms.ColorDialog();
            tabControl = new System.Windows.Forms.TabControl();
            tabPageGeneral = new System.Windows.Forms.TabPage();
            layoutGeneral = new System.Windows.Forms.TableLayoutPanel();
            tabPageMaterial = new System.Windows.Forms.TabPage();
            layoutMaterial = new System.Windows.Forms.TableLayoutPanel();
            tabPageEffect = new System.Windows.Forms.TabPage();
            layoutEffect = new System.Windows.Forms.TableLayoutPanel();
            textureFileDialog = new System.Windows.Forms.OpenFileDialog();
            listGame = new System.Windows.Forms.ComboBox();
            toolTip = new System.Windows.Forms.ToolTip(components);
            listMatType = new System.Windows.Forms.ComboBox();
            listVersion = new System.Windows.Forms.ComboBox();
            lbVersion = new System.Windows.Forms.Label();
            menuStrip.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            tabPageMaterial.SuspendLayout();
            tabPageEffect.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, toolStripMenuItem1 });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(624, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem, serializeToJSONToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            newToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S;
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W;
            closeToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // serializeToJSONToolStripMenuItem
            // 
            serializeToJSONToolStripMenuItem.CheckOnClick = true;
            serializeToJSONToolStripMenuItem.Name = "serializeToJSONToolStripMenuItem";
            serializeToJSONToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J;
            serializeToJSONToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            serializeToJSONToolStripMenuItem.Text = "Serialize to JSON";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
            exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fontToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            fontToolStripMenuItem.Text = "Font...";
            fontToolStripMenuItem.Click += FontToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Material/Effect File (.bgsm; .bgem)|*.bgsm;*.bgem";
            openFileDialog.Title = "Choose a material file...";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Material/Effect File (.bgsm; .bgem)|*.bgsm;*.bgem";
            saveFileDialog.Title = "Save material file to...";
            // 
            // colorDialog
            // 
            colorDialog.FullOpen = true;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Controls.Add(tabPageMaterial);
            tabControl.Controls.Add(tabPageEffect);
            tabControl.Location = new System.Drawing.Point(0, 53);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new System.Drawing.Size(624, 531);
            tabControl.TabIndex = 2;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.AutoScroll = true;
            tabPageGeneral.Controls.Add(layoutGeneral);
            tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Size = new System.Drawing.Size(616, 503);
            tabPageGeneral.TabIndex = 2;
            tabPageGeneral.Text = "General";
            tabPageGeneral.ToolTipText = "Affects both BGSM and BGEM files.";
            tabPageGeneral.UseVisualStyleBackColor = true;
            tabPageGeneral.Scroll += TabScroll;
            // 
            // layoutGeneral
            // 
            layoutGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            layoutGeneral.AutoSize = true;
            layoutGeneral.ColumnCount = 3;
            layoutGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            layoutGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            layoutGeneral.Location = new System.Drawing.Point(3, 3);
            layoutGeneral.Name = "layoutGeneral";
            layoutGeneral.Size = new System.Drawing.Size(610, 495);
            layoutGeneral.TabIndex = 1;
            // 
            // tabPageMaterial
            // 
            tabPageMaterial.AutoScroll = true;
            tabPageMaterial.Controls.Add(layoutMaterial);
            tabPageMaterial.Location = new System.Drawing.Point(4, 24);
            tabPageMaterial.Name = "tabPageMaterial";
            tabPageMaterial.Padding = new System.Windows.Forms.Padding(3);
            tabPageMaterial.Size = new System.Drawing.Size(616, 503);
            tabPageMaterial.TabIndex = 0;
            tabPageMaterial.Text = "Material";
            tabPageMaterial.ToolTipText = "Affects only BGSM files.";
            tabPageMaterial.UseVisualStyleBackColor = true;
            tabPageMaterial.Scroll += TabScroll;
            // 
            // layoutMaterial
            // 
            layoutMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            layoutMaterial.AutoSize = true;
            layoutMaterial.ColumnCount = 3;
            layoutMaterial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            layoutMaterial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutMaterial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            layoutMaterial.Location = new System.Drawing.Point(3, 3);
            layoutMaterial.Name = "layoutMaterial";
            layoutMaterial.Size = new System.Drawing.Size(610, 495);
            layoutMaterial.TabIndex = 1;
            // 
            // tabPageEffect
            // 
            tabPageEffect.AutoScroll = true;
            tabPageEffect.Controls.Add(layoutEffect);
            tabPageEffect.Location = new System.Drawing.Point(4, 24);
            tabPageEffect.Name = "tabPageEffect";
            tabPageEffect.Padding = new System.Windows.Forms.Padding(3);
            tabPageEffect.Size = new System.Drawing.Size(616, 503);
            tabPageEffect.TabIndex = 1;
            tabPageEffect.Text = "Effect";
            tabPageEffect.ToolTipText = "Affects only BGEM files.";
            tabPageEffect.UseVisualStyleBackColor = true;
            tabPageEffect.Scroll += TabScroll;
            // 
            // layoutEffect
            // 
            layoutEffect.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            layoutEffect.AutoSize = true;
            layoutEffect.ColumnCount = 3;
            layoutEffect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            layoutEffect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutEffect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            layoutEffect.Location = new System.Drawing.Point(3, 3);
            layoutEffect.Name = "layoutEffect";
            layoutEffect.Size = new System.Drawing.Size(610, 495);
            layoutEffect.TabIndex = 1;
            // 
            // textureFileDialog
            // 
            textureFileDialog.DefaultExt = "dds";
            textureFileDialog.Filter = "Texture File (.dds)|*.dds";
            textureFileDialog.Title = "Choose a texture file...";
            // 
            // listGame
            // 
            listGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            listGame.FormattingEnabled = true;
            listGame.Location = new System.Drawing.Point(7, 26);
            listGame.Name = "listGame";
            listGame.Size = new System.Drawing.Size(89, 23);
            listGame.TabIndex = 3;
            listGame.SelectedIndexChanged += ListGame_SelectedIndexChanged;
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip.ToolTipTitle = "Info";
            toolTip.Popup += ToolTip_Popup;
            // 
            // listMatType
            // 
            listMatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            listMatType.FormattingEnabled = true;
            listMatType.Items.AddRange(new object[] { "Material (*.bgsm)", "Effect (*.bgem)" });
            listMatType.Location = new System.Drawing.Point(102, 26);
            listMatType.Name = "listMatType";
            listMatType.Size = new System.Drawing.Size(148, 23);
            listMatType.TabIndex = 4;
            listMatType.SelectedIndexChanged += ListMatType_SelectedIndexChanged;
            // 
            // listVersion
            // 
            listVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            listVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            listVersion.FormattingEnabled = true;
            listVersion.Location = new System.Drawing.Point(547, 26);
            listVersion.Name = "listVersion";
            listVersion.Size = new System.Drawing.Size(65, 23);
            listVersion.TabIndex = 5;
            listVersion.SelectedIndexChanged += ListVersion_SelectedIndexChanged;
            // 
            // lbVersion
            // 
            lbVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbVersion.AutoSize = true;
            lbVersion.Location = new System.Drawing.Point(472, 29);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new System.Drawing.Size(69, 15);
            lbVersion.TabIndex = 6;
            lbVersion.Text = "File Version:";
            // 
            // Main
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(624, 586);
            Controls.Add(lbVersion);
            Controls.Add(listVersion);
            Controls.Add(listMatType);
            Controls.Add(listGame);
            Controls.Add(tabControl);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new System.Drawing.Size(640, 260);
            Name = "Main";
            Text = "Material Editor";
            FormClosing += Main_Closing;
            Load += Main_Load;
            ResizeBegin += Main_ResizeBegin;
            ResizeEnd += Main_ResizeEnd;
            DragDrop += Main_DragDrop;
            DragEnter += Main_DragEnter;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            tabPageGeneral.PerformLayout();
            tabPageMaterial.ResumeLayout(false);
            tabPageMaterial.PerformLayout();
            tabPageEffect.ResumeLayout(false);
            tabPageEffect.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ComboBox listGame;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox listMatType;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ComboBox listVersion;
        private System.Windows.Forms.Label lbVersion;
    }
}

