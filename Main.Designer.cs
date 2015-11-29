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
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.splitContainerGeneral = new System.Windows.Forms.SplitContainer();
            this.lbGrayscaleToPaletteColor = new System.Windows.Forms.Label();
            this.lbEnvironmentMaskScale = new System.Windows.Forms.Label();
            this.lbEnvironmentMapping = new System.Windows.Forms.Label();
            this.lbRefractionPower = new System.Windows.Forms.Label();
            this.lbRefractionFalloff = new System.Windows.Forms.Label();
            this.lbRefraction = new System.Windows.Forms.Label();
            this.lbNonOccluder = new System.Windows.Forms.Label();
            this.lbDecalNoFade = new System.Windows.Forms.Label();
            this.lbTwoSided = new System.Windows.Forms.Label();
            this.lbDecal = new System.Windows.Forms.Label();
            this.lbWetnessControlSSR = new System.Windows.Forms.Label();
            this.lbScreenSpaceReflections = new System.Windows.Forms.Label();
            this.lbZBufferTest = new System.Windows.Forms.Label();
            this.lbZBufferWrite = new System.Windows.Forms.Label();
            this.lbAlphaTest = new System.Windows.Forms.Label();
            this.lbAlphaTestReference = new System.Windows.Forms.Label();
            this.lbAlphaBlendMode = new System.Windows.Forms.Label();
            this.lbAlpha = new System.Windows.Forms.Label();
            this.lbScaleV = new System.Windows.Forms.Label();
            this.lbScaleU = new System.Windows.Forms.Label();
            this.lbOffsetV = new System.Windows.Forms.Label();
            this.lbOffsetU = new System.Windows.Forms.Label();
            this.lbTileV = new System.Windows.Forms.Label();
            this.lbTileU = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.cbGrayscaleToPaletteColor = new System.Windows.Forms.CheckBox();
            this.numEnvironmentMaskScale = new System.Windows.Forms.NumericUpDown();
            this.cbEnvironmentMapping = new System.Windows.Forms.CheckBox();
            this.numRefractionPower = new System.Windows.Forms.NumericUpDown();
            this.cbRefractionFalloff = new System.Windows.Forms.CheckBox();
            this.cbRefraction = new System.Windows.Forms.CheckBox();
            this.cbNonOccluder = new System.Windows.Forms.CheckBox();
            this.cbDecalNoFade = new System.Windows.Forms.CheckBox();
            this.cbTwoSided = new System.Windows.Forms.CheckBox();
            this.cbDecal = new System.Windows.Forms.CheckBox();
            this.cbWetnessControlSSR = new System.Windows.Forms.CheckBox();
            this.cbScreenSpaceReflections = new System.Windows.Forms.CheckBox();
            this.cbZBufferTest = new System.Windows.Forms.CheckBox();
            this.cbZBufferWrite = new System.Windows.Forms.CheckBox();
            this.cbAlphaTest = new System.Windows.Forms.CheckBox();
            this.numAlphaTestReference = new System.Windows.Forms.NumericUpDown();
            this.selAlphaBlendMode = new System.Windows.Forms.ComboBox();
            this.numAlpha = new System.Windows.Forms.NumericUpDown();
            this.numScaleV = new System.Windows.Forms.NumericUpDown();
            this.numScaleU = new System.Windows.Forms.NumericUpDown();
            this.numOffsetV = new System.Windows.Forms.NumericUpDown();
            this.numOffsetU = new System.Windows.Forms.NumericUpDown();
            this.cbTileV = new System.Windows.Forms.CheckBox();
            this.cbTileU = new System.Windows.Forms.CheckBox();
            this.numVersion = new System.Windows.Forms.NumericUpDown();
            this.tabPageMaterial = new System.Windows.Forms.TabPage();
            this.splitContainerMaterial = new System.Windows.Forms.SplitContainer();
            this.lbSkewSpecularAlpha = new System.Windows.Forms.Label();
            this.lbGrayscaleToPaletteScale = new System.Windows.Forms.Label();
            this.lbTessellationFadeDistance = new System.Windows.Forms.Label();
            this.lbTessellationBaseFactor = new System.Windows.Forms.Label();
            this.lbTessellationPNScale = new System.Windows.Forms.Label();
            this.lbDisplacementTexScale = new System.Windows.Forms.Label();
            this.lbDisplacementTexBias = new System.Windows.Forms.Label();
            this.lbTessellate = new System.Windows.Forms.Label();
            this.lbSkinTint = new System.Windows.Forms.Label();
            this.lbFacegen = new System.Windows.Forms.Label();
            this.lbTree = new System.Windows.Forms.Label();
            this.lbHairTintColor = new System.Windows.Forms.Label();
            this.lbHair = new System.Windows.Forms.Label();
            this.lbEnvironmentMapEye = new System.Windows.Forms.Label();
            this.lbEnvironmentMapWindow = new System.Windows.Forms.Label();
            this.lbGlowmap = new System.Windows.Forms.Label();
            this.lbAssumeShadowmask = new System.Windows.Forms.Label();
            this.lbDissolveFade = new System.Windows.Forms.Label();
            this.lbCastShadows = new System.Windows.Forms.Label();
            this.lbHideSecret = new System.Windows.Forms.Label();
            this.lbReceiveShadows = new System.Windows.Forms.Label();
            this.lbBackLighting = new System.Windows.Forms.Label();
            this.lbExternalEmittance = new System.Windows.Forms.Label();
            this.lbModelSpaceNormals = new System.Windows.Forms.Label();
            this.lbEmittanceMultiplier = new System.Windows.Forms.Label();
            this.lbEmittanceColor = new System.Windows.Forms.Label();
            this.lbEmittanceEnabled = new System.Windows.Forms.Label();
            this.lbAnisoLighting = new System.Windows.Forms.Label();
            this.lbRootMaterialPath = new System.Windows.Forms.Label();
            this.lbWetMetalness = new System.Windows.Forms.Label();
            this.lbWetFresnelPower = new System.Windows.Forms.Label();
            this.lbWetEnvMapScale = new System.Windows.Forms.Label();
            this.lbWetSpecMinVar = new System.Windows.Forms.Label();
            this.lbWetSpecPowerScale = new System.Windows.Forms.Label();
            this.lbWetSpecScale = new System.Windows.Forms.Label();
            this.lbFresnelPower = new System.Windows.Forms.Label();
            this.lbSmoothness = new System.Windows.Forms.Label();
            this.lbSpecularMult = new System.Windows.Forms.Label();
            this.lbSpecularColor = new System.Windows.Forms.Label();
            this.lbSpecularEnabled = new System.Windows.Forms.Label();
            this.lbSubsurfaceLightingRolloff = new System.Windows.Forms.Label();
            this.lbSubsurfaceLighting = new System.Windows.Forms.Label();
            this.lbBacklightPower = new System.Windows.Forms.Label();
            this.lbRimPower = new System.Windows.Forms.Label();
            this.lbRimLighting = new System.Windows.Forms.Label();
            this.lbEnableEditorAlphaRef = new System.Windows.Forms.Label();
            this.lbDisplacementTexture = new System.Windows.Forms.Label();
            this.lbWrinklesTexture = new System.Windows.Forms.Label();
            this.lbInnerLayerTexture = new System.Windows.Forms.Label();
            this.lbGlowTexture = new System.Windows.Forms.Label();
            this.lbEnvironmentMapTexture = new System.Windows.Forms.Label();
            this.lbGreyscaleTexture = new System.Windows.Forms.Label();
            this.lbSmoothSpecularTexture = new System.Windows.Forms.Label();
            this.lbNormalTexture = new System.Windows.Forms.Label();
            this.lbDiffuseTexture = new System.Windows.Forms.Label();
            this.cbSkewSpecularAlpha = new System.Windows.Forms.CheckBox();
            this.numGrayscaleToPaletteScale = new System.Windows.Forms.NumericUpDown();
            this.numTessellationFadeDistance = new System.Windows.Forms.NumericUpDown();
            this.numTessellationBaseFactor = new System.Windows.Forms.NumericUpDown();
            this.numTessellationPNScale = new System.Windows.Forms.NumericUpDown();
            this.numDisplacementTexScale = new System.Windows.Forms.NumericUpDown();
            this.numDisplacementTexBias = new System.Windows.Forms.NumericUpDown();
            this.cbTessellate = new System.Windows.Forms.CheckBox();
            this.cbSkinTint = new System.Windows.Forms.CheckBox();
            this.cbFacegen = new System.Windows.Forms.CheckBox();
            this.cbTree = new System.Windows.Forms.CheckBox();
            this.btHairTintColor = new System.Windows.Forms.Button();
            this.cbHair = new System.Windows.Forms.CheckBox();
            this.cbEnvironmentMapEye = new System.Windows.Forms.CheckBox();
            this.cbEnvironmentMapWindow = new System.Windows.Forms.CheckBox();
            this.cbGlowmap = new System.Windows.Forms.CheckBox();
            this.cbAssumeShadowmask = new System.Windows.Forms.CheckBox();
            this.cbDissolveFade = new System.Windows.Forms.CheckBox();
            this.cbCastShadows = new System.Windows.Forms.CheckBox();
            this.cbHideSecret = new System.Windows.Forms.CheckBox();
            this.cbReceiveShadows = new System.Windows.Forms.CheckBox();
            this.cbBackLighting = new System.Windows.Forms.CheckBox();
            this.cbExternalEmittance = new System.Windows.Forms.CheckBox();
            this.cbModelSpaceNormals = new System.Windows.Forms.CheckBox();
            this.numEmittanceMultiplier = new System.Windows.Forms.NumericUpDown();
            this.btEmittanceColor = new System.Windows.Forms.Button();
            this.cbEmittanceEnabled = new System.Windows.Forms.CheckBox();
            this.cbAnisoLighting = new System.Windows.Forms.CheckBox();
            this.tbRootMaterialPath = new System.Windows.Forms.TextBox();
            this.numWetMetalness = new System.Windows.Forms.NumericUpDown();
            this.numWetFresnelPower = new System.Windows.Forms.NumericUpDown();
            this.numWetEnvMapScale = new System.Windows.Forms.NumericUpDown();
            this.numWetSpecMinVar = new System.Windows.Forms.NumericUpDown();
            this.numWetSpecPowerScale = new System.Windows.Forms.NumericUpDown();
            this.numWetSpecScale = new System.Windows.Forms.NumericUpDown();
            this.numFresnelPower = new System.Windows.Forms.NumericUpDown();
            this.numSmoothness = new System.Windows.Forms.NumericUpDown();
            this.numSpecularMultiplier = new System.Windows.Forms.NumericUpDown();
            this.btSpecularColor = new System.Windows.Forms.Button();
            this.cbSpecularEnabled = new System.Windows.Forms.CheckBox();
            this.numSubsurfaceLightingRolloff = new System.Windows.Forms.NumericUpDown();
            this.cbSubsurfaceLighting = new System.Windows.Forms.CheckBox();
            this.numBacklightPower = new System.Windows.Forms.NumericUpDown();
            this.cbRimLighting = new System.Windows.Forms.CheckBox();
            this.tbDisplacementTexture = new System.Windows.Forms.TextBox();
            this.tbWrinklesTexture = new System.Windows.Forms.TextBox();
            this.tbInnerLayerTexture = new System.Windows.Forms.TextBox();
            this.tbGlowTexture = new System.Windows.Forms.TextBox();
            this.tbEnvironmentMapTexture = new System.Windows.Forms.TextBox();
            this.tbGreyscaleTexture = new System.Windows.Forms.TextBox();
            this.tbSmoothSpecularTexture = new System.Windows.Forms.TextBox();
            this.tbNormalTexture = new System.Windows.Forms.TextBox();
            this.tbDiffuseTexture = new System.Windows.Forms.TextBox();
            this.numRimPower = new System.Windows.Forms.NumericUpDown();
            this.cbEnableEditorAlphaRef = new System.Windows.Forms.CheckBox();
            this.tabPageEffect = new System.Windows.Forms.TabPage();
            this.splitContainerEffect = new System.Windows.Forms.SplitContainer();
            this.lbSoftDepth = new System.Windows.Forms.Label();
            this.lbEnvmapMinLOD = new System.Windows.Forms.Label();
            this.lbLightingInfluence = new System.Windows.Forms.Label();
            this.lbFalloffStopOpacity = new System.Windows.Forms.Label();
            this.lbFalloffStartOpacity = new System.Windows.Forms.Label();
            this.lbFalloffStopAngle = new System.Windows.Forms.Label();
            this.lbFalloffStartAngle = new System.Windows.Forms.Label();
            this.lbBaseColorScale = new System.Windows.Forms.Label();
            this.lbBaseColor = new System.Windows.Forms.Label();
            this.lbSoftEnabled = new System.Windows.Forms.Label();
            this.lbGrayscaleToPaletteAlpha = new System.Windows.Forms.Label();
            this.lbFalloffColorEnabled = new System.Windows.Forms.Label();
            this.lbFalloffEnabled = new System.Windows.Forms.Label();
            this.lbEffectLightingEnabled = new System.Windows.Forms.Label();
            this.lbBloodEnabled = new System.Windows.Forms.Label();
            this.lbEnvmapMaskTexture = new System.Windows.Forms.Label();
            this.lbNormalTexture_effect = new System.Windows.Forms.Label();
            this.lbEnvmapTexture = new System.Windows.Forms.Label();
            this.lbGrayscaleTexture = new System.Windows.Forms.Label();
            this.lbBaseTexture = new System.Windows.Forms.Label();
            this.numSoftDepth = new System.Windows.Forms.NumericUpDown();
            this.numLightingInfluence = new System.Windows.Forms.NumericUpDown();
            this.numFalloffStopOpacity = new System.Windows.Forms.NumericUpDown();
            this.numFalloffStartOpacity = new System.Windows.Forms.NumericUpDown();
            this.numFalloffStopAngle = new System.Windows.Forms.NumericUpDown();
            this.numFalloffStartAngle = new System.Windows.Forms.NumericUpDown();
            this.btBaseColor = new System.Windows.Forms.Button();
            this.cbSoftEnabled = new System.Windows.Forms.CheckBox();
            this.cbGrayscaleToPaletteAlpha = new System.Windows.Forms.CheckBox();
            this.cbFalloffColorEnabled = new System.Windows.Forms.CheckBox();
            this.cbFalloffEnabled = new System.Windows.Forms.CheckBox();
            this.cbEffectLightingEnabled = new System.Windows.Forms.CheckBox();
            this.tbEnvmapMaskTexture = new System.Windows.Forms.TextBox();
            this.tbNormalTexture_effect = new System.Windows.Forms.TextBox();
            this.tbEnvmapTexture = new System.Windows.Forms.TextBox();
            this.tbGrayscaleTexture = new System.Windows.Forms.TextBox();
            this.tbBaseTexture = new System.Windows.Forms.TextBox();
            this.cbBloodEnabled = new System.Windows.Forms.CheckBox();
            this.numEnvmapMinLOD = new System.Windows.Forms.NumericUpDown();
            this.numBaseColorScale = new System.Windows.Forms.NumericUpDown();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneral)).BeginInit();
            this.splitContainerGeneral.Panel1.SuspendLayout();
            this.splitContainerGeneral.Panel2.SuspendLayout();
            this.splitContainerGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnvironmentMaskScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefractionPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlphaTestReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).BeginInit();
            this.tabPageMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMaterial)).BeginInit();
            this.splitContainerMaterial.Panel1.SuspendLayout();
            this.splitContainerMaterial.Panel2.SuspendLayout();
            this.splitContainerMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrayscaleToPaletteScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTessellationFadeDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTessellationBaseFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTessellationPNScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplacementTexScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplacementTexBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEmittanceMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetMetalness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetFresnelPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetEnvMapScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetSpecMinVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetSpecPowerScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetSpecScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFresnelPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSmoothness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecularMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubsurfaceLightingRolloff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBacklightPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRimPower)).BeginInit();
            this.tabPageEffect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEffect)).BeginInit();
            this.splitContainerEffect.Panel1.SuspendLayout();
            this.splitContainerEffect.Panel2.SuspendLayout();
            this.splitContainerEffect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoftDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLightingInfluence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStopOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStartOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStopAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnvmapMinLOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseColorScale)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 24);
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
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
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
            this.openFileDialog.Filter = "Material (.bgsm)|*.bgsm|Effect (.bgem)|*.bgem|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Choose a material file...";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Material (.bgsm)|*.bgsm|Effect (.bgem)|*.bgem";
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
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 533);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.AutoScroll = true;
            this.tabPageGeneral.Controls.Add(this.splitContainerGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Size = new System.Drawing.Size(476, 507);
            this.tabPageGeneral.TabIndex = 2;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            this.tabPageGeneral.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TabScroll);
            // 
            // splitContainerGeneral
            // 
            this.splitContainerGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerGeneral.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerGeneral.IsSplitterFixed = true;
            this.splitContainerGeneral.Location = new System.Drawing.Point(4, 4);
            this.splitContainerGeneral.Name = "splitContainerGeneral";
            // 
            // splitContainerGeneral.Panel1
            // 
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbGrayscaleToPaletteColor);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbEnvironmentMaskScale);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbEnvironmentMapping);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbRefractionPower);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbRefractionFalloff);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbRefraction);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbNonOccluder);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbDecalNoFade);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbTwoSided);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbDecal);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbWetnessControlSSR);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbScreenSpaceReflections);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbZBufferTest);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbZBufferWrite);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbAlphaTest);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbAlphaTestReference);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbAlphaBlendMode);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbAlpha);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbScaleV);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbScaleU);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbOffsetV);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbOffsetU);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbTileV);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbTileU);
            this.splitContainerGeneral.Panel1.Controls.Add(this.lbVersion);
            this.splitContainerGeneral.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerGeneral.Panel1MinSize = 165;
            // 
            // splitContainerGeneral.Panel2
            // 
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbGrayscaleToPaletteColor);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numEnvironmentMaskScale);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbEnvironmentMapping);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numRefractionPower);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbRefractionFalloff);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbRefraction);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbNonOccluder);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbDecalNoFade);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbTwoSided);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbDecal);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbWetnessControlSSR);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbScreenSpaceReflections);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbZBufferTest);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbZBufferWrite);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbAlphaTest);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numAlphaTestReference);
            this.splitContainerGeneral.Panel2.Controls.Add(this.selAlphaBlendMode);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numAlpha);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numScaleV);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numScaleU);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numOffsetV);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numOffsetU);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbTileV);
            this.splitContainerGeneral.Panel2.Controls.Add(this.cbTileU);
            this.splitContainerGeneral.Panel2.Controls.Add(this.numVersion);
            this.splitContainerGeneral.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerGeneral.Panel2MinSize = 165;
            this.splitContainerGeneral.Size = new System.Drawing.Size(469, 492);
            this.splitContainerGeneral.SplitterDistance = 165;
            this.splitContainerGeneral.TabIndex = 1;
            // 
            // lbGrayscaleToPaletteColor
            // 
            this.lbGrayscaleToPaletteColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGrayscaleToPaletteColor.Location = new System.Drawing.Point(13, 469);
            this.lbGrayscaleToPaletteColor.Margin = new System.Windows.Forms.Padding(3);
            this.lbGrayscaleToPaletteColor.Name = "lbGrayscaleToPaletteColor";
            this.lbGrayscaleToPaletteColor.Size = new System.Drawing.Size(135, 13);
            this.lbGrayscaleToPaletteColor.TabIndex = 24;
            this.lbGrayscaleToPaletteColor.Text = "Grayscale To Palette Color";
            // 
            // lbEnvironmentMaskScale
            // 
            this.lbEnvironmentMaskScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvironmentMaskScale.Location = new System.Drawing.Point(13, 450);
            this.lbEnvironmentMaskScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvironmentMaskScale.Name = "lbEnvironmentMaskScale";
            this.lbEnvironmentMaskScale.Size = new System.Drawing.Size(135, 13);
            this.lbEnvironmentMaskScale.TabIndex = 23;
            this.lbEnvironmentMaskScale.Text = "Environment Mask Scale";
            // 
            // lbEnvironmentMapping
            // 
            this.lbEnvironmentMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvironmentMapping.Location = new System.Drawing.Point(13, 431);
            this.lbEnvironmentMapping.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvironmentMapping.Name = "lbEnvironmentMapping";
            this.lbEnvironmentMapping.Size = new System.Drawing.Size(135, 13);
            this.lbEnvironmentMapping.TabIndex = 22;
            this.lbEnvironmentMapping.Text = "Environment Mapping";
            // 
            // lbRefractionPower
            // 
            this.lbRefractionPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRefractionPower.Location = new System.Drawing.Point(13, 412);
            this.lbRefractionPower.Margin = new System.Windows.Forms.Padding(3);
            this.lbRefractionPower.Name = "lbRefractionPower";
            this.lbRefractionPower.Size = new System.Drawing.Size(135, 13);
            this.lbRefractionPower.TabIndex = 21;
            this.lbRefractionPower.Text = "Refraction Power";
            // 
            // lbRefractionFalloff
            // 
            this.lbRefractionFalloff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRefractionFalloff.Location = new System.Drawing.Point(13, 393);
            this.lbRefractionFalloff.Margin = new System.Windows.Forms.Padding(3);
            this.lbRefractionFalloff.Name = "lbRefractionFalloff";
            this.lbRefractionFalloff.Size = new System.Drawing.Size(135, 13);
            this.lbRefractionFalloff.TabIndex = 20;
            this.lbRefractionFalloff.Text = "Refraction Falloff";
            // 
            // lbRefraction
            // 
            this.lbRefraction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRefraction.Location = new System.Drawing.Point(13, 374);
            this.lbRefraction.Margin = new System.Windows.Forms.Padding(3);
            this.lbRefraction.Name = "lbRefraction";
            this.lbRefraction.Size = new System.Drawing.Size(135, 13);
            this.lbRefraction.TabIndex = 19;
            this.lbRefraction.Text = "Refraction";
            // 
            // lbNonOccluder
            // 
            this.lbNonOccluder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNonOccluder.Location = new System.Drawing.Point(13, 355);
            this.lbNonOccluder.Margin = new System.Windows.Forms.Padding(3);
            this.lbNonOccluder.Name = "lbNonOccluder";
            this.lbNonOccluder.Size = new System.Drawing.Size(135, 13);
            this.lbNonOccluder.TabIndex = 18;
            this.lbNonOccluder.Text = "Non Occluder";
            // 
            // lbDecalNoFade
            // 
            this.lbDecalNoFade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDecalNoFade.Location = new System.Drawing.Point(13, 336);
            this.lbDecalNoFade.Margin = new System.Windows.Forms.Padding(3);
            this.lbDecalNoFade.Name = "lbDecalNoFade";
            this.lbDecalNoFade.Size = new System.Drawing.Size(135, 13);
            this.lbDecalNoFade.TabIndex = 17;
            this.lbDecalNoFade.Text = "Decal No Fade";
            // 
            // lbTwoSided
            // 
            this.lbTwoSided.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTwoSided.Location = new System.Drawing.Point(13, 317);
            this.lbTwoSided.Margin = new System.Windows.Forms.Padding(3);
            this.lbTwoSided.Name = "lbTwoSided";
            this.lbTwoSided.Size = new System.Drawing.Size(135, 13);
            this.lbTwoSided.TabIndex = 16;
            this.lbTwoSided.Text = "Two Sided";
            // 
            // lbDecal
            // 
            this.lbDecal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDecal.Location = new System.Drawing.Point(13, 298);
            this.lbDecal.Margin = new System.Windows.Forms.Padding(3);
            this.lbDecal.Name = "lbDecal";
            this.lbDecal.Size = new System.Drawing.Size(135, 13);
            this.lbDecal.TabIndex = 15;
            this.lbDecal.Text = "Decal";
            // 
            // lbWetnessControlSSR
            // 
            this.lbWetnessControlSSR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetnessControlSSR.Location = new System.Drawing.Point(13, 279);
            this.lbWetnessControlSSR.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetnessControlSSR.Name = "lbWetnessControlSSR";
            this.lbWetnessControlSSR.Size = new System.Drawing.Size(135, 13);
            this.lbWetnessControlSSR.TabIndex = 14;
            this.lbWetnessControlSSR.Text = "Wetness Control SSR";
            // 
            // lbScreenSpaceReflections
            // 
            this.lbScreenSpaceReflections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScreenSpaceReflections.Location = new System.Drawing.Point(13, 260);
            this.lbScreenSpaceReflections.Margin = new System.Windows.Forms.Padding(3);
            this.lbScreenSpaceReflections.Name = "lbScreenSpaceReflections";
            this.lbScreenSpaceReflections.Size = new System.Drawing.Size(135, 13);
            this.lbScreenSpaceReflections.TabIndex = 13;
            this.lbScreenSpaceReflections.Text = "Screen Space Reflections";
            // 
            // lbZBufferTest
            // 
            this.lbZBufferTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbZBufferTest.Location = new System.Drawing.Point(13, 241);
            this.lbZBufferTest.Margin = new System.Windows.Forms.Padding(3);
            this.lbZBufferTest.Name = "lbZBufferTest";
            this.lbZBufferTest.Size = new System.Drawing.Size(135, 13);
            this.lbZBufferTest.TabIndex = 12;
            this.lbZBufferTest.Text = "Z Buffer Test";
            // 
            // lbZBufferWrite
            // 
            this.lbZBufferWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbZBufferWrite.Location = new System.Drawing.Point(13, 222);
            this.lbZBufferWrite.Margin = new System.Windows.Forms.Padding(3);
            this.lbZBufferWrite.Name = "lbZBufferWrite";
            this.lbZBufferWrite.Size = new System.Drawing.Size(135, 13);
            this.lbZBufferWrite.TabIndex = 11;
            this.lbZBufferWrite.Text = "Z Buffer Write";
            // 
            // lbAlphaTest
            // 
            this.lbAlphaTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlphaTest.Location = new System.Drawing.Point(13, 203);
            this.lbAlphaTest.Margin = new System.Windows.Forms.Padding(3);
            this.lbAlphaTest.Name = "lbAlphaTest";
            this.lbAlphaTest.Size = new System.Drawing.Size(135, 13);
            this.lbAlphaTest.TabIndex = 10;
            this.lbAlphaTest.Text = "Alpha Test";
            // 
            // lbAlphaTestReference
            // 
            this.lbAlphaTestReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlphaTestReference.Location = new System.Drawing.Point(13, 184);
            this.lbAlphaTestReference.Margin = new System.Windows.Forms.Padding(3);
            this.lbAlphaTestReference.Name = "lbAlphaTestReference";
            this.lbAlphaTestReference.Size = new System.Drawing.Size(135, 13);
            this.lbAlphaTestReference.TabIndex = 9;
            this.lbAlphaTestReference.Text = "Alpha Test Reference";
            // 
            // lbAlphaBlendMode
            // 
            this.lbAlphaBlendMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlphaBlendMode.Location = new System.Drawing.Point(13, 165);
            this.lbAlphaBlendMode.Margin = new System.Windows.Forms.Padding(3);
            this.lbAlphaBlendMode.Name = "lbAlphaBlendMode";
            this.lbAlphaBlendMode.Size = new System.Drawing.Size(135, 13);
            this.lbAlphaBlendMode.TabIndex = 8;
            this.lbAlphaBlendMode.Text = "Alpha Blend Mode";
            // 
            // lbAlpha
            // 
            this.lbAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlpha.Location = new System.Drawing.Point(13, 146);
            this.lbAlpha.Margin = new System.Windows.Forms.Padding(3);
            this.lbAlpha.Name = "lbAlpha";
            this.lbAlpha.Size = new System.Drawing.Size(135, 13);
            this.lbAlpha.TabIndex = 7;
            this.lbAlpha.Text = "Alpha";
            // 
            // lbScaleV
            // 
            this.lbScaleV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScaleV.Location = new System.Drawing.Point(13, 127);
            this.lbScaleV.Margin = new System.Windows.Forms.Padding(3);
            this.lbScaleV.Name = "lbScaleV";
            this.lbScaleV.Size = new System.Drawing.Size(135, 13);
            this.lbScaleV.TabIndex = 6;
            this.lbScaleV.Text = "Scale V";
            // 
            // lbScaleU
            // 
            this.lbScaleU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScaleU.Location = new System.Drawing.Point(13, 108);
            this.lbScaleU.Margin = new System.Windows.Forms.Padding(3);
            this.lbScaleU.Name = "lbScaleU";
            this.lbScaleU.Size = new System.Drawing.Size(135, 13);
            this.lbScaleU.TabIndex = 5;
            this.lbScaleU.Text = "Scale U";
            // 
            // lbOffsetV
            // 
            this.lbOffsetV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOffsetV.Location = new System.Drawing.Point(13, 89);
            this.lbOffsetV.Margin = new System.Windows.Forms.Padding(3);
            this.lbOffsetV.Name = "lbOffsetV";
            this.lbOffsetV.Size = new System.Drawing.Size(135, 13);
            this.lbOffsetV.TabIndex = 4;
            this.lbOffsetV.Text = "Offset V";
            // 
            // lbOffsetU
            // 
            this.lbOffsetU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOffsetU.Location = new System.Drawing.Point(13, 70);
            this.lbOffsetU.Margin = new System.Windows.Forms.Padding(3);
            this.lbOffsetU.Name = "lbOffsetU";
            this.lbOffsetU.Size = new System.Drawing.Size(135, 13);
            this.lbOffsetU.TabIndex = 3;
            this.lbOffsetU.Text = "Offset U";
            // 
            // lbTileV
            // 
            this.lbTileV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTileV.Location = new System.Drawing.Point(13, 51);
            this.lbTileV.Margin = new System.Windows.Forms.Padding(3);
            this.lbTileV.Name = "lbTileV";
            this.lbTileV.Size = new System.Drawing.Size(135, 13);
            this.lbTileV.TabIndex = 2;
            this.lbTileV.Text = "Tile V";
            // 
            // lbTileU
            // 
            this.lbTileU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTileU.Location = new System.Drawing.Point(13, 32);
            this.lbTileU.Margin = new System.Windows.Forms.Padding(3);
            this.lbTileU.Name = "lbTileU";
            this.lbTileU.Size = new System.Drawing.Size(135, 13);
            this.lbTileU.TabIndex = 1;
            this.lbTileU.Text = "Tile U";
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersion.Location = new System.Drawing.Point(13, 13);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(3);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(135, 13);
            this.lbVersion.TabIndex = 0;
            this.lbVersion.Text = "Version";
            // 
            // cbGrayscaleToPaletteColor
            // 
            this.cbGrayscaleToPaletteColor.Location = new System.Drawing.Point(13, 470);
            this.cbGrayscaleToPaletteColor.Name = "cbGrayscaleToPaletteColor";
            this.cbGrayscaleToPaletteColor.Size = new System.Drawing.Size(100, 13);
            this.cbGrayscaleToPaletteColor.TabIndex = 24;
            this.cbGrayscaleToPaletteColor.UseVisualStyleBackColor = true;
            // 
            // numEnvironmentMaskScale
            // 
            this.numEnvironmentMaskScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numEnvironmentMaskScale.DecimalPlaces = 5;
            this.numEnvironmentMaskScale.Location = new System.Drawing.Point(13, 448);
            this.numEnvironmentMaskScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numEnvironmentMaskScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numEnvironmentMaskScale.Name = "numEnvironmentMaskScale";
            this.numEnvironmentMaskScale.Size = new System.Drawing.Size(272, 20);
            this.numEnvironmentMaskScale.TabIndex = 23;
            // 
            // cbEnvironmentMapping
            // 
            this.cbEnvironmentMapping.Location = new System.Drawing.Point(13, 432);
            this.cbEnvironmentMapping.Name = "cbEnvironmentMapping";
            this.cbEnvironmentMapping.Size = new System.Drawing.Size(100, 13);
            this.cbEnvironmentMapping.TabIndex = 22;
            this.cbEnvironmentMapping.UseVisualStyleBackColor = true;
            // 
            // numRefractionPower
            // 
            this.numRefractionPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numRefractionPower.DecimalPlaces = 5;
            this.numRefractionPower.Location = new System.Drawing.Point(13, 410);
            this.numRefractionPower.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numRefractionPower.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numRefractionPower.Name = "numRefractionPower";
            this.numRefractionPower.Size = new System.Drawing.Size(272, 20);
            this.numRefractionPower.TabIndex = 21;
            // 
            // cbRefractionFalloff
            // 
            this.cbRefractionFalloff.Location = new System.Drawing.Point(13, 394);
            this.cbRefractionFalloff.Name = "cbRefractionFalloff";
            this.cbRefractionFalloff.Size = new System.Drawing.Size(100, 13);
            this.cbRefractionFalloff.TabIndex = 20;
            this.cbRefractionFalloff.UseVisualStyleBackColor = true;
            // 
            // cbRefraction
            // 
            this.cbRefraction.Location = new System.Drawing.Point(13, 375);
            this.cbRefraction.Name = "cbRefraction";
            this.cbRefraction.Size = new System.Drawing.Size(100, 13);
            this.cbRefraction.TabIndex = 19;
            this.cbRefraction.UseVisualStyleBackColor = true;
            // 
            // cbNonOccluder
            // 
            this.cbNonOccluder.Location = new System.Drawing.Point(13, 356);
            this.cbNonOccluder.Name = "cbNonOccluder";
            this.cbNonOccluder.Size = new System.Drawing.Size(100, 13);
            this.cbNonOccluder.TabIndex = 18;
            this.cbNonOccluder.UseVisualStyleBackColor = true;
            // 
            // cbDecalNoFade
            // 
            this.cbDecalNoFade.Location = new System.Drawing.Point(13, 337);
            this.cbDecalNoFade.Name = "cbDecalNoFade";
            this.cbDecalNoFade.Size = new System.Drawing.Size(100, 13);
            this.cbDecalNoFade.TabIndex = 17;
            this.cbDecalNoFade.UseVisualStyleBackColor = true;
            // 
            // cbTwoSided
            // 
            this.cbTwoSided.Location = new System.Drawing.Point(13, 318);
            this.cbTwoSided.Name = "cbTwoSided";
            this.cbTwoSided.Size = new System.Drawing.Size(100, 13);
            this.cbTwoSided.TabIndex = 16;
            this.cbTwoSided.UseVisualStyleBackColor = true;
            // 
            // cbDecal
            // 
            this.cbDecal.Location = new System.Drawing.Point(13, 299);
            this.cbDecal.Name = "cbDecal";
            this.cbDecal.Size = new System.Drawing.Size(100, 13);
            this.cbDecal.TabIndex = 15;
            this.cbDecal.UseVisualStyleBackColor = true;
            // 
            // cbWetnessControlSSR
            // 
            this.cbWetnessControlSSR.Location = new System.Drawing.Point(13, 280);
            this.cbWetnessControlSSR.Name = "cbWetnessControlSSR";
            this.cbWetnessControlSSR.Size = new System.Drawing.Size(100, 13);
            this.cbWetnessControlSSR.TabIndex = 14;
            this.cbWetnessControlSSR.UseVisualStyleBackColor = true;
            // 
            // cbScreenSpaceReflections
            // 
            this.cbScreenSpaceReflections.Location = new System.Drawing.Point(13, 261);
            this.cbScreenSpaceReflections.Name = "cbScreenSpaceReflections";
            this.cbScreenSpaceReflections.Size = new System.Drawing.Size(100, 13);
            this.cbScreenSpaceReflections.TabIndex = 13;
            this.cbScreenSpaceReflections.UseVisualStyleBackColor = true;
            // 
            // cbZBufferTest
            // 
            this.cbZBufferTest.Location = new System.Drawing.Point(13, 242);
            this.cbZBufferTest.Name = "cbZBufferTest";
            this.cbZBufferTest.Size = new System.Drawing.Size(100, 13);
            this.cbZBufferTest.TabIndex = 12;
            this.cbZBufferTest.UseVisualStyleBackColor = true;
            // 
            // cbZBufferWrite
            // 
            this.cbZBufferWrite.Location = new System.Drawing.Point(13, 223);
            this.cbZBufferWrite.Name = "cbZBufferWrite";
            this.cbZBufferWrite.Size = new System.Drawing.Size(100, 13);
            this.cbZBufferWrite.TabIndex = 11;
            this.cbZBufferWrite.UseVisualStyleBackColor = true;
            // 
            // cbAlphaTest
            // 
            this.cbAlphaTest.Location = new System.Drawing.Point(13, 204);
            this.cbAlphaTest.Name = "cbAlphaTest";
            this.cbAlphaTest.Size = new System.Drawing.Size(100, 13);
            this.cbAlphaTest.TabIndex = 10;
            this.cbAlphaTest.UseVisualStyleBackColor = true;
            // 
            // numAlphaTestReference
            // 
            this.numAlphaTestReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAlphaTestReference.Location = new System.Drawing.Point(13, 182);
            this.numAlphaTestReference.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numAlphaTestReference.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.numAlphaTestReference.Name = "numAlphaTestReference";
            this.numAlphaTestReference.Size = new System.Drawing.Size(272, 20);
            this.numAlphaTestReference.TabIndex = 9;
            // 
            // selAlphaBlendMode
            // 
            this.selAlphaBlendMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selAlphaBlendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selAlphaBlendMode.FormattingEnabled = true;
            this.selAlphaBlendMode.Items.AddRange(new object[] {
            "Unknown",
            "None",
            "Standard",
            "Additive",
            "Multiplicative"});
            this.selAlphaBlendMode.Location = new System.Drawing.Point(13, 163);
            this.selAlphaBlendMode.Name = "selAlphaBlendMode";
            this.selAlphaBlendMode.Size = new System.Drawing.Size(272, 21);
            this.selAlphaBlendMode.TabIndex = 8;
            // 
            // numAlpha
            // 
            this.numAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAlpha.DecimalPlaces = 5;
            this.numAlpha.Location = new System.Drawing.Point(13, 144);
            this.numAlpha.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numAlpha.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(272, 20);
            this.numAlpha.TabIndex = 7;
            // 
            // numScaleV
            // 
            this.numScaleV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numScaleV.DecimalPlaces = 5;
            this.numScaleV.Location = new System.Drawing.Point(13, 125);
            this.numScaleV.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numScaleV.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numScaleV.Name = "numScaleV";
            this.numScaleV.Size = new System.Drawing.Size(272, 20);
            this.numScaleV.TabIndex = 6;
            // 
            // numScaleU
            // 
            this.numScaleU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numScaleU.DecimalPlaces = 5;
            this.numScaleU.Location = new System.Drawing.Point(13, 106);
            this.numScaleU.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numScaleU.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numScaleU.Name = "numScaleU";
            this.numScaleU.Size = new System.Drawing.Size(272, 20);
            this.numScaleU.TabIndex = 5;
            // 
            // numOffsetV
            // 
            this.numOffsetV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numOffsetV.DecimalPlaces = 5;
            this.numOffsetV.Location = new System.Drawing.Point(13, 87);
            this.numOffsetV.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numOffsetV.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numOffsetV.Name = "numOffsetV";
            this.numOffsetV.Size = new System.Drawing.Size(272, 20);
            this.numOffsetV.TabIndex = 4;
            // 
            // numOffsetU
            // 
            this.numOffsetU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numOffsetU.DecimalPlaces = 5;
            this.numOffsetU.Location = new System.Drawing.Point(13, 68);
            this.numOffsetU.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numOffsetU.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numOffsetU.Name = "numOffsetU";
            this.numOffsetU.Size = new System.Drawing.Size(272, 20);
            this.numOffsetU.TabIndex = 3;
            // 
            // cbTileV
            // 
            this.cbTileV.Location = new System.Drawing.Point(13, 52);
            this.cbTileV.Name = "cbTileV";
            this.cbTileV.Size = new System.Drawing.Size(100, 13);
            this.cbTileV.TabIndex = 2;
            this.cbTileV.UseVisualStyleBackColor = true;
            // 
            // cbTileU
            // 
            this.cbTileU.Location = new System.Drawing.Point(13, 33);
            this.cbTileU.Name = "cbTileU";
            this.cbTileU.Size = new System.Drawing.Size(100, 13);
            this.cbTileU.TabIndex = 1;
            this.cbTileU.UseVisualStyleBackColor = true;
            // 
            // numVersion
            // 
            this.numVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numVersion.Location = new System.Drawing.Point(13, 11);
            this.numVersion.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numVersion.Name = "numVersion";
            this.numVersion.Size = new System.Drawing.Size(272, 20);
            this.numVersion.TabIndex = 0;
            // 
            // tabPageMaterial
            // 
            this.tabPageMaterial.AutoScroll = true;
            this.tabPageMaterial.Controls.Add(this.splitContainerMaterial);
            this.tabPageMaterial.Location = new System.Drawing.Point(4, 22);
            this.tabPageMaterial.Name = "tabPageMaterial";
            this.tabPageMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMaterial.Size = new System.Drawing.Size(476, 507);
            this.tabPageMaterial.TabIndex = 0;
            this.tabPageMaterial.Text = "Material";
            this.tabPageMaterial.UseVisualStyleBackColor = true;
            this.tabPageMaterial.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TabScroll);
            // 
            // splitContainerMaterial
            // 
            this.splitContainerMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMaterial.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMaterial.IsSplitterFixed = true;
            this.splitContainerMaterial.Location = new System.Drawing.Point(4, 4);
            this.splitContainerMaterial.Name = "splitContainerMaterial";
            // 
            // splitContainerMaterial.Panel1
            // 
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSkewSpecularAlpha);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbGrayscaleToPaletteScale);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbTessellationFadeDistance);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbTessellationBaseFactor);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbTessellationPNScale);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbDisplacementTexScale);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbDisplacementTexBias);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbTessellate);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSkinTint);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbFacegen);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbTree);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbHairTintColor);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbHair);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEnvironmentMapEye);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEnvironmentMapWindow);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbGlowmap);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbAssumeShadowmask);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbDissolveFade);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbCastShadows);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbHideSecret);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbReceiveShadows);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbBackLighting);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbExternalEmittance);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbModelSpaceNormals);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEmittanceMultiplier);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEmittanceColor);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEmittanceEnabled);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbAnisoLighting);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbRootMaterialPath);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWetMetalness);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWetFresnelPower);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWetEnvMapScale);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWetSpecMinVar);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWetSpecPowerScale);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWetSpecScale);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbFresnelPower);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSmoothness);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSpecularMult);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSpecularColor);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSpecularEnabled);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSubsurfaceLightingRolloff);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSubsurfaceLighting);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbBacklightPower);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbRimPower);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbRimLighting);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEnableEditorAlphaRef);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbDisplacementTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbWrinklesTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbInnerLayerTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbGlowTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbEnvironmentMapTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbGreyscaleTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbSmoothSpecularTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbNormalTexture);
            this.splitContainerMaterial.Panel1.Controls.Add(this.lbDiffuseTexture);
            this.splitContainerMaterial.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerMaterial.Panel1MinSize = 165;
            // 
            // splitContainerMaterial.Panel2
            // 
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbSkewSpecularAlpha);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numGrayscaleToPaletteScale);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numTessellationFadeDistance);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numTessellationBaseFactor);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numTessellationPNScale);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numDisplacementTexScale);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numDisplacementTexBias);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbTessellate);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbSkinTint);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbFacegen);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbTree);
            this.splitContainerMaterial.Panel2.Controls.Add(this.btHairTintColor);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbHair);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbEnvironmentMapEye);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbEnvironmentMapWindow);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbGlowmap);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbAssumeShadowmask);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbDissolveFade);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbCastShadows);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbHideSecret);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbReceiveShadows);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbBackLighting);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbExternalEmittance);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbModelSpaceNormals);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numEmittanceMultiplier);
            this.splitContainerMaterial.Panel2.Controls.Add(this.btEmittanceColor);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbEmittanceEnabled);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbAnisoLighting);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbRootMaterialPath);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numWetMetalness);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numWetFresnelPower);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numWetEnvMapScale);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numWetSpecMinVar);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numWetSpecPowerScale);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numWetSpecScale);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numFresnelPower);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numSmoothness);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numSpecularMultiplier);
            this.splitContainerMaterial.Panel2.Controls.Add(this.btSpecularColor);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbSpecularEnabled);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numSubsurfaceLightingRolloff);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbSubsurfaceLighting);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numBacklightPower);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbRimLighting);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbDisplacementTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbWrinklesTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbInnerLayerTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbGlowTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbEnvironmentMapTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbGreyscaleTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbSmoothSpecularTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbNormalTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.tbDiffuseTexture);
            this.splitContainerMaterial.Panel2.Controls.Add(this.numRimPower);
            this.splitContainerMaterial.Panel2.Controls.Add(this.cbEnableEditorAlphaRef);
            this.splitContainerMaterial.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerMaterial.Panel2MinSize = 165;
            this.splitContainerMaterial.Size = new System.Drawing.Size(469, 1068);
            this.splitContainerMaterial.SplitterDistance = 165;
            this.splitContainerMaterial.TabIndex = 2;
            // 
            // lbSkewSpecularAlpha
            // 
            this.lbSkewSpecularAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSkewSpecularAlpha.Location = new System.Drawing.Point(13, 1039);
            this.lbSkewSpecularAlpha.Margin = new System.Windows.Forms.Padding(3);
            this.lbSkewSpecularAlpha.Name = "lbSkewSpecularAlpha";
            this.lbSkewSpecularAlpha.Size = new System.Drawing.Size(135, 13);
            this.lbSkewSpecularAlpha.TabIndex = 54;
            this.lbSkewSpecularAlpha.Text = "Skew Specular Alpha";
            // 
            // lbGrayscaleToPaletteScale
            // 
            this.lbGrayscaleToPaletteScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGrayscaleToPaletteScale.Location = new System.Drawing.Point(13, 1020);
            this.lbGrayscaleToPaletteScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbGrayscaleToPaletteScale.Name = "lbGrayscaleToPaletteScale";
            this.lbGrayscaleToPaletteScale.Size = new System.Drawing.Size(137, 13);
            this.lbGrayscaleToPaletteScale.TabIndex = 53;
            this.lbGrayscaleToPaletteScale.Text = "Grayscale To Palette Scale";
            // 
            // lbTessellationFadeDistance
            // 
            this.lbTessellationFadeDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTessellationFadeDistance.Location = new System.Drawing.Point(13, 1001);
            this.lbTessellationFadeDistance.Margin = new System.Windows.Forms.Padding(3);
            this.lbTessellationFadeDistance.Name = "lbTessellationFadeDistance";
            this.lbTessellationFadeDistance.Size = new System.Drawing.Size(135, 13);
            this.lbTessellationFadeDistance.TabIndex = 52;
            this.lbTessellationFadeDistance.Text = "Tessellation Fade Distance";
            // 
            // lbTessellationBaseFactor
            // 
            this.lbTessellationBaseFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTessellationBaseFactor.Location = new System.Drawing.Point(13, 982);
            this.lbTessellationBaseFactor.Margin = new System.Windows.Forms.Padding(3);
            this.lbTessellationBaseFactor.Name = "lbTessellationBaseFactor";
            this.lbTessellationBaseFactor.Size = new System.Drawing.Size(135, 13);
            this.lbTessellationBaseFactor.TabIndex = 51;
            this.lbTessellationBaseFactor.Text = "Tessellation Base Factor";
            // 
            // lbTessellationPNScale
            // 
            this.lbTessellationPNScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTessellationPNScale.Location = new System.Drawing.Point(13, 963);
            this.lbTessellationPNScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbTessellationPNScale.Name = "lbTessellationPNScale";
            this.lbTessellationPNScale.Size = new System.Drawing.Size(135, 13);
            this.lbTessellationPNScale.TabIndex = 50;
            this.lbTessellationPNScale.Text = "Tessellation PN Scale";
            // 
            // lbDisplacementTexScale
            // 
            this.lbDisplacementTexScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDisplacementTexScale.Location = new System.Drawing.Point(13, 944);
            this.lbDisplacementTexScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbDisplacementTexScale.Name = "lbDisplacementTexScale";
            this.lbDisplacementTexScale.Size = new System.Drawing.Size(135, 13);
            this.lbDisplacementTexScale.TabIndex = 49;
            this.lbDisplacementTexScale.Text = "Displacement Tex Scale";
            // 
            // lbDisplacementTexBias
            // 
            this.lbDisplacementTexBias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDisplacementTexBias.Location = new System.Drawing.Point(13, 925);
            this.lbDisplacementTexBias.Margin = new System.Windows.Forms.Padding(3);
            this.lbDisplacementTexBias.Name = "lbDisplacementTexBias";
            this.lbDisplacementTexBias.Size = new System.Drawing.Size(135, 13);
            this.lbDisplacementTexBias.TabIndex = 48;
            this.lbDisplacementTexBias.Text = "Displacement Tex Bias";
            // 
            // lbTessellate
            // 
            this.lbTessellate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTessellate.Location = new System.Drawing.Point(13, 906);
            this.lbTessellate.Margin = new System.Windows.Forms.Padding(3);
            this.lbTessellate.Name = "lbTessellate";
            this.lbTessellate.Size = new System.Drawing.Size(135, 13);
            this.lbTessellate.TabIndex = 47;
            this.lbTessellate.Text = "Tessellate";
            // 
            // lbSkinTint
            // 
            this.lbSkinTint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSkinTint.Location = new System.Drawing.Point(13, 887);
            this.lbSkinTint.Margin = new System.Windows.Forms.Padding(3);
            this.lbSkinTint.Name = "lbSkinTint";
            this.lbSkinTint.Size = new System.Drawing.Size(135, 13);
            this.lbSkinTint.TabIndex = 46;
            this.lbSkinTint.Text = "Skin Tint";
            // 
            // lbFacegen
            // 
            this.lbFacegen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFacegen.Location = new System.Drawing.Point(13, 868);
            this.lbFacegen.Margin = new System.Windows.Forms.Padding(3);
            this.lbFacegen.Name = "lbFacegen";
            this.lbFacegen.Size = new System.Drawing.Size(135, 13);
            this.lbFacegen.TabIndex = 45;
            this.lbFacegen.Text = "Facegen";
            // 
            // lbTree
            // 
            this.lbTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTree.Location = new System.Drawing.Point(13, 849);
            this.lbTree.Margin = new System.Windows.Forms.Padding(3);
            this.lbTree.Name = "lbTree";
            this.lbTree.Size = new System.Drawing.Size(135, 13);
            this.lbTree.TabIndex = 44;
            this.lbTree.Text = "Tree";
            // 
            // lbHairTintColor
            // 
            this.lbHairTintColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHairTintColor.Location = new System.Drawing.Point(13, 830);
            this.lbHairTintColor.Margin = new System.Windows.Forms.Padding(3);
            this.lbHairTintColor.Name = "lbHairTintColor";
            this.lbHairTintColor.Size = new System.Drawing.Size(135, 13);
            this.lbHairTintColor.TabIndex = 43;
            this.lbHairTintColor.Text = "Hair Tint Color";
            // 
            // lbHair
            // 
            this.lbHair.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHair.Location = new System.Drawing.Point(13, 811);
            this.lbHair.Margin = new System.Windows.Forms.Padding(3);
            this.lbHair.Name = "lbHair";
            this.lbHair.Size = new System.Drawing.Size(135, 13);
            this.lbHair.TabIndex = 42;
            this.lbHair.Text = "Hair";
            // 
            // lbEnvironmentMapEye
            // 
            this.lbEnvironmentMapEye.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvironmentMapEye.Location = new System.Drawing.Point(13, 792);
            this.lbEnvironmentMapEye.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvironmentMapEye.Name = "lbEnvironmentMapEye";
            this.lbEnvironmentMapEye.Size = new System.Drawing.Size(135, 13);
            this.lbEnvironmentMapEye.TabIndex = 41;
            this.lbEnvironmentMapEye.Text = "Environment Map Eye";
            // 
            // lbEnvironmentMapWindow
            // 
            this.lbEnvironmentMapWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvironmentMapWindow.Location = new System.Drawing.Point(13, 773);
            this.lbEnvironmentMapWindow.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvironmentMapWindow.Name = "lbEnvironmentMapWindow";
            this.lbEnvironmentMapWindow.Size = new System.Drawing.Size(135, 13);
            this.lbEnvironmentMapWindow.TabIndex = 40;
            this.lbEnvironmentMapWindow.Text = "Environment Map Window";
            // 
            // lbGlowmap
            // 
            this.lbGlowmap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGlowmap.Location = new System.Drawing.Point(13, 754);
            this.lbGlowmap.Margin = new System.Windows.Forms.Padding(3);
            this.lbGlowmap.Name = "lbGlowmap";
            this.lbGlowmap.Size = new System.Drawing.Size(135, 13);
            this.lbGlowmap.TabIndex = 39;
            this.lbGlowmap.Text = "Glowmap";
            // 
            // lbAssumeShadowmask
            // 
            this.lbAssumeShadowmask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAssumeShadowmask.Location = new System.Drawing.Point(13, 735);
            this.lbAssumeShadowmask.Margin = new System.Windows.Forms.Padding(3);
            this.lbAssumeShadowmask.Name = "lbAssumeShadowmask";
            this.lbAssumeShadowmask.Size = new System.Drawing.Size(135, 13);
            this.lbAssumeShadowmask.TabIndex = 38;
            this.lbAssumeShadowmask.Text = "Assume Shadowmask";
            // 
            // lbDissolveFade
            // 
            this.lbDissolveFade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDissolveFade.Location = new System.Drawing.Point(13, 716);
            this.lbDissolveFade.Margin = new System.Windows.Forms.Padding(3);
            this.lbDissolveFade.Name = "lbDissolveFade";
            this.lbDissolveFade.Size = new System.Drawing.Size(135, 13);
            this.lbDissolveFade.TabIndex = 37;
            this.lbDissolveFade.Text = "Dissolve Fade";
            // 
            // lbCastShadows
            // 
            this.lbCastShadows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCastShadows.Location = new System.Drawing.Point(13, 697);
            this.lbCastShadows.Margin = new System.Windows.Forms.Padding(3);
            this.lbCastShadows.Name = "lbCastShadows";
            this.lbCastShadows.Size = new System.Drawing.Size(135, 13);
            this.lbCastShadows.TabIndex = 36;
            this.lbCastShadows.Text = "Cast Shadows";
            // 
            // lbHideSecret
            // 
            this.lbHideSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHideSecret.Location = new System.Drawing.Point(13, 678);
            this.lbHideSecret.Margin = new System.Windows.Forms.Padding(3);
            this.lbHideSecret.Name = "lbHideSecret";
            this.lbHideSecret.Size = new System.Drawing.Size(135, 13);
            this.lbHideSecret.TabIndex = 35;
            this.lbHideSecret.Text = "Hide Secret";
            // 
            // lbReceiveShadows
            // 
            this.lbReceiveShadows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReceiveShadows.Location = new System.Drawing.Point(13, 659);
            this.lbReceiveShadows.Margin = new System.Windows.Forms.Padding(3);
            this.lbReceiveShadows.Name = "lbReceiveShadows";
            this.lbReceiveShadows.Size = new System.Drawing.Size(135, 13);
            this.lbReceiveShadows.TabIndex = 34;
            this.lbReceiveShadows.Text = "Receive Shadows";
            // 
            // lbBackLighting
            // 
            this.lbBackLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBackLighting.Location = new System.Drawing.Point(13, 640);
            this.lbBackLighting.Margin = new System.Windows.Forms.Padding(3);
            this.lbBackLighting.Name = "lbBackLighting";
            this.lbBackLighting.Size = new System.Drawing.Size(135, 13);
            this.lbBackLighting.TabIndex = 33;
            this.lbBackLighting.Text = "Back Lighting";
            // 
            // lbExternalEmittance
            // 
            this.lbExternalEmittance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExternalEmittance.Location = new System.Drawing.Point(13, 621);
            this.lbExternalEmittance.Margin = new System.Windows.Forms.Padding(3);
            this.lbExternalEmittance.Name = "lbExternalEmittance";
            this.lbExternalEmittance.Size = new System.Drawing.Size(135, 13);
            this.lbExternalEmittance.TabIndex = 32;
            this.lbExternalEmittance.Text = "External Emittance";
            // 
            // lbModelSpaceNormals
            // 
            this.lbModelSpaceNormals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbModelSpaceNormals.Location = new System.Drawing.Point(13, 602);
            this.lbModelSpaceNormals.Margin = new System.Windows.Forms.Padding(3);
            this.lbModelSpaceNormals.Name = "lbModelSpaceNormals";
            this.lbModelSpaceNormals.Size = new System.Drawing.Size(135, 13);
            this.lbModelSpaceNormals.TabIndex = 31;
            this.lbModelSpaceNormals.Text = "Model Space Normals";
            // 
            // lbEmittanceMultiplier
            // 
            this.lbEmittanceMultiplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmittanceMultiplier.Location = new System.Drawing.Point(13, 583);
            this.lbEmittanceMultiplier.Margin = new System.Windows.Forms.Padding(3);
            this.lbEmittanceMultiplier.Name = "lbEmittanceMultiplier";
            this.lbEmittanceMultiplier.Size = new System.Drawing.Size(135, 13);
            this.lbEmittanceMultiplier.TabIndex = 30;
            this.lbEmittanceMultiplier.Text = "Emittance Multiplier";
            // 
            // lbEmittanceColor
            // 
            this.lbEmittanceColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmittanceColor.Location = new System.Drawing.Point(13, 564);
            this.lbEmittanceColor.Margin = new System.Windows.Forms.Padding(3);
            this.lbEmittanceColor.Name = "lbEmittanceColor";
            this.lbEmittanceColor.Size = new System.Drawing.Size(135, 13);
            this.lbEmittanceColor.TabIndex = 29;
            this.lbEmittanceColor.Text = "Emittance Color";
            // 
            // lbEmittanceEnabled
            // 
            this.lbEmittanceEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmittanceEnabled.Location = new System.Drawing.Point(13, 545);
            this.lbEmittanceEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbEmittanceEnabled.Name = "lbEmittanceEnabled";
            this.lbEmittanceEnabled.Size = new System.Drawing.Size(135, 13);
            this.lbEmittanceEnabled.TabIndex = 28;
            this.lbEmittanceEnabled.Text = "Emittance Enabled";
            // 
            // lbAnisoLighting
            // 
            this.lbAnisoLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAnisoLighting.Location = new System.Drawing.Point(13, 526);
            this.lbAnisoLighting.Margin = new System.Windows.Forms.Padding(3);
            this.lbAnisoLighting.Name = "lbAnisoLighting";
            this.lbAnisoLighting.Size = new System.Drawing.Size(135, 13);
            this.lbAnisoLighting.TabIndex = 27;
            this.lbAnisoLighting.Text = "Aniso Lighting";
            // 
            // lbRootMaterialPath
            // 
            this.lbRootMaterialPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRootMaterialPath.Location = new System.Drawing.Point(13, 507);
            this.lbRootMaterialPath.Margin = new System.Windows.Forms.Padding(3);
            this.lbRootMaterialPath.Name = "lbRootMaterialPath";
            this.lbRootMaterialPath.Size = new System.Drawing.Size(135, 13);
            this.lbRootMaterialPath.TabIndex = 26;
            this.lbRootMaterialPath.Text = "Root Material Path";
            // 
            // lbWetMetalness
            // 
            this.lbWetMetalness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetMetalness.Location = new System.Drawing.Point(13, 488);
            this.lbWetMetalness.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetMetalness.Name = "lbWetMetalness";
            this.lbWetMetalness.Size = new System.Drawing.Size(135, 13);
            this.lbWetMetalness.TabIndex = 25;
            this.lbWetMetalness.Text = "Wet Metalness";
            // 
            // lbWetFresnelPower
            // 
            this.lbWetFresnelPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetFresnelPower.Location = new System.Drawing.Point(13, 469);
            this.lbWetFresnelPower.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetFresnelPower.Name = "lbWetFresnelPower";
            this.lbWetFresnelPower.Size = new System.Drawing.Size(135, 13);
            this.lbWetFresnelPower.TabIndex = 24;
            this.lbWetFresnelPower.Text = "Wet Fresnel Power";
            // 
            // lbWetEnvMapScale
            // 
            this.lbWetEnvMapScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetEnvMapScale.Location = new System.Drawing.Point(13, 450);
            this.lbWetEnvMapScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetEnvMapScale.Name = "lbWetEnvMapScale";
            this.lbWetEnvMapScale.Size = new System.Drawing.Size(135, 13);
            this.lbWetEnvMapScale.TabIndex = 23;
            this.lbWetEnvMapScale.Text = "Wet Env Map Scale";
            // 
            // lbWetSpecMinVar
            // 
            this.lbWetSpecMinVar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetSpecMinVar.Location = new System.Drawing.Point(13, 431);
            this.lbWetSpecMinVar.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetSpecMinVar.Name = "lbWetSpecMinVar";
            this.lbWetSpecMinVar.Size = new System.Drawing.Size(135, 13);
            this.lbWetSpecMinVar.TabIndex = 22;
            this.lbWetSpecMinVar.Text = "Wet Spec Min Var";
            // 
            // lbWetSpecPowerScale
            // 
            this.lbWetSpecPowerScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetSpecPowerScale.Location = new System.Drawing.Point(13, 412);
            this.lbWetSpecPowerScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetSpecPowerScale.Name = "lbWetSpecPowerScale";
            this.lbWetSpecPowerScale.Size = new System.Drawing.Size(135, 13);
            this.lbWetSpecPowerScale.TabIndex = 21;
            this.lbWetSpecPowerScale.Text = "Wet Spec Power Scale";
            // 
            // lbWetSpecScale
            // 
            this.lbWetSpecScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWetSpecScale.Location = new System.Drawing.Point(13, 393);
            this.lbWetSpecScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbWetSpecScale.Name = "lbWetSpecScale";
            this.lbWetSpecScale.Size = new System.Drawing.Size(135, 13);
            this.lbWetSpecScale.TabIndex = 20;
            this.lbWetSpecScale.Text = "Wet Spec Scale";
            // 
            // lbFresnelPower
            // 
            this.lbFresnelPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFresnelPower.Location = new System.Drawing.Point(13, 374);
            this.lbFresnelPower.Margin = new System.Windows.Forms.Padding(3);
            this.lbFresnelPower.Name = "lbFresnelPower";
            this.lbFresnelPower.Size = new System.Drawing.Size(135, 13);
            this.lbFresnelPower.TabIndex = 19;
            this.lbFresnelPower.Text = "Fresnel Power";
            // 
            // lbSmoothness
            // 
            this.lbSmoothness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSmoothness.Location = new System.Drawing.Point(13, 355);
            this.lbSmoothness.Margin = new System.Windows.Forms.Padding(3);
            this.lbSmoothness.Name = "lbSmoothness";
            this.lbSmoothness.Size = new System.Drawing.Size(135, 13);
            this.lbSmoothness.TabIndex = 18;
            this.lbSmoothness.Text = "Smoothness";
            // 
            // lbSpecularMult
            // 
            this.lbSpecularMult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSpecularMult.Location = new System.Drawing.Point(13, 336);
            this.lbSpecularMult.Margin = new System.Windows.Forms.Padding(3);
            this.lbSpecularMult.Name = "lbSpecularMult";
            this.lbSpecularMult.Size = new System.Drawing.Size(135, 13);
            this.lbSpecularMult.TabIndex = 17;
            this.lbSpecularMult.Text = "Specular Multiplier";
            // 
            // lbSpecularColor
            // 
            this.lbSpecularColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSpecularColor.Location = new System.Drawing.Point(13, 317);
            this.lbSpecularColor.Margin = new System.Windows.Forms.Padding(3);
            this.lbSpecularColor.Name = "lbSpecularColor";
            this.lbSpecularColor.Size = new System.Drawing.Size(135, 13);
            this.lbSpecularColor.TabIndex = 16;
            this.lbSpecularColor.Text = "Specular Color";
            // 
            // lbSpecularEnabled
            // 
            this.lbSpecularEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSpecularEnabled.Location = new System.Drawing.Point(13, 298);
            this.lbSpecularEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbSpecularEnabled.Name = "lbSpecularEnabled";
            this.lbSpecularEnabled.Size = new System.Drawing.Size(135, 13);
            this.lbSpecularEnabled.TabIndex = 15;
            this.lbSpecularEnabled.Text = "Specular Enabled";
            // 
            // lbSubsurfaceLightingRolloff
            // 
            this.lbSubsurfaceLightingRolloff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSubsurfaceLightingRolloff.Location = new System.Drawing.Point(13, 279);
            this.lbSubsurfaceLightingRolloff.Margin = new System.Windows.Forms.Padding(3);
            this.lbSubsurfaceLightingRolloff.Name = "lbSubsurfaceLightingRolloff";
            this.lbSubsurfaceLightingRolloff.Size = new System.Drawing.Size(135, 13);
            this.lbSubsurfaceLightingRolloff.TabIndex = 14;
            this.lbSubsurfaceLightingRolloff.Text = "Subsurface Lighting Rolloff";
            // 
            // lbSubsurfaceLighting
            // 
            this.lbSubsurfaceLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSubsurfaceLighting.Location = new System.Drawing.Point(13, 260);
            this.lbSubsurfaceLighting.Margin = new System.Windows.Forms.Padding(3);
            this.lbSubsurfaceLighting.Name = "lbSubsurfaceLighting";
            this.lbSubsurfaceLighting.Size = new System.Drawing.Size(135, 13);
            this.lbSubsurfaceLighting.TabIndex = 13;
            this.lbSubsurfaceLighting.Text = "Subsurface Lighting";
            // 
            // lbBacklightPower
            // 
            this.lbBacklightPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBacklightPower.Location = new System.Drawing.Point(13, 241);
            this.lbBacklightPower.Margin = new System.Windows.Forms.Padding(3);
            this.lbBacklightPower.Name = "lbBacklightPower";
            this.lbBacklightPower.Size = new System.Drawing.Size(135, 13);
            this.lbBacklightPower.TabIndex = 12;
            this.lbBacklightPower.Text = "Backlight Power";
            // 
            // lbRimPower
            // 
            this.lbRimPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRimPower.Location = new System.Drawing.Point(13, 222);
            this.lbRimPower.Margin = new System.Windows.Forms.Padding(3);
            this.lbRimPower.Name = "lbRimPower";
            this.lbRimPower.Size = new System.Drawing.Size(135, 13);
            this.lbRimPower.TabIndex = 11;
            this.lbRimPower.Text = "Rim Power";
            // 
            // lbRimLighting
            // 
            this.lbRimLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRimLighting.Location = new System.Drawing.Point(13, 203);
            this.lbRimLighting.Margin = new System.Windows.Forms.Padding(3);
            this.lbRimLighting.Name = "lbRimLighting";
            this.lbRimLighting.Size = new System.Drawing.Size(135, 13);
            this.lbRimLighting.TabIndex = 10;
            this.lbRimLighting.Text = "Rim Lighting";
            // 
            // lbEnableEditorAlphaRef
            // 
            this.lbEnableEditorAlphaRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnableEditorAlphaRef.Location = new System.Drawing.Point(13, 184);
            this.lbEnableEditorAlphaRef.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnableEditorAlphaRef.Name = "lbEnableEditorAlphaRef";
            this.lbEnableEditorAlphaRef.Size = new System.Drawing.Size(135, 13);
            this.lbEnableEditorAlphaRef.TabIndex = 9;
            this.lbEnableEditorAlphaRef.Text = "Enable Editor Alpha Ref";
            // 
            // lbDisplacementTexture
            // 
            this.lbDisplacementTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDisplacementTexture.Location = new System.Drawing.Point(13, 165);
            this.lbDisplacementTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbDisplacementTexture.Name = "lbDisplacementTexture";
            this.lbDisplacementTexture.Size = new System.Drawing.Size(135, 13);
            this.lbDisplacementTexture.TabIndex = 8;
            this.lbDisplacementTexture.Text = "Displacement Texture";
            // 
            // lbWrinklesTexture
            // 
            this.lbWrinklesTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWrinklesTexture.Location = new System.Drawing.Point(13, 146);
            this.lbWrinklesTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbWrinklesTexture.Name = "lbWrinklesTexture";
            this.lbWrinklesTexture.Size = new System.Drawing.Size(135, 13);
            this.lbWrinklesTexture.TabIndex = 7;
            this.lbWrinklesTexture.Text = "Wrinkles Texture";
            // 
            // lbInnerLayerTexture
            // 
            this.lbInnerLayerTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInnerLayerTexture.Location = new System.Drawing.Point(13, 127);
            this.lbInnerLayerTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbInnerLayerTexture.Name = "lbInnerLayerTexture";
            this.lbInnerLayerTexture.Size = new System.Drawing.Size(135, 13);
            this.lbInnerLayerTexture.TabIndex = 6;
            this.lbInnerLayerTexture.Text = "Inner Layer Texture";
            // 
            // lbGlowTexture
            // 
            this.lbGlowTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGlowTexture.Location = new System.Drawing.Point(13, 108);
            this.lbGlowTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbGlowTexture.Name = "lbGlowTexture";
            this.lbGlowTexture.Size = new System.Drawing.Size(135, 13);
            this.lbGlowTexture.TabIndex = 5;
            this.lbGlowTexture.Text = "Glow Texture";
            // 
            // lbEnvironmentMapTexture
            // 
            this.lbEnvironmentMapTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvironmentMapTexture.Location = new System.Drawing.Point(13, 89);
            this.lbEnvironmentMapTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvironmentMapTexture.Name = "lbEnvironmentMapTexture";
            this.lbEnvironmentMapTexture.Size = new System.Drawing.Size(135, 13);
            this.lbEnvironmentMapTexture.TabIndex = 4;
            this.lbEnvironmentMapTexture.Text = "Environment Map Texture";
            // 
            // lbGreyscaleTexture
            // 
            this.lbGreyscaleTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGreyscaleTexture.Location = new System.Drawing.Point(13, 70);
            this.lbGreyscaleTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbGreyscaleTexture.Name = "lbGreyscaleTexture";
            this.lbGreyscaleTexture.Size = new System.Drawing.Size(135, 13);
            this.lbGreyscaleTexture.TabIndex = 3;
            this.lbGreyscaleTexture.Text = "Greyscale Texture";
            // 
            // lbSmoothSpecularTexture
            // 
            this.lbSmoothSpecularTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSmoothSpecularTexture.Location = new System.Drawing.Point(13, 51);
            this.lbSmoothSpecularTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbSmoothSpecularTexture.Name = "lbSmoothSpecularTexture";
            this.lbSmoothSpecularTexture.Size = new System.Drawing.Size(135, 13);
            this.lbSmoothSpecularTexture.TabIndex = 2;
            this.lbSmoothSpecularTexture.Text = "Smooth Specular Texture";
            // 
            // lbNormalTexture
            // 
            this.lbNormalTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNormalTexture.Location = new System.Drawing.Point(13, 32);
            this.lbNormalTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbNormalTexture.Name = "lbNormalTexture";
            this.lbNormalTexture.Size = new System.Drawing.Size(135, 13);
            this.lbNormalTexture.TabIndex = 1;
            this.lbNormalTexture.Text = "Normal Texture";
            // 
            // lbDiffuseTexture
            // 
            this.lbDiffuseTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDiffuseTexture.Location = new System.Drawing.Point(13, 13);
            this.lbDiffuseTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbDiffuseTexture.Name = "lbDiffuseTexture";
            this.lbDiffuseTexture.Size = new System.Drawing.Size(135, 13);
            this.lbDiffuseTexture.TabIndex = 0;
            this.lbDiffuseTexture.Text = "Diffuse Texture";
            // 
            // cbSkewSpecularAlpha
            // 
            this.cbSkewSpecularAlpha.Location = new System.Drawing.Point(13, 1040);
            this.cbSkewSpecularAlpha.Name = "cbSkewSpecularAlpha";
            this.cbSkewSpecularAlpha.Size = new System.Drawing.Size(100, 13);
            this.cbSkewSpecularAlpha.TabIndex = 56;
            this.cbSkewSpecularAlpha.UseVisualStyleBackColor = true;
            // 
            // numGrayscaleToPaletteScale
            // 
            this.numGrayscaleToPaletteScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numGrayscaleToPaletteScale.DecimalPlaces = 5;
            this.numGrayscaleToPaletteScale.Location = new System.Drawing.Point(13, 1018);
            this.numGrayscaleToPaletteScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGrayscaleToPaletteScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numGrayscaleToPaletteScale.Name = "numGrayscaleToPaletteScale";
            this.numGrayscaleToPaletteScale.Size = new System.Drawing.Size(271, 20);
            this.numGrayscaleToPaletteScale.TabIndex = 55;
            // 
            // numTessellationFadeDistance
            // 
            this.numTessellationFadeDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTessellationFadeDistance.DecimalPlaces = 5;
            this.numTessellationFadeDistance.Location = new System.Drawing.Point(13, 999);
            this.numTessellationFadeDistance.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numTessellationFadeDistance.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numTessellationFadeDistance.Name = "numTessellationFadeDistance";
            this.numTessellationFadeDistance.Size = new System.Drawing.Size(271, 20);
            this.numTessellationFadeDistance.TabIndex = 54;
            // 
            // numTessellationBaseFactor
            // 
            this.numTessellationBaseFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTessellationBaseFactor.DecimalPlaces = 5;
            this.numTessellationBaseFactor.Location = new System.Drawing.Point(13, 980);
            this.numTessellationBaseFactor.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numTessellationBaseFactor.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numTessellationBaseFactor.Name = "numTessellationBaseFactor";
            this.numTessellationBaseFactor.Size = new System.Drawing.Size(271, 20);
            this.numTessellationBaseFactor.TabIndex = 53;
            // 
            // numTessellationPNScale
            // 
            this.numTessellationPNScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTessellationPNScale.DecimalPlaces = 5;
            this.numTessellationPNScale.Location = new System.Drawing.Point(13, 961);
            this.numTessellationPNScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numTessellationPNScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numTessellationPNScale.Name = "numTessellationPNScale";
            this.numTessellationPNScale.Size = new System.Drawing.Size(271, 20);
            this.numTessellationPNScale.TabIndex = 52;
            // 
            // numDisplacementTexScale
            // 
            this.numDisplacementTexScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numDisplacementTexScale.DecimalPlaces = 5;
            this.numDisplacementTexScale.Location = new System.Drawing.Point(13, 942);
            this.numDisplacementTexScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numDisplacementTexScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numDisplacementTexScale.Name = "numDisplacementTexScale";
            this.numDisplacementTexScale.Size = new System.Drawing.Size(271, 20);
            this.numDisplacementTexScale.TabIndex = 51;
            // 
            // numDisplacementTexBias
            // 
            this.numDisplacementTexBias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numDisplacementTexBias.DecimalPlaces = 5;
            this.numDisplacementTexBias.Location = new System.Drawing.Point(13, 923);
            this.numDisplacementTexBias.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numDisplacementTexBias.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numDisplacementTexBias.Name = "numDisplacementTexBias";
            this.numDisplacementTexBias.Size = new System.Drawing.Size(271, 20);
            this.numDisplacementTexBias.TabIndex = 50;
            // 
            // cbTessellate
            // 
            this.cbTessellate.Location = new System.Drawing.Point(13, 907);
            this.cbTessellate.Name = "cbTessellate";
            this.cbTessellate.Size = new System.Drawing.Size(100, 13);
            this.cbTessellate.TabIndex = 49;
            this.cbTessellate.UseVisualStyleBackColor = true;
            // 
            // cbSkinTint
            // 
            this.cbSkinTint.Location = new System.Drawing.Point(13, 888);
            this.cbSkinTint.Name = "cbSkinTint";
            this.cbSkinTint.Size = new System.Drawing.Size(100, 13);
            this.cbSkinTint.TabIndex = 48;
            this.cbSkinTint.UseVisualStyleBackColor = true;
            // 
            // cbFacegen
            // 
            this.cbFacegen.Location = new System.Drawing.Point(13, 869);
            this.cbFacegen.Name = "cbFacegen";
            this.cbFacegen.Size = new System.Drawing.Size(100, 13);
            this.cbFacegen.TabIndex = 47;
            this.cbFacegen.UseVisualStyleBackColor = true;
            // 
            // cbTree
            // 
            this.cbTree.Location = new System.Drawing.Point(13, 850);
            this.cbTree.Name = "cbTree";
            this.cbTree.Size = new System.Drawing.Size(100, 13);
            this.cbTree.TabIndex = 46;
            this.cbTree.UseVisualStyleBackColor = true;
            // 
            // btHairTintColor
            // 
            this.btHairTintColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btHairTintColor.BackColor = System.Drawing.Color.White;
            this.btHairTintColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHairTintColor.Location = new System.Drawing.Point(13, 826);
            this.btHairTintColor.Name = "btHairTintColor";
            this.btHairTintColor.Size = new System.Drawing.Size(271, 20);
            this.btHairTintColor.TabIndex = 45;
            this.btHairTintColor.UseVisualStyleBackColor = false;
            this.btHairTintColor.Click += new System.EventHandler(this.ColorClicked);
            // 
            // cbHair
            // 
            this.cbHair.Location = new System.Drawing.Point(13, 812);
            this.cbHair.Name = "cbHair";
            this.cbHair.Size = new System.Drawing.Size(100, 13);
            this.cbHair.TabIndex = 44;
            this.cbHair.UseVisualStyleBackColor = true;
            // 
            // cbEnvironmentMapEye
            // 
            this.cbEnvironmentMapEye.Location = new System.Drawing.Point(13, 793);
            this.cbEnvironmentMapEye.Name = "cbEnvironmentMapEye";
            this.cbEnvironmentMapEye.Size = new System.Drawing.Size(100, 13);
            this.cbEnvironmentMapEye.TabIndex = 43;
            this.cbEnvironmentMapEye.UseVisualStyleBackColor = true;
            // 
            // cbEnvironmentMapWindow
            // 
            this.cbEnvironmentMapWindow.Location = new System.Drawing.Point(13, 774);
            this.cbEnvironmentMapWindow.Name = "cbEnvironmentMapWindow";
            this.cbEnvironmentMapWindow.Size = new System.Drawing.Size(100, 13);
            this.cbEnvironmentMapWindow.TabIndex = 42;
            this.cbEnvironmentMapWindow.UseVisualStyleBackColor = true;
            // 
            // cbGlowmap
            // 
            this.cbGlowmap.Location = new System.Drawing.Point(13, 755);
            this.cbGlowmap.Name = "cbGlowmap";
            this.cbGlowmap.Size = new System.Drawing.Size(100, 13);
            this.cbGlowmap.TabIndex = 41;
            this.cbGlowmap.UseVisualStyleBackColor = true;
            // 
            // cbAssumeShadowmask
            // 
            this.cbAssumeShadowmask.Location = new System.Drawing.Point(13, 736);
            this.cbAssumeShadowmask.Name = "cbAssumeShadowmask";
            this.cbAssumeShadowmask.Size = new System.Drawing.Size(100, 13);
            this.cbAssumeShadowmask.TabIndex = 40;
            this.cbAssumeShadowmask.UseVisualStyleBackColor = true;
            // 
            // cbDissolveFade
            // 
            this.cbDissolveFade.Location = new System.Drawing.Point(13, 717);
            this.cbDissolveFade.Name = "cbDissolveFade";
            this.cbDissolveFade.Size = new System.Drawing.Size(100, 13);
            this.cbDissolveFade.TabIndex = 39;
            this.cbDissolveFade.UseVisualStyleBackColor = true;
            // 
            // cbCastShadows
            // 
            this.cbCastShadows.Location = new System.Drawing.Point(13, 698);
            this.cbCastShadows.Name = "cbCastShadows";
            this.cbCastShadows.Size = new System.Drawing.Size(100, 13);
            this.cbCastShadows.TabIndex = 38;
            this.cbCastShadows.UseVisualStyleBackColor = true;
            // 
            // cbHideSecret
            // 
            this.cbHideSecret.Location = new System.Drawing.Point(13, 679);
            this.cbHideSecret.Name = "cbHideSecret";
            this.cbHideSecret.Size = new System.Drawing.Size(100, 13);
            this.cbHideSecret.TabIndex = 37;
            this.cbHideSecret.UseVisualStyleBackColor = true;
            // 
            // cbReceiveShadows
            // 
            this.cbReceiveShadows.Location = new System.Drawing.Point(13, 660);
            this.cbReceiveShadows.Name = "cbReceiveShadows";
            this.cbReceiveShadows.Size = new System.Drawing.Size(100, 13);
            this.cbReceiveShadows.TabIndex = 36;
            this.cbReceiveShadows.UseVisualStyleBackColor = true;
            // 
            // cbBackLighting
            // 
            this.cbBackLighting.Location = new System.Drawing.Point(13, 641);
            this.cbBackLighting.Name = "cbBackLighting";
            this.cbBackLighting.Size = new System.Drawing.Size(100, 13);
            this.cbBackLighting.TabIndex = 35;
            this.cbBackLighting.UseVisualStyleBackColor = true;
            // 
            // cbExternalEmittance
            // 
            this.cbExternalEmittance.Location = new System.Drawing.Point(13, 622);
            this.cbExternalEmittance.Name = "cbExternalEmittance";
            this.cbExternalEmittance.Size = new System.Drawing.Size(100, 13);
            this.cbExternalEmittance.TabIndex = 34;
            this.cbExternalEmittance.UseVisualStyleBackColor = true;
            // 
            // cbModelSpaceNormals
            // 
            this.cbModelSpaceNormals.Location = new System.Drawing.Point(13, 603);
            this.cbModelSpaceNormals.Name = "cbModelSpaceNormals";
            this.cbModelSpaceNormals.Size = new System.Drawing.Size(100, 13);
            this.cbModelSpaceNormals.TabIndex = 33;
            this.cbModelSpaceNormals.UseVisualStyleBackColor = true;
            // 
            // numEmittanceMultiplier
            // 
            this.numEmittanceMultiplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numEmittanceMultiplier.DecimalPlaces = 5;
            this.numEmittanceMultiplier.Location = new System.Drawing.Point(13, 581);
            this.numEmittanceMultiplier.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numEmittanceMultiplier.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numEmittanceMultiplier.Name = "numEmittanceMultiplier";
            this.numEmittanceMultiplier.Size = new System.Drawing.Size(271, 20);
            this.numEmittanceMultiplier.TabIndex = 32;
            // 
            // btEmittanceColor
            // 
            this.btEmittanceColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btEmittanceColor.BackColor = System.Drawing.Color.White;
            this.btEmittanceColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEmittanceColor.Location = new System.Drawing.Point(13, 560);
            this.btEmittanceColor.Name = "btEmittanceColor";
            this.btEmittanceColor.Size = new System.Drawing.Size(271, 20);
            this.btEmittanceColor.TabIndex = 31;
            this.btEmittanceColor.UseVisualStyleBackColor = false;
            this.btEmittanceColor.Click += new System.EventHandler(this.ColorClicked);
            // 
            // cbEmittanceEnabled
            // 
            this.cbEmittanceEnabled.Location = new System.Drawing.Point(13, 546);
            this.cbEmittanceEnabled.Name = "cbEmittanceEnabled";
            this.cbEmittanceEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbEmittanceEnabled.TabIndex = 30;
            this.cbEmittanceEnabled.UseVisualStyleBackColor = true;
            // 
            // cbAnisoLighting
            // 
            this.cbAnisoLighting.Location = new System.Drawing.Point(13, 527);
            this.cbAnisoLighting.Name = "cbAnisoLighting";
            this.cbAnisoLighting.Size = new System.Drawing.Size(100, 13);
            this.cbAnisoLighting.TabIndex = 29;
            this.cbAnisoLighting.UseVisualStyleBackColor = true;
            // 
            // tbRootMaterialPath
            // 
            this.tbRootMaterialPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootMaterialPath.Location = new System.Drawing.Point(13, 504);
            this.tbRootMaterialPath.MaxLength = 260;
            this.tbRootMaterialPath.Name = "tbRootMaterialPath";
            this.tbRootMaterialPath.Size = new System.Drawing.Size(271, 20);
            this.tbRootMaterialPath.TabIndex = 28;
            // 
            // numWetMetalness
            // 
            this.numWetMetalness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWetMetalness.DecimalPlaces = 5;
            this.numWetMetalness.Location = new System.Drawing.Point(13, 486);
            this.numWetMetalness.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numWetMetalness.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numWetMetalness.Name = "numWetMetalness";
            this.numWetMetalness.Size = new System.Drawing.Size(271, 20);
            this.numWetMetalness.TabIndex = 27;
            // 
            // numWetFresnelPower
            // 
            this.numWetFresnelPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWetFresnelPower.DecimalPlaces = 5;
            this.numWetFresnelPower.Location = new System.Drawing.Point(13, 467);
            this.numWetFresnelPower.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numWetFresnelPower.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numWetFresnelPower.Name = "numWetFresnelPower";
            this.numWetFresnelPower.Size = new System.Drawing.Size(271, 20);
            this.numWetFresnelPower.TabIndex = 26;
            // 
            // numWetEnvMapScale
            // 
            this.numWetEnvMapScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWetEnvMapScale.DecimalPlaces = 5;
            this.numWetEnvMapScale.Location = new System.Drawing.Point(13, 448);
            this.numWetEnvMapScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numWetEnvMapScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numWetEnvMapScale.Name = "numWetEnvMapScale";
            this.numWetEnvMapScale.Size = new System.Drawing.Size(271, 20);
            this.numWetEnvMapScale.TabIndex = 25;
            // 
            // numWetSpecMinVar
            // 
            this.numWetSpecMinVar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWetSpecMinVar.DecimalPlaces = 5;
            this.numWetSpecMinVar.Location = new System.Drawing.Point(13, 429);
            this.numWetSpecMinVar.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numWetSpecMinVar.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numWetSpecMinVar.Name = "numWetSpecMinVar";
            this.numWetSpecMinVar.Size = new System.Drawing.Size(271, 20);
            this.numWetSpecMinVar.TabIndex = 24;
            // 
            // numWetSpecPowerScale
            // 
            this.numWetSpecPowerScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWetSpecPowerScale.DecimalPlaces = 5;
            this.numWetSpecPowerScale.Location = new System.Drawing.Point(13, 410);
            this.numWetSpecPowerScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numWetSpecPowerScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numWetSpecPowerScale.Name = "numWetSpecPowerScale";
            this.numWetSpecPowerScale.Size = new System.Drawing.Size(271, 20);
            this.numWetSpecPowerScale.TabIndex = 23;
            // 
            // numWetSpecScale
            // 
            this.numWetSpecScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWetSpecScale.DecimalPlaces = 5;
            this.numWetSpecScale.Location = new System.Drawing.Point(13, 391);
            this.numWetSpecScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numWetSpecScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numWetSpecScale.Name = "numWetSpecScale";
            this.numWetSpecScale.Size = new System.Drawing.Size(271, 20);
            this.numWetSpecScale.TabIndex = 22;
            // 
            // numFresnelPower
            // 
            this.numFresnelPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numFresnelPower.DecimalPlaces = 5;
            this.numFresnelPower.Location = new System.Drawing.Point(13, 372);
            this.numFresnelPower.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numFresnelPower.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numFresnelPower.Name = "numFresnelPower";
            this.numFresnelPower.Size = new System.Drawing.Size(271, 20);
            this.numFresnelPower.TabIndex = 21;
            // 
            // numSmoothness
            // 
            this.numSmoothness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSmoothness.DecimalPlaces = 5;
            this.numSmoothness.Location = new System.Drawing.Point(13, 353);
            this.numSmoothness.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSmoothness.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numSmoothness.Name = "numSmoothness";
            this.numSmoothness.Size = new System.Drawing.Size(271, 20);
            this.numSmoothness.TabIndex = 20;
            // 
            // numSpecularMultiplier
            // 
            this.numSpecularMultiplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSpecularMultiplier.DecimalPlaces = 5;
            this.numSpecularMultiplier.Location = new System.Drawing.Point(13, 334);
            this.numSpecularMultiplier.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSpecularMultiplier.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numSpecularMultiplier.Name = "numSpecularMultiplier";
            this.numSpecularMultiplier.Size = new System.Drawing.Size(271, 20);
            this.numSpecularMultiplier.TabIndex = 19;
            // 
            // btSpecularColor
            // 
            this.btSpecularColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btSpecularColor.BackColor = System.Drawing.Color.White;
            this.btSpecularColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSpecularColor.Location = new System.Drawing.Point(13, 313);
            this.btSpecularColor.Name = "btSpecularColor";
            this.btSpecularColor.Size = new System.Drawing.Size(271, 20);
            this.btSpecularColor.TabIndex = 18;
            this.btSpecularColor.UseVisualStyleBackColor = false;
            this.btSpecularColor.Click += new System.EventHandler(this.ColorClicked);
            // 
            // cbSpecularEnabled
            // 
            this.cbSpecularEnabled.Location = new System.Drawing.Point(13, 299);
            this.cbSpecularEnabled.Name = "cbSpecularEnabled";
            this.cbSpecularEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbSpecularEnabled.TabIndex = 17;
            this.cbSpecularEnabled.UseVisualStyleBackColor = true;
            // 
            // numSubsurfaceLightingRolloff
            // 
            this.numSubsurfaceLightingRolloff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSubsurfaceLightingRolloff.DecimalPlaces = 5;
            this.numSubsurfaceLightingRolloff.Location = new System.Drawing.Point(13, 277);
            this.numSubsurfaceLightingRolloff.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSubsurfaceLightingRolloff.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numSubsurfaceLightingRolloff.Name = "numSubsurfaceLightingRolloff";
            this.numSubsurfaceLightingRolloff.Size = new System.Drawing.Size(271, 20);
            this.numSubsurfaceLightingRolloff.TabIndex = 16;
            // 
            // cbSubsurfaceLighting
            // 
            this.cbSubsurfaceLighting.Location = new System.Drawing.Point(13, 261);
            this.cbSubsurfaceLighting.Name = "cbSubsurfaceLighting";
            this.cbSubsurfaceLighting.Size = new System.Drawing.Size(100, 13);
            this.cbSubsurfaceLighting.TabIndex = 15;
            this.cbSubsurfaceLighting.UseVisualStyleBackColor = true;
            // 
            // numBacklightPower
            // 
            this.numBacklightPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numBacklightPower.DecimalPlaces = 5;
            this.numBacklightPower.Location = new System.Drawing.Point(13, 239);
            this.numBacklightPower.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBacklightPower.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numBacklightPower.Name = "numBacklightPower";
            this.numBacklightPower.Size = new System.Drawing.Size(271, 20);
            this.numBacklightPower.TabIndex = 14;
            // 
            // cbRimLighting
            // 
            this.cbRimLighting.Location = new System.Drawing.Point(13, 204);
            this.cbRimLighting.Name = "cbRimLighting";
            this.cbRimLighting.Size = new System.Drawing.Size(100, 13);
            this.cbRimLighting.TabIndex = 13;
            this.cbRimLighting.UseVisualStyleBackColor = true;
            // 
            // tbDisplacementTexture
            // 
            this.tbDisplacementTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplacementTexture.Location = new System.Drawing.Point(13, 162);
            this.tbDisplacementTexture.MaxLength = 260;
            this.tbDisplacementTexture.Name = "tbDisplacementTexture";
            this.tbDisplacementTexture.Size = new System.Drawing.Size(271, 20);
            this.tbDisplacementTexture.TabIndex = 12;
            // 
            // tbWrinklesTexture
            // 
            this.tbWrinklesTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWrinklesTexture.Location = new System.Drawing.Point(13, 143);
            this.tbWrinklesTexture.MaxLength = 260;
            this.tbWrinklesTexture.Name = "tbWrinklesTexture";
            this.tbWrinklesTexture.Size = new System.Drawing.Size(271, 20);
            this.tbWrinklesTexture.TabIndex = 11;
            // 
            // tbInnerLayerTexture
            // 
            this.tbInnerLayerTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInnerLayerTexture.Location = new System.Drawing.Point(13, 124);
            this.tbInnerLayerTexture.MaxLength = 260;
            this.tbInnerLayerTexture.Name = "tbInnerLayerTexture";
            this.tbInnerLayerTexture.Size = new System.Drawing.Size(271, 20);
            this.tbInnerLayerTexture.TabIndex = 10;
            // 
            // tbGlowTexture
            // 
            this.tbGlowTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGlowTexture.Location = new System.Drawing.Point(13, 105);
            this.tbGlowTexture.MaxLength = 260;
            this.tbGlowTexture.Name = "tbGlowTexture";
            this.tbGlowTexture.Size = new System.Drawing.Size(271, 20);
            this.tbGlowTexture.TabIndex = 9;
            // 
            // tbEnvironmentMapTexture
            // 
            this.tbEnvironmentMapTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEnvironmentMapTexture.Location = new System.Drawing.Point(13, 86);
            this.tbEnvironmentMapTexture.MaxLength = 260;
            this.tbEnvironmentMapTexture.Name = "tbEnvironmentMapTexture";
            this.tbEnvironmentMapTexture.Size = new System.Drawing.Size(271, 20);
            this.tbEnvironmentMapTexture.TabIndex = 8;
            // 
            // tbGreyscaleTexture
            // 
            this.tbGreyscaleTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGreyscaleTexture.Location = new System.Drawing.Point(13, 67);
            this.tbGreyscaleTexture.MaxLength = 260;
            this.tbGreyscaleTexture.Name = "tbGreyscaleTexture";
            this.tbGreyscaleTexture.Size = new System.Drawing.Size(271, 20);
            this.tbGreyscaleTexture.TabIndex = 7;
            // 
            // tbSmoothSpecularTexture
            // 
            this.tbSmoothSpecularTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSmoothSpecularTexture.Location = new System.Drawing.Point(13, 48);
            this.tbSmoothSpecularTexture.MaxLength = 260;
            this.tbSmoothSpecularTexture.Name = "tbSmoothSpecularTexture";
            this.tbSmoothSpecularTexture.Size = new System.Drawing.Size(271, 20);
            this.tbSmoothSpecularTexture.TabIndex = 6;
            // 
            // tbNormalTexture
            // 
            this.tbNormalTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNormalTexture.Location = new System.Drawing.Point(13, 29);
            this.tbNormalTexture.MaxLength = 260;
            this.tbNormalTexture.Name = "tbNormalTexture";
            this.tbNormalTexture.Size = new System.Drawing.Size(271, 20);
            this.tbNormalTexture.TabIndex = 5;
            // 
            // tbDiffuseTexture
            // 
            this.tbDiffuseTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDiffuseTexture.Location = new System.Drawing.Point(13, 10);
            this.tbDiffuseTexture.MaxLength = 260;
            this.tbDiffuseTexture.Name = "tbDiffuseTexture";
            this.tbDiffuseTexture.Size = new System.Drawing.Size(271, 20);
            this.tbDiffuseTexture.TabIndex = 4;
            // 
            // numRimPower
            // 
            this.numRimPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numRimPower.DecimalPlaces = 5;
            this.numRimPower.Location = new System.Drawing.Point(13, 220);
            this.numRimPower.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numRimPower.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numRimPower.Name = "numRimPower";
            this.numRimPower.Size = new System.Drawing.Size(271, 20);
            this.numRimPower.TabIndex = 3;
            // 
            // cbEnableEditorAlphaRef
            // 
            this.cbEnableEditorAlphaRef.Location = new System.Drawing.Point(13, 185);
            this.cbEnableEditorAlphaRef.Name = "cbEnableEditorAlphaRef";
            this.cbEnableEditorAlphaRef.Size = new System.Drawing.Size(100, 13);
            this.cbEnableEditorAlphaRef.TabIndex = 1;
            this.cbEnableEditorAlphaRef.UseVisualStyleBackColor = true;
            // 
            // tabPageEffect
            // 
            this.tabPageEffect.AutoScroll = true;
            this.tabPageEffect.Controls.Add(this.splitContainerEffect);
            this.tabPageEffect.Location = new System.Drawing.Point(4, 22);
            this.tabPageEffect.Name = "tabPageEffect";
            this.tabPageEffect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEffect.Size = new System.Drawing.Size(476, 507);
            this.tabPageEffect.TabIndex = 1;
            this.tabPageEffect.Text = "Effect";
            this.tabPageEffect.UseVisualStyleBackColor = true;
            this.tabPageEffect.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TabScroll);
            // 
            // splitContainerEffect
            // 
            this.splitContainerEffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerEffect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerEffect.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerEffect.IsSplitterFixed = true;
            this.splitContainerEffect.Location = new System.Drawing.Point(4, 4);
            this.splitContainerEffect.Name = "splitContainerEffect";
            // 
            // splitContainerEffect.Panel1
            // 
            this.splitContainerEffect.Panel1.Controls.Add(this.lbSoftDepth);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbEnvmapMinLOD);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbLightingInfluence);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbFalloffStopOpacity);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbFalloffStartOpacity);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbFalloffStopAngle);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbFalloffStartAngle);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbBaseColorScale);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbBaseColor);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbSoftEnabled);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbGrayscaleToPaletteAlpha);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbFalloffColorEnabled);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbFalloffEnabled);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbEffectLightingEnabled);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbBloodEnabled);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbEnvmapMaskTexture);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbNormalTexture_effect);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbEnvmapTexture);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbGrayscaleTexture);
            this.splitContainerEffect.Panel1.Controls.Add(this.lbBaseTexture);
            this.splitContainerEffect.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerEffect.Panel1MinSize = 165;
            // 
            // splitContainerEffect.Panel2
            // 
            this.splitContainerEffect.Panel2.Controls.Add(this.numSoftDepth);
            this.splitContainerEffect.Panel2.Controls.Add(this.numLightingInfluence);
            this.splitContainerEffect.Panel2.Controls.Add(this.numFalloffStopOpacity);
            this.splitContainerEffect.Panel2.Controls.Add(this.numFalloffStartOpacity);
            this.splitContainerEffect.Panel2.Controls.Add(this.numFalloffStopAngle);
            this.splitContainerEffect.Panel2.Controls.Add(this.numFalloffStartAngle);
            this.splitContainerEffect.Panel2.Controls.Add(this.btBaseColor);
            this.splitContainerEffect.Panel2.Controls.Add(this.cbSoftEnabled);
            this.splitContainerEffect.Panel2.Controls.Add(this.cbGrayscaleToPaletteAlpha);
            this.splitContainerEffect.Panel2.Controls.Add(this.cbFalloffColorEnabled);
            this.splitContainerEffect.Panel2.Controls.Add(this.cbFalloffEnabled);
            this.splitContainerEffect.Panel2.Controls.Add(this.cbEffectLightingEnabled);
            this.splitContainerEffect.Panel2.Controls.Add(this.tbEnvmapMaskTexture);
            this.splitContainerEffect.Panel2.Controls.Add(this.tbNormalTexture_effect);
            this.splitContainerEffect.Panel2.Controls.Add(this.tbEnvmapTexture);
            this.splitContainerEffect.Panel2.Controls.Add(this.tbGrayscaleTexture);
            this.splitContainerEffect.Panel2.Controls.Add(this.tbBaseTexture);
            this.splitContainerEffect.Panel2.Controls.Add(this.cbBloodEnabled);
            this.splitContainerEffect.Panel2.Controls.Add(this.numEnvmapMinLOD);
            this.splitContainerEffect.Panel2.Controls.Add(this.numBaseColorScale);
            this.splitContainerEffect.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerEffect.Panel2MinSize = 165;
            this.splitContainerEffect.Size = new System.Drawing.Size(469, 405);
            this.splitContainerEffect.SplitterDistance = 165;
            this.splitContainerEffect.TabIndex = 2;
            // 
            // lbSoftDepth
            // 
            this.lbSoftDepth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSoftDepth.Location = new System.Drawing.Point(13, 374);
            this.lbSoftDepth.Margin = new System.Windows.Forms.Padding(3);
            this.lbSoftDepth.Name = "lbSoftDepth";
            this.lbSoftDepth.Size = new System.Drawing.Size(137, 13);
            this.lbSoftDepth.TabIndex = 19;
            this.lbSoftDepth.Text = "Soft Depth";
            // 
            // lbEnvmapMinLOD
            // 
            this.lbEnvmapMinLOD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvmapMinLOD.Location = new System.Drawing.Point(13, 355);
            this.lbEnvmapMinLOD.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvmapMinLOD.Name = "lbEnvmapMinLOD";
            this.lbEnvmapMinLOD.Size = new System.Drawing.Size(137, 13);
            this.lbEnvmapMinLOD.TabIndex = 18;
            this.lbEnvmapMinLOD.Text = "Envmap Min LOD";
            // 
            // lbLightingInfluence
            // 
            this.lbLightingInfluence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLightingInfluence.Location = new System.Drawing.Point(13, 336);
            this.lbLightingInfluence.Margin = new System.Windows.Forms.Padding(3);
            this.lbLightingInfluence.Name = "lbLightingInfluence";
            this.lbLightingInfluence.Size = new System.Drawing.Size(137, 13);
            this.lbLightingInfluence.TabIndex = 17;
            this.lbLightingInfluence.Text = "Lighting Influence";
            // 
            // lbFalloffStopOpacity
            // 
            this.lbFalloffStopOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFalloffStopOpacity.Location = new System.Drawing.Point(13, 317);
            this.lbFalloffStopOpacity.Margin = new System.Windows.Forms.Padding(3);
            this.lbFalloffStopOpacity.Name = "lbFalloffStopOpacity";
            this.lbFalloffStopOpacity.Size = new System.Drawing.Size(137, 13);
            this.lbFalloffStopOpacity.TabIndex = 16;
            this.lbFalloffStopOpacity.Text = "Falloff Stop Opacity";
            // 
            // lbFalloffStartOpacity
            // 
            this.lbFalloffStartOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFalloffStartOpacity.Location = new System.Drawing.Point(13, 298);
            this.lbFalloffStartOpacity.Margin = new System.Windows.Forms.Padding(3);
            this.lbFalloffStartOpacity.Name = "lbFalloffStartOpacity";
            this.lbFalloffStartOpacity.Size = new System.Drawing.Size(137, 13);
            this.lbFalloffStartOpacity.TabIndex = 15;
            this.lbFalloffStartOpacity.Text = "Falloff Start Opacity";
            // 
            // lbFalloffStopAngle
            // 
            this.lbFalloffStopAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFalloffStopAngle.Location = new System.Drawing.Point(13, 279);
            this.lbFalloffStopAngle.Margin = new System.Windows.Forms.Padding(3);
            this.lbFalloffStopAngle.Name = "lbFalloffStopAngle";
            this.lbFalloffStopAngle.Size = new System.Drawing.Size(137, 13);
            this.lbFalloffStopAngle.TabIndex = 14;
            this.lbFalloffStopAngle.Text = "Falloff Stop Angle";
            // 
            // lbFalloffStartAngle
            // 
            this.lbFalloffStartAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFalloffStartAngle.Location = new System.Drawing.Point(13, 260);
            this.lbFalloffStartAngle.Margin = new System.Windows.Forms.Padding(3);
            this.lbFalloffStartAngle.Name = "lbFalloffStartAngle";
            this.lbFalloffStartAngle.Size = new System.Drawing.Size(137, 13);
            this.lbFalloffStartAngle.TabIndex = 13;
            this.lbFalloffStartAngle.Text = "Falloff Start Angle";
            // 
            // lbBaseColorScale
            // 
            this.lbBaseColorScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBaseColorScale.Location = new System.Drawing.Point(13, 241);
            this.lbBaseColorScale.Margin = new System.Windows.Forms.Padding(3);
            this.lbBaseColorScale.Name = "lbBaseColorScale";
            this.lbBaseColorScale.Size = new System.Drawing.Size(137, 13);
            this.lbBaseColorScale.TabIndex = 12;
            this.lbBaseColorScale.Text = "Base Color Scale";
            // 
            // lbBaseColor
            // 
            this.lbBaseColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBaseColor.Location = new System.Drawing.Point(13, 222);
            this.lbBaseColor.Margin = new System.Windows.Forms.Padding(3);
            this.lbBaseColor.Name = "lbBaseColor";
            this.lbBaseColor.Size = new System.Drawing.Size(137, 13);
            this.lbBaseColor.TabIndex = 11;
            this.lbBaseColor.Text = "Base Color";
            // 
            // lbSoftEnabled
            // 
            this.lbSoftEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSoftEnabled.Location = new System.Drawing.Point(13, 203);
            this.lbSoftEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbSoftEnabled.Name = "lbSoftEnabled";
            this.lbSoftEnabled.Size = new System.Drawing.Size(137, 13);
            this.lbSoftEnabled.TabIndex = 10;
            this.lbSoftEnabled.Text = "Soft Enabled";
            // 
            // lbGrayscaleToPaletteAlpha
            // 
            this.lbGrayscaleToPaletteAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGrayscaleToPaletteAlpha.Location = new System.Drawing.Point(13, 184);
            this.lbGrayscaleToPaletteAlpha.Margin = new System.Windows.Forms.Padding(3);
            this.lbGrayscaleToPaletteAlpha.Name = "lbGrayscaleToPaletteAlpha";
            this.lbGrayscaleToPaletteAlpha.Size = new System.Drawing.Size(137, 13);
            this.lbGrayscaleToPaletteAlpha.TabIndex = 9;
            this.lbGrayscaleToPaletteAlpha.Text = "Grayscale To Palette Alpha";
            // 
            // lbFalloffColorEnabled
            // 
            this.lbFalloffColorEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFalloffColorEnabled.Location = new System.Drawing.Point(13, 165);
            this.lbFalloffColorEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbFalloffColorEnabled.Name = "lbFalloffColorEnabled";
            this.lbFalloffColorEnabled.Size = new System.Drawing.Size(137, 13);
            this.lbFalloffColorEnabled.TabIndex = 8;
            this.lbFalloffColorEnabled.Text = "Falloff Color Enabled";
            // 
            // lbFalloffEnabled
            // 
            this.lbFalloffEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFalloffEnabled.Location = new System.Drawing.Point(13, 146);
            this.lbFalloffEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbFalloffEnabled.Name = "lbFalloffEnabled";
            this.lbFalloffEnabled.Size = new System.Drawing.Size(137, 13);
            this.lbFalloffEnabled.TabIndex = 7;
            this.lbFalloffEnabled.Text = "Falloff Enabled";
            // 
            // lbEffectLightingEnabled
            // 
            this.lbEffectLightingEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEffectLightingEnabled.Location = new System.Drawing.Point(13, 127);
            this.lbEffectLightingEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbEffectLightingEnabled.Name = "lbEffectLightingEnabled";
            this.lbEffectLightingEnabled.Size = new System.Drawing.Size(137, 13);
            this.lbEffectLightingEnabled.TabIndex = 6;
            this.lbEffectLightingEnabled.Text = "Effect Lighting Enabled";
            // 
            // lbBloodEnabled
            // 
            this.lbBloodEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBloodEnabled.Location = new System.Drawing.Point(13, 108);
            this.lbBloodEnabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbBloodEnabled.Name = "lbBloodEnabled";
            this.lbBloodEnabled.Size = new System.Drawing.Size(137, 13);
            this.lbBloodEnabled.TabIndex = 5;
            this.lbBloodEnabled.Text = "Blood Enabled";
            // 
            // lbEnvmapMaskTexture
            // 
            this.lbEnvmapMaskTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvmapMaskTexture.Location = new System.Drawing.Point(13, 89);
            this.lbEnvmapMaskTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvmapMaskTexture.Name = "lbEnvmapMaskTexture";
            this.lbEnvmapMaskTexture.Size = new System.Drawing.Size(137, 13);
            this.lbEnvmapMaskTexture.TabIndex = 4;
            this.lbEnvmapMaskTexture.Text = "Envmap Mask Texture";
            // 
            // lbNormalTexture_effect
            // 
            this.lbNormalTexture_effect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNormalTexture_effect.Location = new System.Drawing.Point(13, 70);
            this.lbNormalTexture_effect.Margin = new System.Windows.Forms.Padding(3);
            this.lbNormalTexture_effect.Name = "lbNormalTexture_effect";
            this.lbNormalTexture_effect.Size = new System.Drawing.Size(137, 13);
            this.lbNormalTexture_effect.TabIndex = 3;
            this.lbNormalTexture_effect.Text = "Normal Texture";
            // 
            // lbEnvmapTexture
            // 
            this.lbEnvmapTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEnvmapTexture.Location = new System.Drawing.Point(13, 51);
            this.lbEnvmapTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnvmapTexture.Name = "lbEnvmapTexture";
            this.lbEnvmapTexture.Size = new System.Drawing.Size(137, 13);
            this.lbEnvmapTexture.TabIndex = 2;
            this.lbEnvmapTexture.Text = "Envmap Texture";
            // 
            // lbGrayscaleTexture
            // 
            this.lbGrayscaleTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGrayscaleTexture.Location = new System.Drawing.Point(13, 32);
            this.lbGrayscaleTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbGrayscaleTexture.Name = "lbGrayscaleTexture";
            this.lbGrayscaleTexture.Size = new System.Drawing.Size(137, 13);
            this.lbGrayscaleTexture.TabIndex = 1;
            this.lbGrayscaleTexture.Text = "Grayscale Texture";
            // 
            // lbBaseTexture
            // 
            this.lbBaseTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBaseTexture.Location = new System.Drawing.Point(13, 13);
            this.lbBaseTexture.Margin = new System.Windows.Forms.Padding(3);
            this.lbBaseTexture.Name = "lbBaseTexture";
            this.lbBaseTexture.Size = new System.Drawing.Size(137, 13);
            this.lbBaseTexture.TabIndex = 0;
            this.lbBaseTexture.Text = "Base Texture";
            // 
            // numSoftDepth
            // 
            this.numSoftDepth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoftDepth.DecimalPlaces = 5;
            this.numSoftDepth.Location = new System.Drawing.Point(13, 372);
            this.numSoftDepth.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSoftDepth.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numSoftDepth.Name = "numSoftDepth";
            this.numSoftDepth.Size = new System.Drawing.Size(272, 20);
            this.numSoftDepth.TabIndex = 39;
            // 
            // numLightingInfluence
            // 
            this.numLightingInfluence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numLightingInfluence.DecimalPlaces = 5;
            this.numLightingInfluence.Location = new System.Drawing.Point(13, 334);
            this.numLightingInfluence.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numLightingInfluence.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numLightingInfluence.Name = "numLightingInfluence";
            this.numLightingInfluence.Size = new System.Drawing.Size(272, 20);
            this.numLightingInfluence.TabIndex = 38;
            // 
            // numFalloffStopOpacity
            // 
            this.numFalloffStopOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numFalloffStopOpacity.DecimalPlaces = 5;
            this.numFalloffStopOpacity.Location = new System.Drawing.Point(13, 315);
            this.numFalloffStopOpacity.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numFalloffStopOpacity.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numFalloffStopOpacity.Name = "numFalloffStopOpacity";
            this.numFalloffStopOpacity.Size = new System.Drawing.Size(272, 20);
            this.numFalloffStopOpacity.TabIndex = 37;
            // 
            // numFalloffStartOpacity
            // 
            this.numFalloffStartOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numFalloffStartOpacity.DecimalPlaces = 5;
            this.numFalloffStartOpacity.Location = new System.Drawing.Point(13, 296);
            this.numFalloffStartOpacity.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numFalloffStartOpacity.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numFalloffStartOpacity.Name = "numFalloffStartOpacity";
            this.numFalloffStartOpacity.Size = new System.Drawing.Size(272, 20);
            this.numFalloffStartOpacity.TabIndex = 36;
            // 
            // numFalloffStopAngle
            // 
            this.numFalloffStopAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numFalloffStopAngle.DecimalPlaces = 5;
            this.numFalloffStopAngle.Location = new System.Drawing.Point(13, 277);
            this.numFalloffStopAngle.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numFalloffStopAngle.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numFalloffStopAngle.Name = "numFalloffStopAngle";
            this.numFalloffStopAngle.Size = new System.Drawing.Size(272, 20);
            this.numFalloffStopAngle.TabIndex = 35;
            // 
            // numFalloffStartAngle
            // 
            this.numFalloffStartAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numFalloffStartAngle.DecimalPlaces = 5;
            this.numFalloffStartAngle.Location = new System.Drawing.Point(13, 258);
            this.numFalloffStartAngle.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numFalloffStartAngle.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numFalloffStartAngle.Name = "numFalloffStartAngle";
            this.numFalloffStartAngle.Size = new System.Drawing.Size(272, 20);
            this.numFalloffStartAngle.TabIndex = 34;
            // 
            // btBaseColor
            // 
            this.btBaseColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btBaseColor.BackColor = System.Drawing.Color.White;
            this.btBaseColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBaseColor.Location = new System.Drawing.Point(13, 218);
            this.btBaseColor.Name = "btBaseColor";
            this.btBaseColor.Size = new System.Drawing.Size(272, 20);
            this.btBaseColor.TabIndex = 33;
            this.btBaseColor.UseVisualStyleBackColor = false;
            this.btBaseColor.Click += new System.EventHandler(this.ColorClicked);
            // 
            // cbSoftEnabled
            // 
            this.cbSoftEnabled.Location = new System.Drawing.Point(13, 204);
            this.cbSoftEnabled.Name = "cbSoftEnabled";
            this.cbSoftEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbSoftEnabled.TabIndex = 32;
            this.cbSoftEnabled.UseVisualStyleBackColor = true;
            // 
            // cbGrayscaleToPaletteAlpha
            // 
            this.cbGrayscaleToPaletteAlpha.Location = new System.Drawing.Point(13, 185);
            this.cbGrayscaleToPaletteAlpha.Name = "cbGrayscaleToPaletteAlpha";
            this.cbGrayscaleToPaletteAlpha.Size = new System.Drawing.Size(100, 13);
            this.cbGrayscaleToPaletteAlpha.TabIndex = 31;
            this.cbGrayscaleToPaletteAlpha.UseVisualStyleBackColor = true;
            // 
            // cbFalloffColorEnabled
            // 
            this.cbFalloffColorEnabled.Location = new System.Drawing.Point(13, 166);
            this.cbFalloffColorEnabled.Name = "cbFalloffColorEnabled";
            this.cbFalloffColorEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbFalloffColorEnabled.TabIndex = 30;
            this.cbFalloffColorEnabled.UseVisualStyleBackColor = true;
            // 
            // cbFalloffEnabled
            // 
            this.cbFalloffEnabled.Location = new System.Drawing.Point(13, 147);
            this.cbFalloffEnabled.Name = "cbFalloffEnabled";
            this.cbFalloffEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbFalloffEnabled.TabIndex = 29;
            this.cbFalloffEnabled.UseVisualStyleBackColor = true;
            // 
            // cbEffectLightingEnabled
            // 
            this.cbEffectLightingEnabled.Location = new System.Drawing.Point(13, 128);
            this.cbEffectLightingEnabled.Name = "cbEffectLightingEnabled";
            this.cbEffectLightingEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbEffectLightingEnabled.TabIndex = 28;
            this.cbEffectLightingEnabled.UseVisualStyleBackColor = true;
            // 
            // tbEnvmapMaskTexture
            // 
            this.tbEnvmapMaskTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEnvmapMaskTexture.Location = new System.Drawing.Point(13, 86);
            this.tbEnvmapMaskTexture.MaxLength = 260;
            this.tbEnvmapMaskTexture.Name = "tbEnvmapMaskTexture";
            this.tbEnvmapMaskTexture.Size = new System.Drawing.Size(272, 20);
            this.tbEnvmapMaskTexture.TabIndex = 27;
            // 
            // tbNormalTexture_effect
            // 
            this.tbNormalTexture_effect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNormalTexture_effect.Location = new System.Drawing.Point(13, 67);
            this.tbNormalTexture_effect.MaxLength = 260;
            this.tbNormalTexture_effect.Name = "tbNormalTexture_effect";
            this.tbNormalTexture_effect.Size = new System.Drawing.Size(272, 20);
            this.tbNormalTexture_effect.TabIndex = 26;
            // 
            // tbEnvmapTexture
            // 
            this.tbEnvmapTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEnvmapTexture.Location = new System.Drawing.Point(13, 48);
            this.tbEnvmapTexture.MaxLength = 260;
            this.tbEnvmapTexture.Name = "tbEnvmapTexture";
            this.tbEnvmapTexture.Size = new System.Drawing.Size(272, 20);
            this.tbEnvmapTexture.TabIndex = 25;
            // 
            // tbGrayscaleTexture
            // 
            this.tbGrayscaleTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGrayscaleTexture.Location = new System.Drawing.Point(13, 29);
            this.tbGrayscaleTexture.MaxLength = 260;
            this.tbGrayscaleTexture.Name = "tbGrayscaleTexture";
            this.tbGrayscaleTexture.Size = new System.Drawing.Size(272, 20);
            this.tbGrayscaleTexture.TabIndex = 24;
            // 
            // tbBaseTexture
            // 
            this.tbBaseTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseTexture.Location = new System.Drawing.Point(13, 10);
            this.tbBaseTexture.MaxLength = 260;
            this.tbBaseTexture.Name = "tbBaseTexture";
            this.tbBaseTexture.Size = new System.Drawing.Size(272, 20);
            this.tbBaseTexture.TabIndex = 23;
            // 
            // cbBloodEnabled
            // 
            this.cbBloodEnabled.Location = new System.Drawing.Point(13, 109);
            this.cbBloodEnabled.Name = "cbBloodEnabled";
            this.cbBloodEnabled.Size = new System.Drawing.Size(100, 13);
            this.cbBloodEnabled.TabIndex = 22;
            this.cbBloodEnabled.UseVisualStyleBackColor = true;
            // 
            // numEnvmapMinLOD
            // 
            this.numEnvmapMinLOD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numEnvmapMinLOD.Location = new System.Drawing.Point(13, 353);
            this.numEnvmapMinLOD.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numEnvmapMinLOD.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.numEnvmapMinLOD.Name = "numEnvmapMinLOD";
            this.numEnvmapMinLOD.Size = new System.Drawing.Size(272, 20);
            this.numEnvmapMinLOD.TabIndex = 9;
            // 
            // numBaseColorScale
            // 
            this.numBaseColorScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numBaseColorScale.DecimalPlaces = 5;
            this.numBaseColorScale.Location = new System.Drawing.Point(13, 239);
            this.numBaseColorScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBaseColorScale.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numBaseColorScale.Name = "numBaseColorScale";
            this.numBaseColorScale.Size = new System.Drawing.Size(272, 20);
            this.numBaseColorScale.TabIndex = 3;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(385, 246);
            this.Name = "Main";
            this.Text = "Material Editor";
            this.ResizeBegin += new System.EventHandler(this.Main_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.splitContainerGeneral.Panel1.ResumeLayout(false);
            this.splitContainerGeneral.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneral)).EndInit();
            this.splitContainerGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numEnvironmentMaskScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefractionPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlphaTestReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).EndInit();
            this.tabPageMaterial.ResumeLayout(false);
            this.splitContainerMaterial.Panel1.ResumeLayout(false);
            this.splitContainerMaterial.Panel2.ResumeLayout(false);
            this.splitContainerMaterial.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMaterial)).EndInit();
            this.splitContainerMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGrayscaleToPaletteScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTessellationFadeDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTessellationBaseFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTessellationPNScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplacementTexScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplacementTexBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEmittanceMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetMetalness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetFresnelPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetEnvMapScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetSpecMinVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetSpecPowerScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWetSpecScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFresnelPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSmoothness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecularMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubsurfaceLightingRolloff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBacklightPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRimPower)).EndInit();
            this.tabPageEffect.ResumeLayout(false);
            this.splitContainerEffect.Panel1.ResumeLayout(false);
            this.splitContainerEffect.Panel2.ResumeLayout(false);
            this.splitContainerEffect.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEffect)).EndInit();
            this.splitContainerEffect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoftDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLightingInfluence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStopOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStartOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStopAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFalloffStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnvmapMinLOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseColorScale)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageEffect;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.SplitContainer splitContainerGeneral;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbTileU;
        private System.Windows.Forms.Label lbTileV;
        private System.Windows.Forms.Label lbOffsetV;
        private System.Windows.Forms.Label lbOffsetU;
        private System.Windows.Forms.Label lbScaleV;
        private System.Windows.Forms.Label lbScaleU;
        private System.Windows.Forms.Label lbAlpha;
        private System.Windows.Forms.Label lbZBufferTest;
        private System.Windows.Forms.Label lbZBufferWrite;
        private System.Windows.Forms.Label lbAlphaTest;
        private System.Windows.Forms.Label lbAlphaTestReference;
        private System.Windows.Forms.Label lbAlphaBlendMode;
        private System.Windows.Forms.Label lbScreenSpaceReflections;
        private System.Windows.Forms.Label lbWetnessControlSSR;
        private System.Windows.Forms.Label lbTwoSided;
        private System.Windows.Forms.Label lbDecal;
        private System.Windows.Forms.Label lbDecalNoFade;
        private System.Windows.Forms.Label lbRefraction;
        private System.Windows.Forms.Label lbNonOccluder;
        private System.Windows.Forms.Label lbEnvironmentMapping;
        private System.Windows.Forms.Label lbRefractionPower;
        private System.Windows.Forms.Label lbRefractionFalloff;
        private System.Windows.Forms.Label lbEnvironmentMaskScale;
        private System.Windows.Forms.Label lbGrayscaleToPaletteColor;
        private System.Windows.Forms.NumericUpDown numVersion;
        private System.Windows.Forms.CheckBox cbTileU;
        private System.Windows.Forms.CheckBox cbTileV;
        private System.Windows.Forms.NumericUpDown numOffsetU;
        private System.Windows.Forms.NumericUpDown numOffsetV;
        private System.Windows.Forms.NumericUpDown numScaleV;
        private System.Windows.Forms.NumericUpDown numScaleU;
        private System.Windows.Forms.ComboBox selAlphaBlendMode;
        private System.Windows.Forms.NumericUpDown numAlpha;
        private System.Windows.Forms.NumericUpDown numAlphaTestReference;
        private System.Windows.Forms.CheckBox cbZBufferTest;
        private System.Windows.Forms.CheckBox cbZBufferWrite;
        private System.Windows.Forms.CheckBox cbAlphaTest;
        private System.Windows.Forms.CheckBox cbNonOccluder;
        private System.Windows.Forms.CheckBox cbDecalNoFade;
        private System.Windows.Forms.CheckBox cbTwoSided;
        private System.Windows.Forms.CheckBox cbDecal;
        private System.Windows.Forms.CheckBox cbWetnessControlSSR;
        private System.Windows.Forms.CheckBox cbScreenSpaceReflections;
        private System.Windows.Forms.NumericUpDown numRefractionPower;
        private System.Windows.Forms.CheckBox cbRefractionFalloff;
        private System.Windows.Forms.CheckBox cbRefraction;
        private System.Windows.Forms.CheckBox cbGrayscaleToPaletteColor;
        private System.Windows.Forms.NumericUpDown numEnvironmentMaskScale;
        private System.Windows.Forms.CheckBox cbEnvironmentMapping;
        private System.Windows.Forms.SplitContainer splitContainerMaterial;
        private System.Windows.Forms.Label lbDiffuseTexture;
        private System.Windows.Forms.NumericUpDown numRimPower;
        private System.Windows.Forms.CheckBox cbEnableEditorAlphaRef;
        private System.Windows.Forms.Label lbGreyscaleTexture;
        private System.Windows.Forms.Label lbSmoothSpecularTexture;
        private System.Windows.Forms.Label lbNormalTexture;
        private System.Windows.Forms.Label lbEnvironmentMapTexture;
        private System.Windows.Forms.Label lbWrinklesTexture;
        private System.Windows.Forms.Label lbInnerLayerTexture;
        private System.Windows.Forms.Label lbGlowTexture;
        private System.Windows.Forms.Label lbDisplacementTexture;
        private System.Windows.Forms.Label lbEnableEditorAlphaRef;
        private System.Windows.Forms.Label lbSpecularEnabled;
        private System.Windows.Forms.Label lbSubsurfaceLightingRolloff;
        private System.Windows.Forms.Label lbSubsurfaceLighting;
        private System.Windows.Forms.Label lbBacklightPower;
        private System.Windows.Forms.Label lbRimPower;
        private System.Windows.Forms.Label lbRimLighting;
        private System.Windows.Forms.Label lbSpecularMult;
        private System.Windows.Forms.Label lbSpecularColor;
        private System.Windows.Forms.Label lbSmoothness;
        private System.Windows.Forms.Label lbWetSpecScale;
        private System.Windows.Forms.Label lbFresnelPower;
        private System.Windows.Forms.Label lbWetSpecPowerScale;
        private System.Windows.Forms.Label lbWetFresnelPower;
        private System.Windows.Forms.Label lbWetEnvMapScale;
        private System.Windows.Forms.Label lbWetSpecMinVar;
        private System.Windows.Forms.Label lbWetMetalness;
        private System.Windows.Forms.Label lbRootMaterialPath;
        private System.Windows.Forms.Label lbModelSpaceNormals;
        private System.Windows.Forms.Label lbEmittanceMultiplier;
        private System.Windows.Forms.Label lbEmittanceColor;
        private System.Windows.Forms.Label lbEmittanceEnabled;
        private System.Windows.Forms.Label lbAnisoLighting;
        private System.Windows.Forms.Label lbDisplacementTexScale;
        private System.Windows.Forms.Label lbDisplacementTexBias;
        private System.Windows.Forms.Label lbTessellate;
        private System.Windows.Forms.Label lbSkinTint;
        private System.Windows.Forms.Label lbFacegen;
        private System.Windows.Forms.Label lbTree;
        private System.Windows.Forms.Label lbHairTintColor;
        private System.Windows.Forms.Label lbHair;
        private System.Windows.Forms.Label lbEnvironmentMapEye;
        private System.Windows.Forms.Label lbEnvironmentMapWindow;
        private System.Windows.Forms.Label lbGlowmap;
        private System.Windows.Forms.Label lbAssumeShadowmask;
        private System.Windows.Forms.Label lbDissolveFade;
        private System.Windows.Forms.Label lbCastShadows;
        private System.Windows.Forms.Label lbHideSecret;
        private System.Windows.Forms.Label lbReceiveShadows;
        private System.Windows.Forms.Label lbBackLighting;
        private System.Windows.Forms.Label lbExternalEmittance;
        private System.Windows.Forms.Label lbGrayscaleToPaletteScale;
        private System.Windows.Forms.Label lbTessellationFadeDistance;
        private System.Windows.Forms.Label lbTessellationBaseFactor;
        private System.Windows.Forms.Label lbTessellationPNScale;
        private System.Windows.Forms.Label lbSkewSpecularAlpha;
        private System.Windows.Forms.TextBox tbDiffuseTexture;
        private System.Windows.Forms.TextBox tbDisplacementTexture;
        private System.Windows.Forms.TextBox tbWrinklesTexture;
        private System.Windows.Forms.TextBox tbInnerLayerTexture;
        private System.Windows.Forms.TextBox tbGlowTexture;
        private System.Windows.Forms.TextBox tbEnvironmentMapTexture;
        private System.Windows.Forms.TextBox tbGreyscaleTexture;
        private System.Windows.Forms.TextBox tbSmoothSpecularTexture;
        private System.Windows.Forms.TextBox tbNormalTexture;
        private System.Windows.Forms.CheckBox cbRimLighting;
        private System.Windows.Forms.NumericUpDown numBacklightPower;
        private System.Windows.Forms.NumericUpDown numSubsurfaceLightingRolloff;
        private System.Windows.Forms.CheckBox cbSubsurfaceLighting;
        private System.Windows.Forms.Button btSpecularColor;
        private System.Windows.Forms.CheckBox cbSpecularEnabled;
        private System.Windows.Forms.NumericUpDown numSpecularMultiplier;
        private System.Windows.Forms.NumericUpDown numWetMetalness;
        private System.Windows.Forms.NumericUpDown numWetFresnelPower;
        private System.Windows.Forms.NumericUpDown numWetEnvMapScale;
        private System.Windows.Forms.NumericUpDown numWetSpecMinVar;
        private System.Windows.Forms.NumericUpDown numWetSpecPowerScale;
        private System.Windows.Forms.NumericUpDown numWetSpecScale;
        private System.Windows.Forms.NumericUpDown numFresnelPower;
        private System.Windows.Forms.NumericUpDown numSmoothness;
        private System.Windows.Forms.TextBox tbRootMaterialPath;
        private System.Windows.Forms.NumericUpDown numEmittanceMultiplier;
        private System.Windows.Forms.Button btEmittanceColor;
        private System.Windows.Forms.CheckBox cbEmittanceEnabled;
        private System.Windows.Forms.CheckBox cbAnisoLighting;
        private System.Windows.Forms.Button btHairTintColor;
        private System.Windows.Forms.CheckBox cbHair;
        private System.Windows.Forms.CheckBox cbEnvironmentMapEye;
        private System.Windows.Forms.CheckBox cbEnvironmentMapWindow;
        private System.Windows.Forms.CheckBox cbGlowmap;
        private System.Windows.Forms.CheckBox cbAssumeShadowmask;
        private System.Windows.Forms.CheckBox cbDissolveFade;
        private System.Windows.Forms.CheckBox cbCastShadows;
        private System.Windows.Forms.CheckBox cbHideSecret;
        private System.Windows.Forms.CheckBox cbReceiveShadows;
        private System.Windows.Forms.CheckBox cbBackLighting;
        private System.Windows.Forms.CheckBox cbExternalEmittance;
        private System.Windows.Forms.CheckBox cbModelSpaceNormals;
        private System.Windows.Forms.CheckBox cbSkewSpecularAlpha;
        private System.Windows.Forms.NumericUpDown numGrayscaleToPaletteScale;
        private System.Windows.Forms.NumericUpDown numTessellationFadeDistance;
        private System.Windows.Forms.NumericUpDown numTessellationBaseFactor;
        private System.Windows.Forms.NumericUpDown numTessellationPNScale;
        private System.Windows.Forms.NumericUpDown numDisplacementTexScale;
        private System.Windows.Forms.NumericUpDown numDisplacementTexBias;
        private System.Windows.Forms.CheckBox cbTessellate;
        private System.Windows.Forms.CheckBox cbSkinTint;
        private System.Windows.Forms.CheckBox cbFacegen;
        private System.Windows.Forms.CheckBox cbTree;
        private System.Windows.Forms.SplitContainer splitContainerEffect;
        private System.Windows.Forms.Label lbBaseTexture;
        private System.Windows.Forms.CheckBox cbBloodEnabled;
        private System.Windows.Forms.NumericUpDown numEnvmapMinLOD;
        private System.Windows.Forms.NumericUpDown numBaseColorScale;
        private System.Windows.Forms.Label lbGrayscaleTexture;
        private System.Windows.Forms.Label lbEnvmapTexture;
        private System.Windows.Forms.Label lbEnvmapMaskTexture;
        private System.Windows.Forms.Label lbNormalTexture_effect;
        private System.Windows.Forms.Label lbBloodEnabled;
        private System.Windows.Forms.Label lbGrayscaleToPaletteAlpha;
        private System.Windows.Forms.Label lbFalloffColorEnabled;
        private System.Windows.Forms.Label lbFalloffEnabled;
        private System.Windows.Forms.Label lbEffectLightingEnabled;
        private System.Windows.Forms.Label lbFalloffStopOpacity;
        private System.Windows.Forms.Label lbFalloffStartOpacity;
        private System.Windows.Forms.Label lbFalloffStopAngle;
        private System.Windows.Forms.Label lbFalloffStartAngle;
        private System.Windows.Forms.Label lbBaseColorScale;
        private System.Windows.Forms.Label lbBaseColor;
        private System.Windows.Forms.Label lbSoftEnabled;
        private System.Windows.Forms.Label lbEnvmapMinLOD;
        private System.Windows.Forms.Label lbLightingInfluence;
        private System.Windows.Forms.Label lbSoftDepth;
        private System.Windows.Forms.TextBox tbBaseTexture;
        private System.Windows.Forms.TextBox tbEnvmapMaskTexture;
        private System.Windows.Forms.TextBox tbNormalTexture_effect;
        private System.Windows.Forms.TextBox tbEnvmapTexture;
        private System.Windows.Forms.TextBox tbGrayscaleTexture;
        private System.Windows.Forms.CheckBox cbSoftEnabled;
        private System.Windows.Forms.CheckBox cbGrayscaleToPaletteAlpha;
        private System.Windows.Forms.CheckBox cbFalloffColorEnabled;
        private System.Windows.Forms.CheckBox cbFalloffEnabled;
        private System.Windows.Forms.CheckBox cbEffectLightingEnabled;
        private System.Windows.Forms.Button btBaseColor;
        private System.Windows.Forms.NumericUpDown numSoftDepth;
        private System.Windows.Forms.NumericUpDown numLightingInfluence;
        private System.Windows.Forms.NumericUpDown numFalloffStopOpacity;
        private System.Windows.Forms.NumericUpDown numFalloffStartOpacity;
        private System.Windows.Forms.NumericUpDown numFalloffStopAngle;
        private System.Windows.Forms.NumericUpDown numFalloffStartAngle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

    }
}

