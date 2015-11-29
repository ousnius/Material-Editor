using System;
using System.Drawing;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class Main : Form
    {
        private string workFileName;

        public Main()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string fileName = args[1].ToLower();
                if (fileName.EndsWith(".bgsm"))
                {
                    OpenMaterial(fileName, BGSM.Signature);
                }
                else if (fileName.EndsWith(".bgem"))
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
            tabControl.Enabled = true;

            // Default values
            BaseMaterialFile bgsm = new BGSM();
            BaseMaterialFile bgem = new BGEM();
            SetUIFromMaterial(ref bgsm);
            SetUIFromMaterial(ref bgem);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName.ToLower();
                if (file.EndsWith(".bgsm"))
                {
                    OpenMaterial(file, BGSM.Signature);
                }
                else if (file.EndsWith(".bgem"))
                {
                    OpenMaterial(file, BGEM.Signature);
                }
                else
                {
                    MessageBox.Show("File extension not supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workFileName))
                return;

            BaseMaterialFile material;
            if (workFileName.EndsWith(".bgsm"))
                material = new BGSM();
            else if (workFileName.EndsWith(".bgem"))
                material = new BGEM();
            else
                return;

            SetMaterialFromUI(ref material);

            if (!material.Save(workFileName))
            {
                MessageBox.Show("Failed to save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workFileName = saveFileDialog.FileName.ToLower();
                this.Text = workFileName.Remove(0, workFileName.LastIndexOf('\\') + 1);
                saveToolStripMenuItem.Enabled = true;

                BaseMaterialFile material;
                if (workFileName.EndsWith(".bgsm"))
                    material = new BGSM();
                else if (workFileName.EndsWith(".bgem"))
                    material = new BGEM();
                else
                    return;

                SetMaterialFromUI(ref material);

                if (!material.Save(workFileName))
                {
                    MessageBox.Show("Failed to save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workFileName = string.Empty;

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            tabControl.Enabled = false;
            this.Text = "Material Editor";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog();
        }

        private void ColorClicked(object sender, EventArgs e)
        {
            Button btColor = (Button)sender;
            colorDialog.Color = btColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btColor.BackColor = colorDialog.Color;
            }
        }

        private void TabScroll(object sender, ScrollEventArgs e)
        {
            TabPage tab = (TabPage)sender;
            tab.Update();
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout(true);
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
                if (file.EndsWith(".bgsm"))
                {
                    OpenMaterial(file, BGSM.Signature);
                }
                else if (file.EndsWith(".bgem"))
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
        private void SetUIFromMaterial(ref BaseMaterialFile file)
        {
            // Base
            numVersion.Value = file.Version;
            cbTileU.Checked = file.TileU;
            cbTileV.Checked = file.TileV;
            numOffsetU.Value = Convert.ToDecimal(file.UOffset);
            numOffsetV.Value = Convert.ToDecimal(file.VOffset);
            numScaleU.Value = Convert.ToDecimal(file.UScale);
            numScaleV.Value = Convert.ToDecimal(file.VScale);
            numAlpha.Value = Convert.ToDecimal(file.Alpha);

            int alphaBlendMode = (int)file.AlphaBlendMode;
            if (alphaBlendMode < 0 || alphaBlendMode > 4)
                alphaBlendMode = 0;

            selAlphaBlendMode.SelectedIndex = alphaBlendMode;

            numAlphaTestReference.Value = file.AlphaTestRef;
            cbAlphaTest.Checked = file.AlphaTest;
            cbZBufferWrite.Checked = file.ZBufferWrite;
            cbZBufferTest.Checked = file.ZBufferTest;
            cbScreenSpaceReflections.Checked = file.ScreenSpaceReflections;
            cbWetnessControlSSR.Checked = file.WetnessControlScreenSpaceReflections;
            cbDecal.Checked = file.Decal;
            cbTwoSided.Checked = file.TwoSided;
            cbDecalNoFade.Checked = file.DecalNoFade;
            cbNonOccluder.Checked = file.NonOccluder;
            cbRefraction.Checked = file.Refraction;
            cbRefractionFalloff.Checked = file.RefractionFalloff;
            numRefractionPower.Value = Convert.ToDecimal(file.RefractionPower);
            cbEnvironmentMapping.Checked = file.EnvironmentMapping;
            numEnvironmentMaskScale.Value = Convert.ToDecimal(file.EnvironmentMappingMaskScale);
            cbGrayscaleToPaletteColor.Checked = file.GrayscaleToPaletteColor;

            if (file.GetType() == typeof(BGSM))
            {
                // BGSM
                BGSM bgsm = (BGSM)file;
                tbDiffuseTexture.Text = bgsm.DiffuseTexture;
                tbNormalTexture.Text = bgsm.NormalTexture;
                tbSmoothSpecularTexture.Text = bgsm.SmoothSpecTexture;
                tbGreyscaleTexture.Text = bgsm.GreyscaleTexture;
                tbEnvironmentMapTexture.Text = bgsm.EnvmapTexture;
                tbGlowTexture.Text = bgsm.GlowTexture;
                tbInnerLayerTexture.Text = bgsm.InnerLayerTexture;
                tbWrinklesTexture.Text = bgsm.WrinklesTexture;
                tbDisplacementTexture.Text = bgsm.DisplacementTexture;
                cbEnableEditorAlphaRef.Checked = bgsm.EnableEditorAlphaRef;
                cbRimLighting.Checked = bgsm.RimLighting;
                numBacklightPower.Value = Convert.ToDecimal(bgsm.BackLightPower);
                cbSubsurfaceLighting.Checked = bgsm.SubsurfaceLighting;
                numSubsurfaceLightingRolloff.Value = Convert.ToDecimal(bgsm.SubsurfaceLightingRolloff);
                cbSpecularEnabled.Checked = bgsm.SpecularEnabled;

                Color specularColor = Color.FromArgb((int)bgsm.SpecularColor);
                btSpecularColor.BackColor = Color.FromArgb(specularColor.R, specularColor.G, specularColor.B);

                numSpecularMultiplier.Value = Convert.ToDecimal(bgsm.SpecularMult);
                numSmoothness.Value = Convert.ToDecimal(bgsm.Smoothness);
                numFresnelPower.Value = Convert.ToDecimal(bgsm.FresnelPower);
                numWetSpecScale.Value = Convert.ToDecimal(bgsm.WetnessControlSpecScale);
                numWetSpecPowerScale.Value = Convert.ToDecimal(bgsm.WetnessControlSpecPowerScale);
                numWetSpecMinVar.Value = Convert.ToDecimal(bgsm.WetnessControlSpecMinvar);
                numWetEnvMapScale.Value = Convert.ToDecimal(bgsm.WetnessControlEnvMapScale);
                numWetFresnelPower.Value = Convert.ToDecimal(bgsm.WetnessControlFresnelPower);
                numWetMetalness.Value = Convert.ToDecimal(bgsm.WetnessControlMetalness);
                tbRootMaterialPath.Text = bgsm.RootMaterialPath;
                cbAnisoLighting.Checked = bgsm.AnisoLighting;
                cbEmittanceEnabled.Checked = bgsm.EmitEnabled;

                Color emittanceColor = Color.FromArgb((int)bgsm.EmittanceColor);
                btEmittanceColor.BackColor = Color.FromArgb(emittanceColor.R, emittanceColor.G, emittanceColor.B);

                numEmittanceMultiplier.Value = Convert.ToDecimal(bgsm.EmittanceMult);
                cbModelSpaceNormals.Checked = bgsm.ModelSpaceNormals;
                cbExternalEmittance.Checked = bgsm.ExternalEmittance;
                cbBackLighting.Checked = bgsm.BackLighting;
                cbReceiveShadows.Checked = bgsm.ReceiveShadows;
                cbHideSecret.Checked = bgsm.HideSecret;
                cbCastShadows.Checked = bgsm.CastShadows;
                cbDissolveFade.Checked = bgsm.DissolveFade;
                cbAssumeShadowmask.Checked = bgsm.AssumeShadowmask;
                cbGlowmap.Checked = bgsm.Glowmap;
                cbEnvironmentMapWindow.Checked = bgsm.EnvironmentMappingWindow;
                cbEnvironmentMapEye.Checked = bgsm.EnvironmentMappingEye;
                cbHair.Checked = bgsm.Hair;

                Color hairTintColor = Color.FromArgb((int)bgsm.HairTintColor);
                btHairTintColor.BackColor = Color.FromArgb(hairTintColor.R, hairTintColor.G, hairTintColor.B);

                cbTree.Checked = bgsm.Tree;
                cbFacegen.Checked = bgsm.Facegen;
                cbSkinTint.Checked = bgsm.SkinTint;

                cbTessellate.Checked = bgsm.Tessellate;
                numDisplacementTexBias.Value = Convert.ToDecimal(bgsm.DisplacementTextureBias);
                numDisplacementTexScale.Value = Convert.ToDecimal(bgsm.DisplacementTextureScale);
                numTessellationPNScale.Value = Convert.ToDecimal(bgsm.TessellationPnScale);
                numTessellationBaseFactor.Value = Convert.ToDecimal(bgsm.TessellationBaseFactor);
                numTessellationFadeDistance.Value = Convert.ToDecimal(bgsm.TessellationFadeDistance);

                numGrayscaleToPaletteScale.Value = Convert.ToDecimal(bgsm.GrayscaleToPaletteScale);
                cbSkewSpecularAlpha.Checked = bgsm.SkewSpecularAlpha;
            }
            else if (file.GetType() == typeof(BGEM))
            {
                // BGEM
                BGEM bgem = (BGEM)file;
                tbBaseTexture.Text = bgem.BaseTexture;
                tbGrayscaleTexture.Text = bgem.GrayscaleTexture;
                tbEnvmapTexture.Text = bgem.EnvmapTexture;
                tbNormalTexture_effect.Text = bgem.NormalTexture;
                tbEnvmapMaskTexture.Text = bgem.EnvmapMaskTexture;

                cbBloodEnabled.Checked = bgem.BloodEnabled;
                cbEffectLightingEnabled.Checked = bgem.EffectLightingEnabled;
                cbFalloffEnabled.Checked = bgem.FalloffEnabled;
                cbFalloffColorEnabled.Checked = bgem.FalloffColorEnabled;
                cbGrayscaleToPaletteAlpha.Checked = bgem.GrayscaleToPaletteAlpha;
                cbSoftEnabled.Checked = bgem.SoftEnabled;

                Color baseColor = Color.FromArgb((int)bgem.BaseColor);
                btBaseColor.BackColor = Color.FromArgb(baseColor.R, baseColor.G, baseColor.B);

                numBaseColorScale.Value = Convert.ToDecimal(bgem.BaseColorScale);
                numFalloffStartAngle.Value = Convert.ToDecimal(bgem.FalloffStartAngle);
                numFalloffStopAngle.Value = Convert.ToDecimal(bgem.FalloffStopAngle);
                numFalloffStartOpacity.Value = Convert.ToDecimal(bgem.FalloffStartOpacity);
                numFalloffStopOpacity.Value = Convert.ToDecimal(bgem.FalloffStopOpacity);
                numLightingInfluence.Value = Convert.ToDecimal(bgem.LightingInfluence);
                numEnvmapMinLOD.Value = bgem.EnvmapMinLOD;
            }
        }

        private void SetMaterialFromUI(ref BaseMaterialFile file)
        {
            // Base
            file.Version = Convert.ToUInt32(numVersion.Value);
            file.TileU = cbTileU.Checked;
            file.TileV = cbTileV.Checked;
            file.UOffset = Convert.ToSingle(numOffsetU.Value);
            file.VOffset = Convert.ToSingle(numOffsetV.Value);
            file.UScale = Convert.ToSingle(numScaleU.Value);
            file.VScale = Convert.ToSingle(numScaleV.Value);

            file.Alpha = Convert.ToSingle(numAlpha.Value);
            file.AlphaBlendMode = (BaseMaterialFile.AlphaBlendModeType)selAlphaBlendMode.SelectedIndex;
            file.AlphaTestRef = Convert.ToSByte(numAlphaTestReference.Value);
            file.AlphaTest = cbAlphaTest.Checked;
            file.ZBufferWrite = cbZBufferWrite.Checked;
            file.ZBufferTest = cbZBufferTest.Checked;

            file.ScreenSpaceReflections = cbScreenSpaceReflections.Checked;
            file.WetnessControlScreenSpaceReflections = cbWetnessControlSSR.Checked;
            file.Decal = cbDecal.Checked;
            file.TwoSided = cbTwoSided.Checked;
            file.DecalNoFade = cbDecalNoFade.Checked;
            file.NonOccluder = cbNonOccluder.Checked;
            file.Refraction = cbRefraction.Checked;
            file.RefractionFalloff = cbRefractionFalloff.Checked;
            file.RefractionPower = Convert.ToSingle(numRefractionPower.Value);
            file.EnvironmentMapping = cbEnvironmentMapping.Checked;
            file.EnvironmentMappingMaskScale = Convert.ToSingle(numEnvironmentMaskScale.Value);
            file.GrayscaleToPaletteColor = cbGrayscaleToPaletteColor.Checked;

            if (file.GetType() == typeof(BGSM))
            {
                // BGSM
                BGSM bgsm = (BGSM)file;
                bgsm.DiffuseTexture = tbDiffuseTexture.Text;
                bgsm.NormalTexture = tbNormalTexture.Text;
                bgsm.SmoothSpecTexture = tbSmoothSpecularTexture.Text;
                bgsm.GreyscaleTexture = tbGreyscaleTexture.Text;
                bgsm.EnvmapTexture = tbEnvironmentMapTexture.Text;
                bgsm.GlowTexture = tbGlowTexture.Text;
                bgsm.InnerLayerTexture = tbInnerLayerTexture.Text;
                bgsm.WrinklesTexture = tbWrinklesTexture.Text;
                bgsm.DisplacementTexture = tbDisplacementTexture.Text;

                bgsm.EnableEditorAlphaRef = cbEnableEditorAlphaRef.Checked;
                bgsm.RimLighting = cbRimLighting.Checked;
                bgsm.BackLightPower = Convert.ToSingle(numBacklightPower.Value);
                bgsm.SubsurfaceLighting = cbSubsurfaceLighting.Checked;
                bgsm.SubsurfaceLightingRolloff = Convert.ToSingle(numSubsurfaceLightingRolloff.Value);

                bgsm.SpecularEnabled = cbSpecularEnabled.Checked;
                bgsm.SpecularColor = (uint)btSpecularColor.BackColor.ToArgb();
                bgsm.SpecularMult = Convert.ToSingle(numSpecularMultiplier.Value);
                bgsm.Smoothness = Convert.ToSingle(numSmoothness.Value);
                bgsm.FresnelPower = Convert.ToSingle(numFresnelPower.Value);
                bgsm.WetnessControlSpecScale = Convert.ToSingle(numWetSpecScale.Value);
                bgsm.WetnessControlSpecPowerScale = Convert.ToSingle(numWetSpecPowerScale.Value);
                bgsm.WetnessControlSpecMinvar = Convert.ToSingle(numWetSpecMinVar.Value);
                bgsm.WetnessControlEnvMapScale = Convert.ToSingle(numWetEnvMapScale.Value);
                bgsm.WetnessControlFresnelPower = Convert.ToSingle(numWetFresnelPower.Value);
                bgsm.WetnessControlMetalness = Convert.ToSingle(numWetMetalness.Value);

                bgsm.RootMaterialPath = tbRootMaterialPath.Text;
                bgsm.AnisoLighting = cbAnisoLighting.Checked;
                bgsm.EmitEnabled = cbEmittanceEnabled.Checked;
                bgsm.EmittanceColor = (uint)btEmittanceColor.BackColor.ToArgb();
                bgsm.EmittanceMult = Convert.ToSingle(numEmittanceMultiplier.Value);
                bgsm.ModelSpaceNormals = cbModelSpaceNormals.Checked;
                bgsm.ExternalEmittance = cbExternalEmittance.Checked;
                bgsm.BackLighting = cbBackLighting.Checked;
                bgsm.ReceiveShadows = cbReceiveShadows.Checked;
                bgsm.HideSecret = cbHideSecret.Checked;
                bgsm.CastShadows = cbCastShadows.Checked;
                bgsm.DissolveFade = cbDissolveFade.Checked;
                bgsm.AssumeShadowmask = cbAssumeShadowmask.Checked;
                bgsm.Glowmap = cbGlowmap.Checked;
                bgsm.EnvironmentMappingWindow = cbEnvironmentMapWindow.Checked;
                bgsm.EnvironmentMappingEye = cbEnvironmentMapEye.Checked;
                bgsm.Hair = cbHair.Checked;
                bgsm.HairTintColor = (uint)btHairTintColor.BackColor.ToArgb();
                bgsm.Tree = cbTree.Checked;
                bgsm.Facegen = cbFacegen.Checked;
                bgsm.SkinTint = cbSkinTint.Checked;

                bgsm.Tessellate = cbTessellate.Checked;
                bgsm.DisplacementTextureBias = Convert.ToSingle(numDisplacementTexBias.Value);
                bgsm.DisplacementTextureScale = Convert.ToSingle(numDisplacementTexScale.Value);
                bgsm.TessellationPnScale = Convert.ToSingle(numTessellationPNScale.Value);
                bgsm.TessellationBaseFactor = Convert.ToSingle(numTessellationBaseFactor.Value);
                bgsm.TessellationFadeDistance = Convert.ToSingle(numTessellationFadeDistance.Value);

                bgsm.GrayscaleToPaletteScale = Convert.ToSingle(numGrayscaleToPaletteScale.Value);
                bgsm.SkewSpecularAlpha = cbSkewSpecularAlpha.Checked;
            }
            else if (file.GetType() == typeof(BGEM))
            {
                // BGEM
                BGEM bgem = (BGEM)file;
                bgem.BaseTexture = tbBaseTexture.Text;
                bgem.GrayscaleTexture = tbGrayscaleTexture.Text;
                bgem.EnvmapTexture = tbEnvmapTexture.Text;
                bgem.NormalTexture = tbNormalTexture_effect.Text;
                bgem.EnvmapMaskTexture = tbEnvmapMaskTexture.Text;

                bgem.BloodEnabled = cbBloodEnabled.Checked;
                bgem.EffectLightingEnabled = cbEffectLightingEnabled.Checked;
                bgem.FalloffEnabled = cbFalloffEnabled.Checked;
                bgem.FalloffColorEnabled = cbFalloffColorEnabled.Checked;
                bgem.GrayscaleToPaletteAlpha = cbGrayscaleToPaletteAlpha.Checked;
                bgem.SoftEnabled = cbSoftEnabled.Checked;

                bgem.BaseColor = (uint)btBaseColor.BackColor.ToArgb();
                bgem.BaseColorScale = Convert.ToSingle(numBaseColorScale.Value);
                bgem.FalloffStartAngle = Convert.ToSingle(numFalloffStartAngle.Value);
                bgem.FalloffStopAngle = Convert.ToSingle(numFalloffStopAngle.Value);
                bgem.FalloffStartOpacity = Convert.ToSingle(numFalloffStartOpacity.Value);
                bgem.FalloffStopOpacity = Convert.ToSingle(numFalloffStopOpacity.Value);
                bgem.LightingInfluence = Convert.ToSingle(numLightingInfluence.Value);
                bgem.EnvmapMinLOD = Convert.ToByte(numEnvmapMinLOD.Value);
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

            if (!material.Open(fileName))
            {
                MessageBox.Show("Failed to open file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            workFileName = fileName;

            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            tabControl.Enabled = true;

            int nameIndex = fileName.LastIndexOf('\\');
            this.Text = fileName.Substring(nameIndex + 1, fileName.Length - nameIndex - 1);

            SetUIFromMaterial(ref material);
        }
        #endregion
    }
}
