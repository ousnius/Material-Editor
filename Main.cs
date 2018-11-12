using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace Material_Editor
{
    public struct Config
    {
        public GameVersion GameVersion;
    }

    public enum GameVersion
    {
        FO4,
        FO76
    }

    public partial class Main : Form
    {
        private Config config = new Config();
        private string workFileName;
        private bool changed;

        public Main()
        {
            InitializeComponent();

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

        #region UI
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workFileName = string.Empty;

            saveAsToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            layoutGeneral.Enabled = true;
            layoutMaterial.Enabled = true;
            layoutEffect.Enabled = true;

            layoutGeneral.SuspendLayout();
            layoutMaterial.SuspendLayout();
            layoutEffect.SuspendLayout();

            CreateMaterialControls();

            layoutGeneral.ResumeLayout(true);
            layoutMaterial.ResumeLayout(true);
            layoutEffect.ResumeLayout(true);
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
            if (string.IsNullOrEmpty(workFileName))
            {
                saveAsToolStripMenuItem_Click(null, null);
            }

            BaseMaterialFile material;
            if (workFileName.ToLower().EndsWith(".bgsm"))
                material = new BGSM();
            else if (workFileName.ToLower().EndsWith(".bgem"))
                material = new BGEM();
            else
                return;

            GetMaterialValues(material);

            try
            {
                using (var file = new FileStream(workFileName, FileMode.Create))
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
                            MessageBox.Show(string.Format("Failed to serialize to JSON data for file '{0}'!", workFileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show(string.Format("Failed to save file '{0}'!", workFileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Failed to save file '{0}'!", workFileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nameIndex = workFileName.LastIndexOf('\\');
            Text = workFileName.Substring(nameIndex + 1, workFileName.Length - nameIndex - 1);
            changed = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.AddExtension = false;
            saveFileDialog.DefaultExt = "";
            if (!string.IsNullOrEmpty(workFileName))
            {
                int fileIndex = workFileName.LastIndexOf('\\');
                if (fileIndex >= 0)
                {
                    string fileName = workFileName.Substring(fileIndex + 1, workFileName.Length - fileIndex - 1);
                    saveFileDialog.FileName = fileName;
                }
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                BaseMaterialFile material;
                if (fileName.ToLower().EndsWith(".bgsm"))
                    material = new BGSM();
                else if (fileName.ToLower().EndsWith(".bgem"))
                    material = new BGEM();
                else
                    return;

                GetMaterialValues(material);

                try
                {
                    using (var file = new FileStream(fileName, FileMode.Create))
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
                                MessageBox.Show(string.Format("Failed to serialize to JSON data for file '{0}'!", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show(string.Format("Failed to save file '{0}'!", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(string.Format("Failed to save file '{0}'!", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                workFileName = fileName;

                saveToolStripMenuItem.Enabled = true;

                int nameIndex = workFileName.LastIndexOf('\\');
                Text = workFileName.Substring(nameIndex + 1, workFileName.Length - nameIndex - 1);
                changed = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workFileName = string.Empty;

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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutDialog();
            about.ShowDialog();
        }
        

        private void TabScroll(object sender, ScrollEventArgs e)
        {
            TabPage tab = (TabPage)sender;
            tab.Update();
        }

        private void OnChanged()
        {
            if (!string.IsNullOrEmpty(workFileName))
            {
                int nameIndex = workFileName.LastIndexOf('\\');
                Text = "*" + workFileName.Substring(nameIndex + 1, workFileName.Length - nameIndex - 1);
                changed = true;
            }
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
            layoutGeneral.SuspendLayout();
            layoutMaterial.SuspendLayout();
            layoutEffect.SuspendLayout();
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            ResumeLayout(true);
            layoutGeneral.ResumeLayout(true);
            layoutMaterial.ResumeLayout(true);
            layoutEffect.ResumeLayout(true);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReadSettings();

            var items = Enum.GetNames(typeof(GameVersion));
            listVersion.Items.AddRange(items);
            listVersion.SelectedIndex = (int)config.GameVersion;
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

        private void listVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedVersion = (GameVersion)listVersion.SelectedIndex;
            if (config.GameVersion != selectedVersion)
            {
                config.GameVersion = selectedVersion;
                SetControlVisibility();
                OnChanged();
            }
        }
        #endregion

        #region Material
        private void CreateMaterialControls(BaseMaterialFile file = null)
        {
            bool defaultValues = file == null;
            if (defaultValues)
                file = new BGSM();

            ControlFactory.ClearControls();
            
            switch (config.GameVersion)
            {
                case GameVersion.FO4:
                    file.Version = 1;
                    break;

                case GameVersion.FO76:
                    file.Version = 20;
                    break;
            }

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
            ControlFactory.CreateControl(layoutGeneral, "Grayscale To Palette Color", file.GrayscaleToPaletteColor, (control) => { OnChanged(); });
            ControlFactory.CreateFlagControl(layoutGeneral, "Mask Writes", Enum.GetNames(typeof(BaseMaterialFile.MaskWriteFlags)), (int)file.MaskWrites, (control) => { OnChanged(); });

            if (file.GetType() == typeof(BGSM))
            {
                BGSM bgsm = (BGSM)file;

                ControlFactory.CreateFileControl(layoutMaterial, "Diffuse", FileControl.FileType.Texture, bgsm.DiffuseTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Normal", FileControl.FileType.Texture, bgsm.NormalTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Smooth Spec", FileControl.FileType.Texture, bgsm.SmoothSpecTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Greyscale", FileControl.FileType.Texture, bgsm.GreyscaleTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Environment", FileControl.FileType.Texture, bgsm.EnvmapTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Glow", FileControl.FileType.Texture, bgsm.GlowTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Inner Layer", FileControl.FileType.Texture, bgsm.InnerLayerTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Wrinkles", FileControl.FileType.Texture, bgsm.WrinklesTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Displacement", FileControl.FileType.Texture, bgsm.DisplacementTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Specular", FileControl.FileType.Texture, bgsm.SpecularTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Lighting", FileControl.FileType.Texture, bgsm.LightingTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Flow", FileControl.FileType.Texture, bgsm.FlowTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutMaterial, "Distance Field Alpha", FileControl.FileType.Texture, bgsm.DistanceFieldAlphaTexture, (control) => { OnChanged(); });

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

                var translucencySubsurfaceColor = Color.FromArgb((int)bgsm.TranslucencySubsurfaceColor);
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

                var specularColor = Color.FromArgb((int)bgsm.SpecularColor);
                ControlFactory.CreateControl(layoutMaterial, "Specular Color", specularColor, (control) => { OnChanged(); });

                ControlFactory.CreateControl(layoutMaterial, "Specular Multiplier", bgsm.SpecularMult, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Smoothness", Math.Min(Math.Max(0.0f, bgsm.Smoothness), 1.0f), (control) => { OnChanged(); });
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

                ControlFactory.CreateFileControl(layoutMaterial, "Root Material Path", FileControl.FileType.Material, bgsm.RootMaterialPath, (control) => { OnChanged(); });

                ControlFactory.CreateControl(layoutMaterial, "Aniso Lighting", bgsm.AnisoLighting, (control) => { OnChanged(); });

                ControlFactory.CreateControl(layoutMaterial, "Emittance Enabled", bgsm.EmitEnabled, (control) =>
                {
                    bool enabled = Convert.ToBoolean(control.GetProperty());

                    ControlFactory.SetVisible("Emittance Color", enabled);
                    ControlFactory.SetVisible("Emittance Multiplier", enabled);
                    
                    OnChanged();
                });

                var emittanceColor = Color.FromArgb((int)bgsm.EmittanceColor);
                ControlFactory.CreateControl(layoutMaterial, "Emittance Color", emittanceColor, (control) => { OnChanged(); });

                ControlFactory.CreateControl(layoutMaterial, "Emittance Multiplier", bgsm.EmittanceMult, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Model Space Normals", bgsm.ModelSpaceNormals, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "External Emittance", bgsm.ExternalEmittance, (control) => { OnChanged(); });
                
                ControlFactory.CreateControl(layoutMaterial, "Lum Emittance", bgsm.LumEmittance, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Terrain", bgsm.Terrain, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Terrain Threshold Falloff", bgsm.TerrainThresholdFalloff, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Terrain Tiling Distance", bgsm.TerrainTilingDistance, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Terrain Rotation Angle", bgsm.TerrainRotationAngle, (control) => { OnChanged(); });

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

                var hairTintColor = Color.FromArgb((int)bgsm.HairTintColor);
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

                ControlFactory.CreateControl(layoutMaterial, "Unk Bool 2 BGSM", bgsm.UnkBool2, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Unk Int 1 BGSM", bgsm.UnkInt1, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Unk Single 1 BGSM", bgsm.UnkSingle1, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Unk Single 2 BGSM", bgsm.UnkSingle2, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutMaterial, "Unk Single 3 BGSM", bgsm.UnkSingle3, (control) => { OnChanged(); });
            }

            if (defaultValues)
                file = new BGEM();

            if (file.GetType() == typeof(BGEM))
            {
                BGEM bgem = (BGEM)file;

                ControlFactory.CreateFileControl(layoutEffect, "Base Texture", FileControl.FileType.Texture, bgem.BaseTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Grayscale Texture", FileControl.FileType.Texture, bgem.GrayscaleTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Envmap Texture", FileControl.FileType.Texture, bgem.EnvmapTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Normal Texture", FileControl.FileType.Texture, bgem.NormalTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Envmap Mask Texture", FileControl.FileType.Texture, bgem.EnvmapMaskTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Specular Texture", FileControl.FileType.Texture, bgem.SpecularTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Lighting Texture", FileControl.FileType.Texture, bgem.LightingTexture, (control) => { OnChanged(); });
                ControlFactory.CreateFileControl(layoutEffect, "Distance Field Alpha Texture", FileControl.FileType.Texture, bgem.DistanceFieldAlphaTexture, (control) => { OnChanged(); });

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

                var baseColor = Color.FromArgb((int)bgem.BaseColor);
                ControlFactory.CreateControl(layoutEffect, "Base Color", baseColor, (control) => { OnChanged(); });

                ControlFactory.CreateControl(layoutEffect, "Base Color Scale", bgem.BaseColorScale, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Falloff Start Angle", bgem.FalloffStartAngle, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Falloff Stop Angle", bgem.FalloffStopAngle, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Falloff Start Opacity", bgem.FalloffStartOpacity, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Falloff Stop Opacity", bgem.FalloffStopOpacity, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Lighting Influence", bgem.LightingInfluence, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Envmap Min LOD", bgem.EnvmapMinLOD, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Soft Depth", bgem.SoftDepth, (control) => { OnChanged(); });

                var emitColor = Color.FromArgb((int)bgem.EmittanceColor);
                ControlFactory.CreateControl(layoutEffect, "Emit Color", emitColor, (control) => { OnChanged(); });

                ControlFactory.CreateControl(layoutEffect, "Lum Emit", bgem.LumEmittance, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Unk Single 1 BGEM", bgem.UnkSingle1, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Unk Single 2 BGEM", bgem.UnkSingle2, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Unk Byte 1 BGEM", bgem.UnkByte1, (control) => { OnChanged(); });
                ControlFactory.CreateControl(layoutEffect, "Unk Byte 2 BGEM", bgem.UnkByte2, (control) => { OnChanged(); });
            }

            SetControlVisibility();
        }

        private void SetControlVisibility()
        {
            layoutGeneral.SuspendLayout();
            layoutMaterial.SuspendLayout();
            layoutEffect.SuspendLayout();

            switch (config.GameVersion)
            {
                case GameVersion.FO4:
                    ControlFactory.SetVisible("Environment Mask Scale", true);
                    ControlFactory.SetVisible("Mask Writes", false);

                    ControlFactory.SetVisible("Inner Layer", true);
                    ControlFactory.SetVisible("Wrinkles", true);
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
                    ControlFactory.SetVisible("Back Light Power", true);
                    ControlFactory.SetVisible("Subsurface Lighting", true);
                    ControlFactory.SetVisible("Subsurface Lighting Rolloff", true);

                    ControlFactory.SetVisible("Wet Env Map Scale", true);

                    ControlFactory.SetVisible("PBR", false);
                    ControlFactory.SetVisible("Custom Porosity", false);
                    ControlFactory.SetVisible("Porosity Value", false);

                    ControlFactory.SetVisible("Lum Emittance", false);

                    ControlFactory.SetVisible("Terrain", false);
                    ControlFactory.SetVisible("Terrain Threshold Falloff", false);
                    ControlFactory.SetVisible("Terrain Tiling Distance", false);
                    ControlFactory.SetVisible("Terrain Rotation Angle", false);

                    ControlFactory.SetVisible("Back Lighting", true);

                    ControlFactory.SetVisible("Environment Map Window", true);
                    ControlFactory.SetVisible("Environment Map Eye", true);

                    ControlFactory.SetVisible("Displacement Tex Bias", true);
                    ControlFactory.SetVisible("Displacement Tex Scale", true);
                    ControlFactory.SetVisible("Tessellation PN Scale", true);
                    ControlFactory.SetVisible("Tessellation Base Factor", true);
                    ControlFactory.SetVisible("Tessellation Fade Distance", true);

                    ControlFactory.SetVisible("Unk Bool 2 BGSM", false);
                    ControlFactory.SetVisible("Unk Int 1 BGSM", false);
                    ControlFactory.SetVisible("Unk Single 1 BGSM", false);
                    ControlFactory.SetVisible("Unk Single 2 BGSM", false);
                    ControlFactory.SetVisible("Unk Single 3 BGSM", false);

                    ControlFactory.SetVisible("Specular Texture", false);
                    ControlFactory.SetVisible("Lighting Texture", false);
                    ControlFactory.SetVisible("Distance Field Alpha Texture", false);

                    ControlFactory.SetVisible("Env Mapping", false);
                    ControlFactory.SetVisible("Env Mapping Mask Scale", false);

                    ControlFactory.SetVisible("Emit Color", false);
                    ControlFactory.SetVisible("Lum Emit", false);
                    ControlFactory.SetVisible("Unk Single 1 BGEM", false);
                    ControlFactory.SetVisible("Unk Single 2 BGEM", false);
                    ControlFactory.SetVisible("Unk Byte 1 BGEM", false);
                    ControlFactory.SetVisible("Unk Byte 2 BGEM", false);
                    break;

                case GameVersion.FO76:
                    ControlFactory.SetVisible("Environment Mask Scale", false);
                    ControlFactory.SetVisible("Mask Writes", true);

                    ControlFactory.SetVisible("Inner Layer", false);
                    ControlFactory.SetVisible("Wrinkles", false);
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
                    ControlFactory.SetVisible("Back Light Power", false);
                    ControlFactory.SetVisible("Subsurface Lighting", false);
                    ControlFactory.SetVisible("Subsurface Lighting Rolloff", false);

                    ControlFactory.SetVisible("Wet Env Map Scale", false);

                    ControlFactory.SetVisible("PBR", true);
                    ControlFactory.SetVisible("Custom Porosity", true);
                    ControlFactory.SetVisible("Porosity Value", true);

                    ControlFactory.SetVisible("Lum Emittance", true);

                    ControlFactory.SetVisible("Terrain", true);
                    ControlFactory.SetVisible("Terrain Threshold Falloff", true);
                    ControlFactory.SetVisible("Terrain Tiling Distance", true);
                    ControlFactory.SetVisible("Terrain Rotation Angle", true);

                    ControlFactory.SetVisible("Back Lighting", false);

                    ControlFactory.SetVisible("Environment Map Window", false);
                    ControlFactory.SetVisible("Environment Map Eye", false);

                    ControlFactory.SetVisible("Displacement Tex Bias", false);
                    ControlFactory.SetVisible("Displacement Tex Scale", false);
                    ControlFactory.SetVisible("Tessellation PN Scale", false);
                    ControlFactory.SetVisible("Tessellation Base Factor", false);
                    ControlFactory.SetVisible("Tessellation Fade Distance", false);

                    ControlFactory.SetVisible("Unk Bool 2 BGSM", true);
                    ControlFactory.SetVisible("Unk Int 1 BGSM", true);
                    ControlFactory.SetVisible("Unk Single 1 BGSM", true);
                    ControlFactory.SetVisible("Unk Single 2 BGSM", true);
                    ControlFactory.SetVisible("Unk Single 3 BGSM", true);

                    ControlFactory.SetVisible("Specular Texture", true);
                    ControlFactory.SetVisible("Lighting Texture", true);
                    ControlFactory.SetVisible("Distance Field Alpha Texture", true);

                    ControlFactory.SetVisible("Env Mapping", true);
                    ControlFactory.SetVisible("Env Mapping Mask Scale", true);

                    ControlFactory.SetVisible("Emit Color", true);
                    ControlFactory.SetVisible("Lum Emit", true);
                    ControlFactory.SetVisible("Unk Single 1 BGEM", true);
                    ControlFactory.SetVisible("Unk Single 2 BGEM", true);
                    ControlFactory.SetVisible("Unk Byte 1 BGEM", true);
                    ControlFactory.SetVisible("Unk Byte 2 BGEM", true);
                    break;
            }

            ControlFactory.RunChangedCallbacks();

            layoutGeneral.ResumeLayout();
            layoutMaterial.ResumeLayout();
            layoutEffect.ResumeLayout();
        }

        private void GetMaterialValues(BaseMaterialFile file)
        {
            CustomControl control = null;

            switch (config.GameVersion)
            {
                case GameVersion.FO4:
                    file.Version = 1;
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
            if (control != null) file.EnvironmentMapping = Convert.ToBoolean(control.GetProperty());

            control = ControlFactory.Find("Environment Mask Scale");
            if (control != null) file.EnvironmentMappingMaskScale = Convert.ToSingle(control.GetProperty());

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

                control = ControlFactory.Find("Terrain");
                if (control != null) bgsm.Terrain = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Terrain Threshold Falloff");
                if (control != null) bgsm.TerrainThresholdFalloff = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Terrain Tiling Distance");
                if (control != null) bgsm.TerrainTilingDistance = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("TerrainRotationAngle");
                if (control != null) bgsm.TerrainRotationAngle = Convert.ToSingle(control.GetProperty());

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

                control = ControlFactory.Find("Unk Bool 2 BGSM");
                if (control != null) bgsm.UnkBool2 = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Unk Int 1 BGSM");
                if (control != null) bgsm.UnkInt1 = Convert.ToUInt32(control.GetProperty());

                control = ControlFactory.Find("Unk Single 1 BGSM");
                if (control != null) bgsm.UnkSingle1 = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Unk Single 2 BGSM");
                if (control != null) bgsm.UnkSingle2 = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Unk Single 3 BGSM");
                if (control != null) bgsm.UnkSingle3 = Convert.ToSingle(control.GetProperty());
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

                control = ControlFactory.Find("Distance Field Alpha Texture");
                if (control != null) bgem.DistanceFieldAlphaTexture = Convert.ToString(control.GetProperty());

                control = ControlFactory.Find("Env Mapping");
                if (control != null) bgem.EnvironmentMapping = Convert.ToBoolean(control.GetProperty());

                control = ControlFactory.Find("Env Mapping Mask Scale");
                if (control != null) bgem.EnvironmentMappingMaskScale = Convert.ToSingle(control.GetProperty());

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

                control = ControlFactory.Find("Lum Emit");
                if (control != null) bgem.LumEmittance = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Unk Single 1 BGEM");
                if (control != null) bgem.UnkSingle1 = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Unk Single 2 BGEM");
                if (control != null) bgem.UnkSingle2 = Convert.ToSingle(control.GetProperty());

                control = ControlFactory.Find("Unk Byte 1 BGEM");
                if (control != null) bgem.UnkByte1 = Convert.ToByte(control.GetProperty());

                control = ControlFactory.Find("Unk Byte 2 BGEM");
                if (control != null) bgem.UnkByte2 = Convert.ToByte(control.GetProperty());
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

                layoutGeneral.SuspendLayout();
                layoutMaterial.SuspendLayout();
                layoutEffect.SuspendLayout();

                CreateMaterialControls(material);

                layoutGeneral.ResumeLayout(true);
                layoutMaterial.ResumeLayout(true);
                layoutEffect.ResumeLayout(true);

                workFileName = fileName;

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
