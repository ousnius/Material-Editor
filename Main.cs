using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Linq;

namespace Material_Editor
{
    public struct Config
    {
        public GameVersion GameVersion;
        public Font Font;
    }

    public enum GameVersion
    {
        FO4,
        FO76
    }

    public enum MaterialType
    {
        Material,
        Effect
    }

    public partial class Main : Form
    {
        private Config config = new Config();
        private string workFilePath;
        private bool changed;
        private bool toolTipPopping;

        private string WorkFileName
        {
            get
            {
                if (workFilePath != null)
                {
                    int nameIndex = workFilePath.LastIndexOf('\\');
                    if (nameIndex != -1)
                        return workFilePath.Substring(nameIndex + 1, workFilePath.Length - nameIndex - 1);
                    else
                        return workFilePath;
                }

                return null;
            }
        }

        private MaterialType CurrentMaterialType
        {
            get { return (MaterialType)listMatType.SelectedIndex; }
        }

        public Main()
        {
            InitializeComponent();
            ReadSettings();
        }

        private string ChangeFileExtension(string filePath)
        {
            if (filePath == null)
                return null;

            string ext;
            switch (CurrentMaterialType)
            {
                case MaterialType.Effect:
                    ext = ".bgem";
                    break;
                default:
                    ext = ".bgsm";
                    break;
            }
            return Path.ChangeExtension(filePath, ext);
        }

        #region UI
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workFilePath = null;
            Text = "Material Editor";

            saveAsToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            layoutGeneral.Enabled = true;
            layoutMaterial.Enabled = true;
            layoutEffect.Enabled = true;

            SuspendAll();
            CreateMaterialControls();
            ResumeAll();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                if (file.ToLower().EndsWith(".bgsm"))
                {
                    OpenMaterial(file, BGSM.Signature);
                }
                else if (file.ToLower().EndsWith(".bgem"))
                {
                    OpenMaterial(file, BGEM.Signature);
                }
                else
                {
                    MessageBox.Show(string.Format("File extension of file '{0}' not supported!", file), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workFilePath))
            {
                saveAsToolStripMenuItem_Click(null, null);
            }

            BaseMaterialFile material;
            switch (CurrentMaterialType)
            {
                case MaterialType.Effect:
                    material = new BGEM();
                    break;
                default:
                    material = new BGSM();
                    break;
            }

            GetMaterialValues(material);

            try
            {
                using (var file = new FileStream(workFilePath, FileMode.Create))
                {
                    if (serializeToJSONToolStripMenuItem.Checked)
                    {
                        var currentCulture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                        try
                        {
                            using (var writer = JsonReaderWriterFactory.CreateJsonWriter(file, Encoding.UTF8, true, true, "  "))
                            {
                                var ser = new DataContractJsonSerializer(material.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
                                ser.WriteObject(writer, material);
                                writer.Flush();
                            }
                        }
                        catch
                        {
                            MessageBox.Show(string.Format("Failed to serialize to JSON data for file '{0}'!", workFilePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            Thread.CurrentThread.CurrentCulture = currentCulture;
                        }
                    }
                    else
                    {
                        if (!material.Save(file))
                        {
                            MessageBox.Show(string.Format("Failed to save file '{0}'!", workFilePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Failed to save file '{0}'!", workFilePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Text = WorkFileName;
            changed = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var matType = CurrentMaterialType;
            switch (matType)
            {
                case MaterialType.Effect:
                    saveFileDialog.Filter = "Effect File (.bgem)|*.bgem";
                    break;
                default:
                    saveFileDialog.Filter = "Material File (.bgsm)|*.bgsm";
                    break;
            }

            string fileName = WorkFileName;
            if (fileName != null)
            {
                saveFileDialog.FileName = ChangeFileExtension(fileName);
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                BaseMaterialFile material;
                if (CurrentMaterialType == MaterialType.Effect)
                    material = new BGEM();
                else
                    material = new BGSM();

                GetMaterialValues(material);

                try
                {
                    using (var file = new FileStream(filePath, FileMode.Create))
                    {
                        if (serializeToJSONToolStripMenuItem.Checked)
                        {
                            var currentCulture = Thread.CurrentThread.CurrentCulture;
                            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                            try
                            {
                                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(file, Encoding.UTF8, true, true, "  "))
                                {
                                    var ser = new DataContractJsonSerializer(material.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
                                    ser.WriteObject(writer, material);
                                    writer.Flush();
                                }
                            }
                            catch
                            {
                                MessageBox.Show(string.Format("Failed to serialize to JSON data for file '{0}'!", filePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Thread.CurrentThread.CurrentCulture = currentCulture;
                            }
                        }
                        else
                        {
                            if (!material.Save(file))
                            {
                                MessageBox.Show(string.Format("Failed to save file '{0}'!", filePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(string.Format("Failed to save file '{0}'!", filePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                workFilePath = filePath;

                saveToolStripMenuItem.Enabled = true;

                Text = WorkFileName;
                changed = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workFilePath = string.Empty;

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            layoutGeneral.Enabled = false;
            layoutMaterial.Enabled = false;
            layoutEffect.Enabled = false;

            Text = "Material Editor";
            changed = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog()
            {
                AllowScriptChange = false,
                AllowVectorFonts = false,
                AllowVerticalFonts = false,
                FontMustExist = true,
                ShowColor = false,
                ShowEffects = false,
                MaxSize = 14,
                Font = config.Font ?? Font
            };

            var result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                config.Font = fontDialog.Font;
                MessageBox.Show("Changing the font requires a restart of the application.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutDialog();
            about.ShowDialog();
        }

        private void listVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedVersion = (GameVersion)listVersion.SelectedIndex;
            if (config.GameVersion != selectedVersion)
            {
                config.GameVersion = selectedVersion;

                SuspendAll();
                SetControlVisibility();
                ResumeAll();

                OnChanged();
            }
        }

        private void listMatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabPageMaterial);
            tabControl.TabPages.Remove(tabPageEffect);

            switch (CurrentMaterialType)
            {
                case MaterialType.Material:
                    tabControl.TabPages.Add(tabPageMaterial);
                    tabControl.SelectTab(tabPageMaterial);
                    break;
                case MaterialType.Effect:
                    tabControl.TabPages.Add(tabPageEffect);
                    tabControl.SelectTab(tabPageEffect);
                    break;
            }

            string filePath = ChangeFileExtension(workFilePath);
            if (filePath != workFilePath)
            {
                workFilePath = filePath;
                OnChanged();
            }
        }

        private void toolTip_Popup(object sender, PopupEventArgs ea)
        {
            if (toolTipPopping)
                return;

            toolTipPopping = true;

            if (ea.AssociatedControl.Tag is CustomControl customControl)
            {
                var baseToolTip = customControl.BaseToolTip;
                if (baseToolTip != null)
                {
                    var newToolTip = baseToolTip;

                    if (ea.AssociatedControl.Tag is ColorControl colorControl)
                    {
                        var knownColorLookup = Enum.GetValues(typeof(KnownColor))
                            .Cast<KnownColor>()
                            .Select(Color.FromKnownColor)
                            .Where(c => !c.IsSystemColor)
                            .ToLookup(c => c.ToArgb());

                        var currentColor = colorControl.CurrentColor;
                        var knownColors = knownColorLookup[currentColor.ToArgb()];
                        if (knownColors.Count() > 0)
                        {
                            var colorList = knownColors.Aggregate("", (str, obj) => str + obj.Name + ", ").TrimEnd(' ', ',');
                            newToolTip += $"{Environment.NewLine}Color: {currentColor.R}, {currentColor.G}, {currentColor.B} ({colorList})";
                        }
                        else
                        {
                            newToolTip += $"{Environment.NewLine}Color: {currentColor.R}, {currentColor.G}, {currentColor.B}";
                        }
                    }
                    else if (ea.AssociatedControl.Tag is FileControl fileControl)
                    {
                        newToolTip += $"{Environment.NewLine}File Type: {fileControl.CurrentFileType}";
                    }

                    toolTip.SetToolTip(ea.AssociatedControl, newToolTip);
                }
            }

            toolTipPopping = false;
        }

        private void SuspendAll()
        {
            SuspendLayout();
            layoutGeneral.SuspendLayout();
            layoutMaterial.SuspendLayout();
            layoutEffect.SuspendLayout();
        }

        private void ResumeAll()
        {
            ResumeLayout();
            layoutGeneral.ResumeLayout();
            layoutMaterial.ResumeLayout();
            layoutEffect.ResumeLayout();
        }

        private void TabScroll(object sender, ScrollEventArgs e)
        {
            var tab = (TabPage)sender;
            tab.Update();
        }

        private void OnChanged()
        {
            if (!string.IsNullOrEmpty(workFilePath))
            {
                Text = $"*{WorkFileName}";
                changed = true;
            }
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            SuspendAll();
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            ResumeAll();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Font = config.Font;

            var items = Enum.GetNames(typeof(GameVersion));
            listVersion.Items.AddRange(items);
            listVersion.SelectedIndex = (int)config.GameVersion;

            listMatType.SelectedIndex = 0;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string fileName = args[1];
                if (fileName.ToLower().EndsWith(".bgsm"))
                {
                    OpenMaterial(fileName, BGSM.Signature);
                }
                else if (fileName.ToLower().EndsWith(".bgem"))
                {
                    OpenMaterial(fileName, BGEM.Signature);
                }
                else
                {
                    MessageBox.Show("File extension not supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReadSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                var gameVersion = appSettings["GameVersion"];
                if (gameVersion != null)
                {
                    Enum.TryParse(gameVersion, out config.GameVersion);
                }

                var fontName = appSettings.Get("FontName");
                var fontSizeStr = appSettings.Get("FontSize");
                if (fontName != null && fontSizeStr != null)
                {
                    if (!float.TryParse(fontSizeStr, CultureInfo.InvariantCulture, out float fontSize))
                        fontSize = 10.0f;

                    config.Font = new Font(fontName, fontSize);
                }
                else
                {
                    config.Font = Font;
                }

                Application.SetDefaultFont(config.Font);
            }
            catch { }
        }

        private void WriteSettings()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var gameVersion = configFile.AppSettings.Settings["GameVersion"];
                if (gameVersion != null)
                    gameVersion.Value = Convert.ToString(config.GameVersion);
                else
                    configFile.AppSettings.Settings.Add("GameVersion", Convert.ToString(config.GameVersion));

                var fontName = configFile.AppSettings.Settings["FontName"];
                if (fontName != null)
                    fontName.Value = config.Font.Name;
                else
                    configFile.AppSettings.Settings.Add("FontName", config.Font.Name);

                var fontSize = configFile.AppSettings.Settings["FontSize"];
                if (fontSize != null)
                    fontSize.Value = config.Font.Size.ToString(CultureInfo.InvariantCulture);
                else
                    configFile.AppSettings.Settings.Add("FontSize", config.Font.Size.ToString(CultureInfo.InvariantCulture));

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch { }
        }

        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                DialogResult res = MessageBox.Show("There are unsaved changes to the file.\nDo want to save them before closing the program?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            WriteSettings();
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string file = files[0];
                if (file.ToLower().EndsWith(".bgsm"))
                {
                    OpenMaterial(file, BGSM.Signature);
                }
                else if (file.ToLower().EndsWith(".bgem"))
                {
                    OpenMaterial(file, BGEM.Signature);
                }
                else
                {
                    MessageBox.Show("Format not supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Material
        private static Color UIntToColor(uint value)
        {
            return Color.FromArgb(255,
                (byte)((value >> 16) & 0xFF),
                (byte)((value >> 8) & 0xFF),
                (byte)(value & 0xFF));
        }

        private void CreateMaterialControls(BaseMaterialFile file = null)
        {
            if (file == null)
                file = new BGSM();

            var fileFont = new Font("Consolas", Font.Size, FontStyle.Regular, GraphicsUnit.Point);

            ControlFactory.ClearControls();

            ControlFactory.CreateControl(layoutGeneral, "Tile U", file.TileU, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Tile V", file.TileV, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Offset U", file.UOffset, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Offset V", file.VOffset, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Scale U", file.UScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Scale V", file.VScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Alpha", file.Alpha, (control) => { OnChanged(); });

            int alphaBlendMode = (int)file.AlphaBlendMode;
            if (alphaBlendMode < 0 || alphaBlendMode > 4)
                alphaBlendMode = 0;

            ControlFactory.CreateDropdownControl(layoutGeneral, "Alpha Blend Mode",
                new[] { "Unknown", "None", "Standard", "Additive", "Multiplicative" }, alphaBlendMode,
                (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutGeneral, "Alpha Test Reference", file.AlphaTestRef, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Alpha Test", file.AlphaTest, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Z Buffer Write", file.ZBufferWrite, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Z Buffer Test", file.ZBufferTest, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Screen Space Reflections", file.ScreenSpaceReflections, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Wetness Control SSR", file.WetnessControlScreenSpaceReflections, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Decal", file.Decal, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Two Sided", file.TwoSided, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Decal No Fade", file.DecalNoFade, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Non Occluder", file.NonOccluder, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutGeneral, "Refraction", file.Refraction, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                ControlFactory.SetVisible("Refraction Falloff", enabled);
                ControlFactory.SetVisible("Refraction Power", enabled);

                OnChanged();
            });

            ControlFactory.CreateControl(layoutGeneral, "Refraction Falloff", file.RefractionFalloff, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Refraction Power", file.RefractionPower, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutGeneral, "Environment Mapping", file.EnvironmentMapping, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                if (config.GameVersion == GameVersion.FO4)
                {
                    ControlFactory.SetVisible("Environment Mask Scale", enabled);
                }

                OnChanged();
            });

            ControlFactory.CreateControl(layoutGeneral, "Environment Mask Scale", file.EnvironmentMappingMaskScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Depth Bias", file.DepthBias, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutGeneral, "Grayscale To Palette Color", file.GrayscaleToPaletteColor, (control) => { OnChanged(); });
            ControlFactory.CreateFlagControl(layoutGeneral, "Mask Writes", Enum.GetNames(typeof(BaseMaterialFile.MaskWriteFlags)), (int)file.MaskWrites, (control) => { OnChanged(); });

            var bgsm = file as BGSM;
            if (bgsm == null)
                bgsm = new BGSM();

            ControlFactory.CreateFileControl(layoutMaterial, "Diffuse", fileFont, FileControl.FileType.Texture, bgsm.DiffuseTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Normal", fileFont, FileControl.FileType.Texture, bgsm.NormalTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Smooth Spec", fileFont, FileControl.FileType.Texture, bgsm.SmoothSpecTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Greyscale", fileFont, FileControl.FileType.Texture, bgsm.GreyscaleTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Environment", fileFont, FileControl.FileType.Texture, bgsm.EnvmapTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Glow", fileFont, FileControl.FileType.Texture, bgsm.GlowTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Inner Layer", fileFont, FileControl.FileType.Texture, bgsm.InnerLayerTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Wrinkles", fileFont, FileControl.FileType.Texture, bgsm.WrinklesTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Displacement", fileFont, FileControl.FileType.Texture, bgsm.DisplacementTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Specular", fileFont, FileControl.FileType.Texture, bgsm.SpecularTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Lighting", fileFont, FileControl.FileType.Texture, bgsm.LightingTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Flow", fileFont, FileControl.FileType.Texture, bgsm.FlowTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutMaterial, "Distance Field Alpha", fileFont, FileControl.FileType.Texture, bgsm.DistanceFieldAlphaTexture, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Enable Editor Alpha Ref", bgsm.EnableEditorAlphaRef, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Rim Lighting", bgsm.RimLighting, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                if (config.GameVersion == GameVersion.FO4)
                {
                    ControlFactory.SetVisible("Rim Power", enabled);
                }

                OnChanged();
            });

            ControlFactory.CreateControl(layoutMaterial, "Rim Power", bgsm.RimPower, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Backlight Power", bgsm.BackLightPower, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Subsurface Lighting", bgsm.SubsurfaceLighting, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                if (config.GameVersion == GameVersion.FO4)
                {
                    ControlFactory.SetVisible("Subsurface Lighting Rolloff", enabled);
                }

                OnChanged();
            });

            ControlFactory.CreateControl(layoutMaterial, "Subsurface Lighting Rolloff", bgsm.SubsurfaceLightingRolloff, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Translucency", bgsm.Translucency, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Transl. Thick Object", bgsm.TranslucencyThickObject, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Transl. Alb+Subsurf Color", bgsm.TranslucencyMixAlbedoWithSubsurfaceColor, (control) => { OnChanged(); });

            var translucencySubsurfaceColor = UIntToColor(bgsm.TranslucencySubsurfaceColor);
            ControlFactory.CreateControl(layoutMaterial, "Transl. Subsurface Color", translucencySubsurfaceColor, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Transl. Transmissive Scale", bgsm.TranslucencyTransmissiveScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Transl. Turbulence", bgsm.TranslucencyTurbulence, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Specular Enabled", bgsm.SpecularEnabled, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                ControlFactory.SetVisible("Specular Color", enabled);
                ControlFactory.SetVisible("Specular Multiplier", enabled);

                OnChanged();
            });

            var specularColor = UIntToColor(bgsm.SpecularColor);
            ControlFactory.CreateControl(layoutMaterial, "Specular Color", specularColor, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Specular Multiplier", bgsm.SpecularMult, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Smoothness", bgsm.Smoothness, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Fresnel Power", bgsm.FresnelPower, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Wet Spec Scale", bgsm.WetnessControlSpecScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Wet Spec Power Scale", bgsm.WetnessControlSpecPowerScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Wet Spec Min Var", bgsm.WetnessControlSpecMinvar, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Wet Env Map Scale", bgsm.WetnessControlEnvMapScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Wet Fresnel Power", bgsm.WetnessControlFresnelPower, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Wet Metalness", bgsm.WetnessControlMetalness, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "PBR", bgsm.PBR, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Custom Porosity", bgsm.CustomPorosity, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Porosity Value", bgsm.PorosityValue, (control) => { OnChanged(); });

            ControlFactory.CreateFileControl(layoutMaterial, "Root Material Path", fileFont, FileControl.FileType.Material, bgsm.RootMaterialPath, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Aniso Lighting", bgsm.AnisoLighting, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Emittance Enabled", bgsm.EmitEnabled, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                ControlFactory.SetVisible("Emittance Color", enabled);
                ControlFactory.SetVisible("Emittance Multiplier", enabled);

                OnChanged();
            });

            var emittanceColor = UIntToColor(bgsm.EmittanceColor);
            ControlFactory.CreateControl(layoutMaterial, "Emittance Color", emittanceColor, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Emittance Multiplier", bgsm.EmittanceMult, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Model Space Normals", bgsm.ModelSpaceNormals, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "External Emittance", bgsm.ExternalEmittance, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Lum Emittance", bgsm.LumEmittance, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Adaptative Emissive", bgsm.UseAdaptativeEmissive, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                if (config.GameVersion == GameVersion.FO76)
                {
                    ControlFactory.SetVisible("Adapt. Em. Exposure Offset", enabled);
                    ControlFactory.SetVisible("Adapt. Em. Final Exposure Min", enabled);
                    ControlFactory.SetVisible("Adapt. Em. Final Exposure Max", enabled);
                }

                OnChanged();
            });

            ControlFactory.CreateControl(layoutMaterial, "Adapt. Em. Exposure Offset", bgsm.AdaptativeEmissive_ExposureOffset, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Adapt. Em. Final Exposure Min", bgsm.AdaptativeEmissive_FinalExposureMin, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Adapt. Em. Final Exposure Max", bgsm.AdaptativeEmissive_FinalExposureMax, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Back Lighting", bgsm.BackLighting, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Receive Shadows", bgsm.ReceiveShadows, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Hide Secret", bgsm.HideSecret, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Cast Shadows", bgsm.CastShadows, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Dissolve Fade", bgsm.DissolveFade, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Assume Shadowmask", bgsm.AssumeShadowmask, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Glowmap", bgsm.Glowmap, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Environment Map Window", bgsm.EnvironmentMappingWindow, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Environment Map Eye", bgsm.EnvironmentMappingEye, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Hair", bgsm.Hair, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                ControlFactory.SetVisible("Hair Tint Color", enabled);

                OnChanged();
            });

            var hairTintColor = UIntToColor(bgsm.HairTintColor);
            ControlFactory.CreateControl(layoutMaterial, "Hair Tint Color", hairTintColor, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Tree", bgsm.Tree, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Facegen", bgsm.Facegen, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Skin Tint", bgsm.SkinTint, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Tessellate", bgsm.Tessellate, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                if (config.GameVersion == GameVersion.FO4)
                {
                    ControlFactory.SetVisible("Displacement Tex Bias", enabled);
                    ControlFactory.SetVisible("Displacement Tex Scale", enabled);
                    ControlFactory.SetVisible("Tessellation PN Scale", enabled);
                    ControlFactory.SetVisible("Tessellation Base Factor", enabled);
                    ControlFactory.SetVisible("Tessellation Fade Distance", enabled);
                }

                OnChanged();
            });

            ControlFactory.CreateControl(layoutMaterial, "Displacement Tex Bias", bgsm.DisplacementTextureBias, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Displacement Tex Scale", bgsm.DisplacementTextureScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Tessellation PN Scale", bgsm.TessellationPnScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Tessellation Base Factor", bgsm.TessellationBaseFactor, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Tessellation Fade Distance", bgsm.TessellationFadeDistance, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Grayscale To Palette Scale", bgsm.GrayscaleToPaletteScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Skew Specular Alpha", bgsm.SkewSpecularAlpha, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutMaterial, "Terrain", bgsm.Terrain, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                if (config.GameVersion == GameVersion.FO76)
                {
                    ControlFactory.SetVisible("Unk Int 1 BGSM", enabled);
                    ControlFactory.SetVisible("Terrain Threshold Falloff", enabled);
                    ControlFactory.SetVisible("Terrain Tiling Distance", enabled);
                    ControlFactory.SetVisible("Terrain Rotation Angle", enabled);
                }

                OnChanged();
            });

            ControlFactory.CreateControl(layoutMaterial, "Unk Int 1 BGSM", bgsm.UnkInt1, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Terrain Threshold Falloff", bgsm.TerrainThresholdFalloff, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Terrain Tiling Distance", bgsm.TerrainTilingDistance, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutMaterial, "Terrain Rotation Angle", bgsm.TerrainRotationAngle, (control) => { OnChanged(); });

            var bgem = file as BGEM;
            if (bgem == null)
                bgem = new BGEM();

            ControlFactory.CreateFileControl(layoutEffect, "Base Texture", fileFont, FileControl.FileType.Texture, bgem.BaseTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Grayscale Texture", fileFont, FileControl.FileType.Texture, bgem.GrayscaleTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Envmap Texture", fileFont, FileControl.FileType.Texture, bgem.EnvmapTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Normal Texture", fileFont, FileControl.FileType.Texture, bgem.NormalTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Envmap Mask Texture", fileFont, FileControl.FileType.Texture, bgem.EnvmapMaskTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Specular Texture", fileFont, FileControl.FileType.Texture, bgem.SpecularTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Lighting Texture", fileFont, FileControl.FileType.Texture, bgem.LightingTexture, (control) => { OnChanged(); });
            ControlFactory.CreateFileControl(layoutEffect, "Glow Texture", fileFont, FileControl.FileType.Texture, bgem.GlowTexture, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutEffect, "Env Mapping", bgem.EnvironmentMapping, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Env Mapping Mask Scale", bgem.EnvironmentMappingMaskScale, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutEffect, "Blood Enabled", bgem.BloodEnabled, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Effect Lighting Enabled", bgem.EffectLightingEnabled, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutEffect, "Falloff Enabled", bgem.FalloffEnabled, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                ControlFactory.SetVisible("Falloff Start Angle", enabled);
                ControlFactory.SetVisible("Falloff Stop Angle", enabled);
                ControlFactory.SetVisible("Falloff Start Opacity", enabled);
                ControlFactory.SetVisible("Falloff Stop Opacity", enabled);

                OnChanged();
            });

            ControlFactory.CreateControl(layoutEffect, "Falloff Color Enabled", bgem.FalloffColorEnabled, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Grayscale To Palette Alpha", bgem.GrayscaleToPaletteAlpha, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutEffect, "Soft Enabled", bgem.SoftEnabled, (control) =>
            {
                bool enabled = Convert.ToBoolean(control.GetProperty());

                ControlFactory.SetVisible("Soft Depth", enabled);

                OnChanged();
            });

            var baseColor = UIntToColor(bgem.BaseColor);
            ControlFactory.CreateControl(layoutEffect, "Base Color", baseColor, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutEffect, "Base Color Scale", bgem.BaseColorScale, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Falloff Start Angle", bgem.FalloffStartAngle, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Falloff Stop Angle", bgem.FalloffStopAngle, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Falloff Start Opacity", bgem.FalloffStartOpacity, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Falloff Stop Opacity", bgem.FalloffStopOpacity, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Lighting Influence", bgem.LightingInfluence, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Envmap Min LOD", bgem.EnvmapMinLOD, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Soft Depth", bgem.SoftDepth, (control) => { OnChanged(); });

            var emitColor = UIntToColor(bgem.EmittanceColor);
            ControlFactory.CreateControl(layoutEffect, "Emit Color", emitColor, (control) => { OnChanged(); });

            ControlFactory.CreateControl(layoutEffect, "Adaptative Em. Exposure Offset", bgem.AdaptativeEmissive_ExposureOffset, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Adaptative Em. Final Exp. Min", bgem.AdaptativeEmissive_FinalExposureMin, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Adaptative Em. Final Exp. Max", bgem.AdaptativeEmissive_FinalExposureMax, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Effect Glowmap", bgem.Glowmap, (control) => { OnChanged(); });
            ControlFactory.CreateControl(layoutEffect, "Effect PBR Specular", bgem.EffectPbrSpecular, (control) => { OnChanged(); });

            CreateTooltips();
            SetControlVisibility();
        }

        private void CreateTooltips()
        {
            toolTip.RemoveAll();

            ControlFactory.SetTooltip("Tile U", toolTip, "Tile the U texture coordinate (wrapping/repeating the texture).");
            ControlFactory.SetTooltip("Tile V", toolTip, "Tile the V texture coordinate (wrapping/repeating the texture).");
            ControlFactory.SetTooltip("Offset U", toolTip, "Offset the U texture coordinate.");
            ControlFactory.SetTooltip("Offset V", toolTip, "Offset the V texture coordinate.");
            ControlFactory.SetTooltip("Scale U", toolTip, "Scale the U texture coordinate.");
            ControlFactory.SetTooltip("Scale V", toolTip, "Scale the V texture coordinate.");
            ControlFactory.SetTooltip("Alpha", toolTip, "Fixed alpha value that applies to the entire mesh (unrelated to texture alpha).");
            ControlFactory.SetTooltip("Alpha Blend Mode", toolTip, "Defines the mode at which alpha is blended into other meshes.");
            ControlFactory.SetTooltip("Alpha Test Reference", toolTip, "Reference value to do alpha testing for. Transparency happens when alpha is below or exceeds the reference value (depending on modes).");
            ControlFactory.SetTooltip("Alpha Test", toolTip, "Toggle alpha testing using the reference value.");
            ControlFactory.SetTooltip("Z Buffer Write", toolTip, "The mesh writes to the z-buffer to make others aware of its depth.");
            ControlFactory.SetTooltip("Z Buffer Test", toolTip, "The mesh tests the z-buffer to take note of other meshes depth.");
            ControlFactory.SetTooltip("Screen Space Reflections", toolTip, "Toggle screen space reflections.");
            ControlFactory.SetTooltip("Wetness Control SSR", toolTip, "Toggle wetness control for screen space reflections.");
            ControlFactory.SetTooltip("Decal", toolTip, "Toggle decal rendering.");
            ControlFactory.SetTooltip("Two Sided", toolTip, "Renders both sides of all faces of the mesh (double sided).");
            ControlFactory.SetTooltip("Decal No Fade", toolTip, "Toggle decal rendering without fade.");
            ControlFactory.SetTooltip("Non Occluder", toolTip, "Don't perform occlusion (line-of-sight).");
            ControlFactory.SetTooltip("Refraction", toolTip, "Toggle refraction of light.");
            ControlFactory.SetTooltip("Refraction Falloff", toolTip, "Toggles refraction falloff.");
            ControlFactory.SetTooltip("Refraction Power", toolTip, "Power of the refraction.");
            ControlFactory.SetTooltip("Environment Mapping", toolTip, "Toggle environment mapping.");
            ControlFactory.SetTooltip("Environment Mask Scale", toolTip, "Scale for the environment mask.");
            ControlFactory.SetTooltip("Depth Bias", toolTip, "Toggle depth bias to prevent z-fighting.");
            ControlFactory.SetTooltip("Grayscale To Palette Color", toolTip, "Toggle mapping of grayscale to palette colors.");
            ControlFactory.SetTooltip("Mask Writes", toolTip, "Masks writing of certain lighting properties.");

            ControlFactory.SetTooltip("Diffuse", toolTip, "Diffuse texture slot.");
            ControlFactory.SetTooltip("Normal", toolTip, "Normal map slot.");
            ControlFactory.SetTooltip("Smooth Spec", toolTip, "Smoothness/specular mask slot.");
            ControlFactory.SetTooltip("Greyscale", toolTip, "Greyscale (palette/lookup/heightmap) texture slot.");
            ControlFactory.SetTooltip("Environment", toolTip, "Environment map slot.");
            ControlFactory.SetTooltip("Glow", toolTip, "Glow map or other specialty slot.");
            ControlFactory.SetTooltip("Inner Layer", toolTip, "Inner layer mask slot.");
            ControlFactory.SetTooltip("Wrinkles", toolTip, "Wrinkles texture slot.");
            ControlFactory.SetTooltip("Displacement", toolTip, "Displacement texture slot.");
            ControlFactory.SetTooltip("Specular", toolTip, "PBR specular texture slot.");
            ControlFactory.SetTooltip("Lighting", toolTip, "PBR lighting texture slot.");
            ControlFactory.SetTooltip("Flow", toolTip, "PBR flow texture slot.");
            ControlFactory.SetTooltip("Distance Field Alpha", toolTip, "Distance field alpha texture slot.");
            ControlFactory.SetTooltip("Enable Editor Alpha Ref", toolTip, "Toggle editor alpha testing reference.");
            ControlFactory.SetTooltip("Rim Lighting", toolTip, "Toggle rim lighting effect.");
            ControlFactory.SetTooltip("Rim Power", toolTip, "Power of the rim lighting.");
            ControlFactory.SetTooltip("Backlight Power", toolTip, "Power of the back lighting.");
            ControlFactory.SetTooltip("Subsurface Lighting", toolTip, "Toggle subsurface lighting effect.");
            ControlFactory.SetTooltip("Subsurface Lighting Rolloff", toolTip, "Rolloff of the subsurface lighting.");
            ControlFactory.SetTooltip("Translucency", toolTip, "Toggle translucency simulation.");
            ControlFactory.SetTooltip("Transl. Thick Object", toolTip, "Object on which the material is applied is thick (or a billboard if not). Used for correct shadowing.");
            ControlFactory.SetTooltip("Transl. Alb+Subsurf Color", toolTip, "Multiply the subsurface color with the albedo instead of just outputting the specified color.");
            ControlFactory.SetTooltip("Transl. Subsurface Color", toolTip, "Color tint of the subsurface matter.");
            ControlFactory.SetTooltip("Transl. Transmissive Scale", toolTip, "Simulate amount of light collision inside the material.");
            ControlFactory.SetTooltip("Transl. Turbulence", toolTip, "Turbulence for translucency.");
            ControlFactory.SetTooltip("Specular Enabled", toolTip, "Toggle specular effect.");
            ControlFactory.SetTooltip("Specular Color", toolTip, "Color for the specular effect.");
            ControlFactory.SetTooltip("Specular Multiplier", toolTip, "Multiplier for the specular effect.");
            ControlFactory.SetTooltip("Smoothness", toolTip, "Smoothness of the specular effect.");
            ControlFactory.SetTooltip("Fresnel Power", toolTip, "Power of the fresnel reflection and transmission (specular).");
            ControlFactory.SetTooltip("Wet Spec Scale", toolTip, "Scale of the wetness specular.");
            ControlFactory.SetTooltip("Wet Spec Power Scale", toolTip, "Power scale of the wetness specular.");
            ControlFactory.SetTooltip("Wet Spec Min Var", toolTip, "Minimum variance of the wetness specular.");
            ControlFactory.SetTooltip("Wet Env Map Scale", toolTip, "Environment map scale of the wetness effect.");
            ControlFactory.SetTooltip("Wet Fresnel Power", toolTip, "Fresnel power of the wetness effect.");
            ControlFactory.SetTooltip("Wet Metalness", toolTip, "Metalness of the wetness effect.");
            ControlFactory.SetTooltip("PBR", toolTip, "Enables native PBR rendering. Requires diffuse, normal, specular and lighting texture (flow optional).");
            ControlFactory.SetTooltip("Custom Porosity", toolTip, "Toggle custom porosity for PBR.");
            ControlFactory.SetTooltip("Porosity Value", toolTip, "Custom porosity value for PBR.");
            ControlFactory.SetTooltip("Root Material Path", toolTip, "Template/root file of the current material.");
            ControlFactory.SetTooltip("Aniso Lighting", toolTip, "Toggle anisotropic lighting.");
            ControlFactory.SetTooltip("Emittance Enabled", toolTip, "Toggle emittance effect.");
            ControlFactory.SetTooltip("Emittance Color", toolTip, "Color for the emittance effect.");
            ControlFactory.SetTooltip("Emittance Multiplier", toolTip, "Multiplier for the emittance effect.");
            ControlFactory.SetTooltip("Model Space Normals", toolTip, "Toggle model space normals rendering.");
            ControlFactory.SetTooltip("External Emittance", toolTip, "Toggle external emittance effect.");
            ControlFactory.SetTooltip("Lum Emittance", toolTip, "Luminous emittance value (in Lux) of the luminous flux emitted from the surface.");
            ControlFactory.SetTooltip("Adaptative Emissive", toolTip, "Use stable emissive over physically based emittance. If unchecked, uses luminous emittance.");
            ControlFactory.SetTooltip("Adapt. Em. Exposure Offset", toolTip, "Exposure offset applied while exposing the emissive object.");
            ControlFactory.SetTooltip("Adapt. Em. Final Exposure Min", toolTip, "Minimum amount of exposure on the emissive object.");
            ControlFactory.SetTooltip("Adapt. Em. Final Exposure Max", toolTip, "Maximum amount of exposure on the emissive object.");
            ControlFactory.SetTooltip("Back Lighting", toolTip, "Toggle back lighting effect.");
            ControlFactory.SetTooltip("Receive Shadows", toolTip, "Toggle if this mesh receives shadows.");
            ControlFactory.SetTooltip("Hide Secret", toolTip, "Toggle hide secret.");
            ControlFactory.SetTooltip("Cast Shadows", toolTip, "Toggle shadow casting for this mesh.");
            ControlFactory.SetTooltip("Dissolve Fade", toolTip, "Toggle dissolve fade.");
            ControlFactory.SetTooltip("Assume Shadowmask", toolTip, "Toggle assuming shadowmask.");
            ControlFactory.SetTooltip("Glowmap", toolTip, "Toggle making use of a glowmap for emittance.");
            ControlFactory.SetTooltip("Environment Map Window", toolTip, "Toggle environment map window.");
            ControlFactory.SetTooltip("Environment Map Eye", toolTip, "Toggle environment map eye.");
            ControlFactory.SetTooltip("Hair", toolTip, "Toggle hair rendering.");
            ControlFactory.SetTooltip("Hair Tint Color", toolTip, "Color for the hair tinting.");
            ControlFactory.SetTooltip("Tree", toolTip, "Toggle tree rendering.");
            ControlFactory.SetTooltip("Facegen", toolTip, "Toggle facegen rendering.");
            ControlFactory.SetTooltip("Skin Tint", toolTip, "Toggle skin tint rendering.");
            ControlFactory.SetTooltip("Tessellate", toolTip, "Toggle tessellation effect.");
            ControlFactory.SetTooltip("Displacement Tex Bias", toolTip, "Bias for the displacement texture.");
            ControlFactory.SetTooltip("Displacement Tex Scale", toolTip, "Scale for the displacement texture.");
            ControlFactory.SetTooltip("Tessellation PN Scale", toolTip, "PN (point normal) scale for the tessellation effect.");
            ControlFactory.SetTooltip("Tessellation Base Factor", toolTip, "Base factor for the tessellation effect.");
            ControlFactory.SetTooltip("Tessellation Fade Distance", toolTip, "Fade distance for the tessellation effect.");
            ControlFactory.SetTooltip("Grayscale To Palette Scale", toolTip, "Scale for the grayscale to palette mapping.");
            ControlFactory.SetTooltip("Skew Specular Alpha", toolTip, "Toggle skew specular alpha.");
            ControlFactory.SetTooltip("Terrain", toolTip, "Toggle terrain rendering.");
            ControlFactory.SetTooltip("Unk Int 1 BGSM", toolTip, "Unknown value.");
            ControlFactory.SetTooltip("Terrain Threshold Falloff", toolTip, "Softness of the terrain blending.");
            ControlFactory.SetTooltip("Terrain Tiling Distance", toolTip, "Tiling distance of the terrain.");
            ControlFactory.SetTooltip("Terrain Rotation Angle", toolTip, "Rotation angle of the terrain.");

            ControlFactory.SetTooltip("Base Texture", toolTip, "Base texture slot.");
            ControlFactory.SetTooltip("Grayscale Texture", toolTip, "Grayscale texture slot.");
            ControlFactory.SetTooltip("Envmap Texture", toolTip, "Environment map slot.");
            ControlFactory.SetTooltip("Normal Texture", toolTip, "Normal map slot.");
            ControlFactory.SetTooltip("Envmap Mask Texture", toolTip, "Environment map mask slot.");
            ControlFactory.SetTooltip("Specular Texture", toolTip, "PBR specular texture slot.");
            ControlFactory.SetTooltip("Lighting Texture", toolTip, "PBR lighting texture slot.");
            ControlFactory.SetTooltip("Glow Texture", toolTip, "PBR emissive palette slot.");
            ControlFactory.SetTooltip("Env Mapping", toolTip, "Toggle environment mapping effect.");
            ControlFactory.SetTooltip("Env Mapping Mask Scale", toolTip, "Scale for the environment mapping mask.");
            ControlFactory.SetTooltip("Blood Enabled", toolTip, "Toggle blood rendering.");
            ControlFactory.SetTooltip("Effect Lighting Enabled", toolTip, "Toggle effect lighting.");
            ControlFactory.SetTooltip("Falloff Enabled", toolTip, "Toggle falloff settings driving alpha.");
            ControlFactory.SetTooltip("Falloff Color Enabled", toolTip, "Toggle falloff settings driving color.");
            ControlFactory.SetTooltip("Grayscale To Palette Alpha", toolTip, "Toggle grayscale to palette alpha mapping.");
            ControlFactory.SetTooltip("Soft Enabled", toolTip, "Toggle softness effect.");
            ControlFactory.SetTooltip("Base Color", toolTip, "Base color of the effect.");
            ControlFactory.SetTooltip("Base Color Scale", toolTip, "Scale of the base color.");
            ControlFactory.SetTooltip("Falloff Start Angle", toolTip, "Start angle of the falloff.");
            ControlFactory.SetTooltip("Falloff Stop Angle", toolTip, "Stop angle of the falloff.");
            ControlFactory.SetTooltip("Falloff Start Opacity", toolTip, "Start opacity of the falloff.");
            ControlFactory.SetTooltip("Falloff Stop Opacity", toolTip, "Stop opacity of the falloff.");
            ControlFactory.SetTooltip("Lighting Influence", toolTip, "Lighting influence value of the material.");
            ControlFactory.SetTooltip("Envmap Min LOD", toolTip, "Minimum LOD for environment mapping.");
            ControlFactory.SetTooltip("Soft Depth", toolTip, "Softness depth value of the material.");
            ControlFactory.SetTooltip("Emit Color", toolTip, "Color for the PBR emittance effect.");
            ControlFactory.SetTooltip("Adaptative Em. Exposure Offset", toolTip, "Exposure offset applied while exposing the emissive object.");
            ControlFactory.SetTooltip("Adaptative Em. Final Exp. Min", toolTip, "Minimum amount of exposure on the emissive object.");
            ControlFactory.SetTooltip("Adaptative Em. Final Exp. Max", toolTip, "Maximum amount of exposure on the emissive object.");
            ControlFactory.SetTooltip("Effect Glowmap", toolTip, "Toggle glowmap.");
            ControlFactory.SetTooltip("Effect PBR Specular", toolTip, "Toggle PBR specular effect.");
        }

        private void SetControlVisibility()
        {
            switch (config.GameVersion)
            {
                case GameVersion.FO4:
                    ControlFactory.SetVisible("Environment Mask Scale", true);
                    ControlFactory.SetVisible("Depth Bias", false);
                    ControlFactory.SetVisible("Mask Writes", false);

                    ControlFactory.SetVisible("Environment", true);
                    ControlFactory.SetVisible("Inner Layer", true);
                    ControlFactory.SetVisible("Displacement", true);
                    ControlFactory.SetVisible("Specular", false);
                    ControlFactory.SetVisible("Lighting", false);
                    ControlFactory.SetVisible("Flow", false);
                    ControlFactory.SetVisible("Distance Field Alpha", false);

                    ControlFactory.SetVisible("Translucency", false);
                    ControlFactory.SetVisible("Transl. Thick Object", false);
                    ControlFactory.SetVisible("Transl. Alb+Subsurf Color", false);
                    ControlFactory.SetVisible("Transl. Subsurface Color", false);
                    ControlFactory.SetVisible("Transl. Transmissive Scale", false);
                    ControlFactory.SetVisible("Transl. Turbulence", false);

                    ControlFactory.SetVisible("Rim Lighting", true);
                    ControlFactory.SetVisible("Rim Power", true);
                    ControlFactory.SetVisible("Backlight Power", true);
                    ControlFactory.SetVisible("Subsurface Lighting", true);
                    ControlFactory.SetVisible("Subsurface Lighting Rolloff", true);

                    ControlFactory.SetVisible("Wet Env Map Scale", true);

                    ControlFactory.SetVisible("PBR", false);
                    ControlFactory.SetVisible("Custom Porosity", false);
                    ControlFactory.SetVisible("Porosity Value", false);

                    ControlFactory.SetVisible("Lum Emittance", false);

                    ControlFactory.SetVisible("Adaptative Emissive", false);
                    ControlFactory.SetVisible("Adapt. Em. Exposure Offset", false);
                    ControlFactory.SetVisible("Adapt. Em. Final Exposure Min", false);
                    ControlFactory.SetVisible("Adapt. Em. Final Exposure Max", false);

                    ControlFactory.SetVisible("Back Lighting", true);

                    ControlFactory.SetVisible("Environment Map Window", true);
                    ControlFactory.SetVisible("Environment Map Eye", true);

                    ControlFactory.SetVisible("Displacement Tex Bias", true);
                    ControlFactory.SetVisible("Displacement Tex Scale", true);
                    ControlFactory.SetVisible("Tessellation PN Scale", true);
                    ControlFactory.SetVisible("Tessellation Base Factor", true);
                    ControlFactory.SetVisible("Tessellation Fade Distance", true);

                    ControlFactory.SetVisible("Terrain", false);
                    ControlFactory.SetVisible("Unk Int 1 BGSM", false);
                    ControlFactory.SetVisible("Terrain Threshold Falloff", false);
                    ControlFactory.SetVisible("Terrain Tiling Distance", false);
                    ControlFactory.SetVisible("Terrain Rotation Angle", false);

                    ControlFactory.SetVisible("Specular Texture", false);
                    ControlFactory.SetVisible("Lighting Texture", false);
                    ControlFactory.SetVisible("Glow Texture", false);

                    ControlFactory.SetVisible("Environment Mapping", true);
                    ControlFactory.SetVisible("Environment Mask Scale", true);
                    ControlFactory.SetVisible("Env Mapping", false, false);
                    ControlFactory.SetVisible("Env Mapping Mask Scale", false, false);

                    ControlFactory.SetVisible("Emit Color", false);
                    ControlFactory.SetVisible("Adaptative Em. Exposure Offset", false);
                    ControlFactory.SetVisible("Adaptative Em. Final Exp. Min", false);
                    ControlFactory.SetVisible("Adaptative Em. Final Exp. Max", false);
                    ControlFactory.SetVisible("Effect Glowmap", false);
                    ControlFactory.SetVisible("Effect PBR Specular", false);
                    break;

                case GameVersion.FO76:
                    ControlFactory.SetVisible("Environment Mask Scale", false);
                    ControlFactory.SetVisible("Depth Bias", true);
                    ControlFactory.SetVisible("Mask Writes", true);

                    ControlFactory.SetVisible("Environment", false);
                    ControlFactory.SetVisible("Inner Layer", false);
                    ControlFactory.SetVisible("Displacement", false);
                    ControlFactory.SetVisible("Specular", true);
                    ControlFactory.SetVisible("Lighting", true);
                    ControlFactory.SetVisible("Flow", true);
                    ControlFactory.SetVisible("Distance Field Alpha", true);

                    ControlFactory.SetVisible("Translucency", true);
                    ControlFactory.SetVisible("Transl. Thick Object", true);
                    ControlFactory.SetVisible("Transl. Alb+Subsurf Color", true);
                    ControlFactory.SetVisible("Transl. Subsurface Color", true);
                    ControlFactory.SetVisible("Transl. Transmissive Scale", true);
                    ControlFactory.SetVisible("Transl. Turbulence", true);

                    ControlFactory.SetVisible("Rim Lighting", false);
                    ControlFactory.SetVisible("Rim Power", false);
                    ControlFactory.SetVisible("Backlight Power", false);
                    ControlFactory.SetVisible("Subsurface Lighting", false);
                    ControlFactory.SetVisible("Subsurface Lighting Rolloff", false);

                    ControlFactory.SetVisible("Wet Env Map Scale", false);

                    ControlFactory.SetVisible("PBR", true);
                    ControlFactory.SetVisible("Custom Porosity", true);
                    ControlFactory.SetVisible("Porosity Value", true);

                    ControlFactory.SetVisible("Lum Emittance", true);

                    ControlFactory.SetVisible("Adaptative Emissive", true);
                    ControlFactory.SetVisible("Adapt. Em. Exposure Offset", true);
                    ControlFactory.SetVisible("Adapt. Em. Final Exposure Min", true);
                    ControlFactory.SetVisible("Adapt. Em. Final Exposure Max", true);

                    ControlFactory.SetVisible("Back Lighting", false);

                    ControlFactory.SetVisible("Environment Map Window", false);
                    ControlFactory.SetVisible("Environment Map Eye", false);

                    ControlFactory.SetVisible("Displacement Tex Bias", false);
                    ControlFactory.SetVisible("Displacement Tex Scale", false);
                    ControlFactory.SetVisible("Tessellation PN Scale", false);
                    ControlFactory.SetVisible("Tessellation Base Factor", false);
                    ControlFactory.SetVisible("Tessellation Fade Distance", false);

                    ControlFactory.SetVisible("Terrain", true);
                    ControlFactory.SetVisible("Unk Int 1 BGSM", true);
                    ControlFactory.SetVisible("Terrain Threshold Falloff", true);
                    ControlFactory.SetVisible("Terrain Tiling Distance", true);
                    ControlFactory.SetVisible("Terrain Rotation Angle", true);

                    ControlFactory.SetVisible("Specular Texture", true);
                    ControlFactory.SetVisible("Lighting Texture", true);
                    ControlFactory.SetVisible("Glow Texture", true);

                    ControlFactory.SetVisible("Environment Mapping", false, false);
                    ControlFactory.SetVisible("Environment Mask Scale", false, false);
                    ControlFactory.SetVisible("Env Mapping", true);
                    ControlFactory.SetVisible("Env Mapping Mask Scale", true);

                    ControlFactory.SetVisible("Emit Color", true);
                    ControlFactory.SetVisible("Adaptative Em. Exposure Offset", true);
                    ControlFactory.SetVisible("Adaptative Em. Final Exp. Min", true);
                    ControlFactory.SetVisible("Adaptative Em. Final Exp. Max", true);
                    ControlFactory.SetVisible("Effect Glowmap", true);
                    ControlFactory.SetVisible("Effect PBR Specular", true);
                    break;
            }

            ControlFactory.RunChangedCallbacks();
        }

        private void GetMaterialValues(BaseMaterialFile file)
        {
            CustomControl control = null;

            switch (config.GameVersion)
            {
                case GameVersion.FO4:
                    file.Version = 2;
                    break;

                case GameVersion.FO76:
                    file.Version = 20;
                    break;
            }

            control = ControlFactory.Find("Tile U");
            if (control != null) file.TileU = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Tile V");
            if (control != null) file.TileV = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Offset U");
            if (control != null) file.UOffset = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Offset V");
            if (control != null) file.VOffset = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Scale U");
            if (control != null) file.UScale = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Scale V");
            if (control != null) file.VScale = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Alpha");
            if (control != null) file.Alpha = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Alpha Blend Mode");
            if (control != null) file.AlphaBlendMode = (BaseMaterialFile.AlphaBlendModeType)Convert.ToInt32(control.GetProperty());

            control = ControlFactory.Find("Alpha Test Reference");
            if (control != null) file.AlphaTestRef = Convert.ToByte(control.GetProperty());

            control = ControlFactory.Find("Alpha Test");
            if (control != null) file.AlphaTest = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Z Buffer Write");
            if (control != null) file.ZBufferWrite = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Z Buffer Test");
            if (control != null) file.ZBufferTest = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Screen Space Reflections");
            if (control != null) file.ScreenSpaceReflections = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Wetness Control SSR");
            if (control != null) file.WetnessControlScreenSpaceReflections = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Decal");
            if (control != null) file.Decal = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Two Sided");
            if (control != null) file.TwoSided = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Decal No Fade");
            if (control != null) file.DecalNoFade = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Non Occluder");
            if (control != null) file.NonOccluder = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Refraction");
            if (control != null) file.Refraction = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Refraction Falloff");
            if (control != null) file.RefractionFalloff = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Refraction Power");
            if (control != null) file.RefractionPower = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Environment Mapping");
            if (control != null && control.Serialize) file.EnvironmentMapping = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Environment Mask Scale");
            if (control != null && control.Serialize) file.EnvironmentMappingMaskScale = Convert.ToSingle(control.GetProperty());

            control = ControlFactory.Find("Depth Bias");
            if (control != null) file.DepthBias = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Grayscale To Palette Color");
            if (control != null) file.GrayscaleToPaletteColor = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Mask Writes");
            if (control != null) file.MaskWrites = (BaseMaterialFile.MaskWriteFlags)control.GetProperty();

            if (file.GetType() == typeof(BGSM))
            {
                BGSM bgsm = (BGSM)file;

                control = ControlFactory.Find("Diffuse");
                if (control != null) bgsm.DiffuseTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Normal");
                if (control != null) bgsm.NormalTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Smooth Spec");
                if (control != null) bgsm.SmoothSpecTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Greyscale");
                if (control != null) bgsm.GreyscaleTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Environment");
                if (control != null) bgsm.EnvmapTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Glow");
                if (control != null) bgsm.GlowTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Inner Layer");
                if (control != null) bgsm.InnerLayerTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Wrinkles");
                if (control != null) bgsm.WrinklesTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Displacement");
                if (control != null) bgsm.DisplacementTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Specular");
                if (control != null) bgsm.SpecularTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Lighting");
                if (control != null) bgsm.LightingTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Flow");
                if (control != null) bgsm.FlowTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Distance Field Alpha");
                if (control != null) bgsm.DistanceFieldAlphaTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Enable Editor Alpha Ref");
                if (control != null) bgsm.EnableEditorAlphaRef = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Translucency");
                if (control != null) bgsm.Translucency = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Transl. Thick Object");
                if (control != null) bgsm.TranslucencyThickObject = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Transl. Alb+Subsurf Color");
                if (control != null) bgsm.TranslucencyMixAlbedoWithSubsurfaceColor = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Transl. Subsurface Color");
                if (control != null) bgsm.TranslucencySubsurfaceColor = (uint)((Color)control.GetProperty()).ToArgb();

                control = ControlFactory.Find("Transl. Transmissive Scale");
                if (control != null) bgsm.TranslucencyTransmissiveScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Transl. Turbulence");
                if (control != null) bgsm.TranslucencyTurbulence = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Rim Lighting");
                if (control != null) bgsm.RimLighting = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Rim Power");
                if (control != null) bgsm.RimPower = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Backlight Power");
                if (control != null) bgsm.BackLightPower = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Subsurface Lighting");
                if (control != null) bgsm.SubsurfaceLighting = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Subsurface Lighting Rolloff");
                if (control != null) bgsm.SubsurfaceLightingRolloff = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Specular Enabled");
                if (control != null) bgsm.SpecularEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Specular Color");
                if (control != null) bgsm.SpecularColor = (uint)((Color)control.GetProperty()).ToArgb();

                control = ControlFactory.Find("Specular Multiplier");
                if (control != null) bgsm.SpecularMult = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Smoothness");
                if (control != null) bgsm.Smoothness = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Fresnel Power");
                if (control != null) bgsm.FresnelPower = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Wet Spec Scale");
                if (control != null) bgsm.WetnessControlSpecScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Wet Spec Power Scale");
                if (control != null) bgsm.WetnessControlSpecPowerScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Wet Spec Min Var");
                if (control != null) bgsm.WetnessControlSpecMinvar = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Wet Env Map Scale");
                if (control != null) bgsm.WetnessControlEnvMapScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Wet Fresnel Power");
                if (control != null) bgsm.WetnessControlFresnelPower = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Wet Metalness");
                if (control != null) bgsm.WetnessControlMetalness = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("PBR");
                if (control != null) bgsm.PBR = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Custom Porosity");
                if (control != null) bgsm.CustomPorosity = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Porosity Value");
                if (control != null) bgsm.PorosityValue = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Root Material Path");
                if (control != null) bgsm.RootMaterialPath = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Aniso Lighting");
                if (control != null) bgsm.AnisoLighting = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Emittance Enabled");
                if (control != null) bgsm.EmitEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Emittance Color");
                if (control != null) bgsm.EmittanceColor = (uint)((Color)control.GetProperty()).ToArgb();

                control = ControlFactory.Find("Emittance Multiplier");
                if (control != null) bgsm.EmittanceMult = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Model Space Normals");
                if (control != null) bgsm.ModelSpaceNormals = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("External Emittance");
                if (control != null) bgsm.ExternalEmittance = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Lum Emittance");
                if (control != null) bgsm.LumEmittance = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Adaptative Emissive");
                if (control != null) bgsm.UseAdaptativeEmissive = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Adapt. Em. Exposure Offset");
                if (control != null) bgsm.AdaptativeEmissive_ExposureOffset = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Adapt. Em. Final Exposure Min");
                if (control != null) bgsm.AdaptativeEmissive_FinalExposureMin = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Adapt. Em. Final Exposure Max");
                if (control != null) bgsm.AdaptativeEmissive_FinalExposureMax = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Back Lighting");
                if (control != null) bgsm.BackLighting = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Receive Shadows");
                if (control != null) bgsm.ReceiveShadows = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Hide Secret");
                if (control != null) bgsm.HideSecret = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Cast Shadows");
                if (control != null) bgsm.CastShadows = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Dissolve Fade");
                if (control != null) bgsm.DissolveFade = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Assume Shadowmask");
                if (control != null) bgsm.AssumeShadowmask = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Glowmap");
                if (control != null) bgsm.Glowmap = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Environment Map Window");
                if (control != null) bgsm.EnvironmentMappingWindow = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Environment Map Eye");
                if (control != null) bgsm.EnvironmentMappingEye = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Hair");
                if (control != null) bgsm.Hair = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Hair Tint Color");
                if (control != null) bgsm.HairTintColor = (uint)((Color)control.GetProperty()).ToArgb();

                control = ControlFactory.Find("Tree");
                if (control != null) bgsm.Tree = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Facegen");
                if (control != null) bgsm.Facegen = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Skin Tint");
                if (control != null) bgsm.SkinTint = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Tessellate");
                if (control != null) bgsm.Tessellate = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Displacement Tex Bias");
                if (control != null) bgsm.DisplacementTextureBias = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Displacement Tex Scale");
                if (control != null) bgsm.DisplacementTextureScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Tessellation PN Scale");
                if (control != null) bgsm.TessellationPnScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Tessellation Base Factor");
                if (control != null) bgsm.TessellationBaseFactor = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Tessellation Fade Distance");
                if (control != null) bgsm.TessellationFadeDistance = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Grayscale To Palette Scale");
                if (control != null) bgsm.GrayscaleToPaletteScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Skew Specular Alpha");
                if (control != null) bgsm.SkewSpecularAlpha = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Terrain");
                if (control != null) bgsm.Terrain = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Unk Int 1 BGSM");
                if (control != null) bgsm.UnkInt1 = Convert.ToUInt32(control.GetProperty());

                control = ControlFactory.Find("Terrain Threshold Falloff");
                if (control != null) bgsm.TerrainThresholdFalloff = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Terrain Tiling Distance");
                if (control != null) bgsm.TerrainTilingDistance = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Terrain Rotation Angle");
                if (control != null) bgsm.TerrainRotationAngle = Convert.ToSingle(control.GetProperty());
            }
            else if (file.GetType() == typeof(BGEM))
            {
                BGEM bgem = (BGEM)file;

                control = ControlFactory.Find("Base Texture");
                if (control != null) bgem.BaseTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Grayscale Texture");
                if (control != null) bgem.GrayscaleTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Envmap Texture");
                if (control != null) bgem.EnvmapTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Normal Texture");
                if (control != null) bgem.NormalTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Envmap Mask Texture");
                if (control != null) bgem.EnvmapMaskTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Specular Texture");
                if (control != null) bgem.SpecularTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Lighting Texture");
                if (control != null) bgem.LightingTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Glow Texture");
                if (control != null) bgem.GlowTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Env Mapping");
                if (control != null && control.Serialize) bgem.EnvironmentMapping = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Env Mapping Mask Scale");
                if (control != null && control.Serialize) bgem.EnvironmentMappingMaskScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Blood Enabled");
                if (control != null) bgem.BloodEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Effect Lighting Enabled");
                if (control != null) bgem.EffectLightingEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Falloff Enabled");
                if (control != null) bgem.FalloffEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Falloff Color Enabled");
                if (control != null) bgem.FalloffColorEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Grayscale To Palette Alpha");
                if (control != null) bgem.GrayscaleToPaletteAlpha = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Soft Enabled");
                if (control != null) bgem.SoftEnabled = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Base Color");
                if (control != null) bgem.BaseColor = (uint)((Color)control.GetProperty()).ToArgb();

                control = ControlFactory.Find("Base Color Scale");
                if (control != null) bgem.BaseColorScale = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Falloff Start Angle");
                if (control != null) bgem.FalloffStartAngle = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Falloff Stop Angle");
                if (control != null) bgem.FalloffStopAngle = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Falloff Start Opacity");
                if (control != null) bgem.FalloffStartOpacity = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Falloff Stop Opacity");
                if (control != null) bgem.FalloffStopOpacity = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Lighting Influence");
                if (control != null) bgem.LightingInfluence = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Envmap Min LOD");
                if (control != null) bgem.EnvmapMinLOD = Convert.ToByte(control.GetProperty());

                control = ControlFactory.Find("Soft Depth");
                if (control != null) bgem.SoftDepth = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Emit Color");
                if (control != null) bgem.EmittanceColor = (uint)((Color)control.GetProperty()).ToArgb();

                control = ControlFactory.Find("Adaptative Em. Exposure Offset");
                if (control != null) bgem.AdaptativeEmissive_ExposureOffset = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Adaptative Em. Final Exp. Min");
                if (control != null) bgem.AdaptativeEmissive_FinalExposureMin = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Adaptative Em. Final Exp. Max");
                if (control != null) bgem.AdaptativeEmissive_FinalExposureMax = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Effect Glowmap");
                if (control != null) bgem.Glowmap = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Effect PBR Specular");
                if (control != null) bgem.EffectPbrSpecular = Convert.ToBoolean(control.GetProperty());
            }
        }

        private void OpenMaterial(string fileName, uint signature)
        {
            BaseMaterialFile material;
            if (signature == BGSM.Signature)
                material = new BGSM();
            else if (signature == BGEM.Signature)
                material = new BGEM();
            else
                return;

            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                char start = Convert.ToChar(file.ReadByte());
                file.Position = 0;

                // Check for JSON
                if (start == '{' || start == '[')
                {
                    try
                    {
                        var ser = new DataContractJsonSerializer(material.GetType());
                        if (signature == BGSM.Signature)
                            material = (BGSM)ser.ReadObject(file);
                        else if (signature == BGEM.Signature)
                            material = (BGEM)ser.ReadObject(file);
                    }
                    catch (Exception) { }
                }
                // Try binary
                else if (!material.Open(file))
                {
                    MessageBox.Show(string.Format("Failed to open file '{0}'!", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                workFilePath = fileName;

                SuspendAll();
                ControlFactory.ClearControls();

                if (material.Version > 21)
                {
                    MessageBox.Show($"Version {material.Version} not currently supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (material.Version > 2 && material.Version <= 21)
                    listVersion.SelectedIndex = (int)GameVersion.FO76;
                else
                    listVersion.SelectedIndex = (int)GameVersion.FO4;

                if (signature == BGSM.Signature)
                    listMatType.SelectedIndex = (int)MaterialType.Material;
                else if (signature == BGEM.Signature)
                    listMatType.SelectedIndex = (int)MaterialType.Effect;

                CreateMaterialControls(material);
                ResumeAll();

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                layoutGeneral.Enabled = true;
                layoutMaterial.Enabled = true;
                layoutEffect.Enabled = true;

                int nameIndex = fileName.LastIndexOf('\\');
                Text = fileName.Substring(nameIndex + 1, fileName.Length - nameIndex - 1);
                changed = false;
            }
        }
        #endregion
    }
}
