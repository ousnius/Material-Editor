using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class Main : Form
    {
        BGSM workMaterial;
        string workFileName;

        public Main()
        {
            InitializeComponent();
            tableLayoutPanel.Enabled = false;
            tableLayoutPanel.PerformLayout();
        }

        private void SetUIFromMaterial(ref BGSM bgsm)
        {
            numInt1.Value = bgsm.unk1;
            numInt2.Value = bgsm.unk2;
            numInt3.Value = bgsm.unk3;
            numInt4.Value = bgsm.unk4;

            numFloat1.Value = Convert.ToDecimal(bgsm.unkF1);
            numFloat2.Value = Convert.ToDecimal(bgsm.unkF2);
            numFloat3.Value = Convert.ToDecimal(bgsm.unkF3);

            numFlags1.Value = bgsm.flags1;
            numFlags2.Value = bgsm.flags2;

            numMysteryByte1.Value = bgsm.mysteryB1;
            numMysteryByte2.Value = bgsm.mysteryB2;

            cbUseAlpha.Checked = bgsm.useAlpha;

            numMysteryByte4.Value = bgsm.mysteryB4;
            numMysteryByte5.Value = bgsm.mysteryB5;
            numMysteryByte6.Value = bgsm.mysteryB6;
            numMysteryByte7.Value = bgsm.mysteryB7;
            numMysteryByte8.Value = bgsm.mysteryB8;

            cbUseDoubleSided.Checked = bgsm.useDoubleSided;

            numMysteryByte10.Value = bgsm.mysteryB10;
            numMysteryByte11.Value = bgsm.mysteryB11;
            numMysteryByte12.Value = bgsm.mysteryB12;
            numMysteryByte13.Value = bgsm.mysteryB13;
            numMysteryByte14.Value = bgsm.mysteryB14;
            numMysteryByte15.Value = bgsm.mysteryB15;
            numMysteryByte16.Value = bgsm.mysteryB16;
            numMysteryByte17.Value = bgsm.mysteryB17;
            numMysteryByte18.Value = bgsm.mysteryB18;
            numMysteryByte19.Value = bgsm.mysteryB19;
            numMysteryByte20.Value = bgsm.mysteryB20;
            numMysteryByte21.Value = bgsm.mysteryB21;
            numMysteryByte22.Value = bgsm.mysteryB22;
            numMysteryByte23.Value = bgsm.mysteryB23;

            tbTexture1.Text = bgsm.textures[0];
            tbTexture2.Text = bgsm.textures[1];
            tbTexture3.Text = bgsm.textures[2];
            tbTexture4.Text = bgsm.textures[3];
            tbTexture5.Text = bgsm.textures[4];
            tbTexture6.Text = bgsm.textures[5];
            tbTexture7.Text = bgsm.textures[6];
            tbTexture8.Text = bgsm.textures[7];
            tbTexture9.Text = bgsm.textures[8];

            numByte1.Value = bgsm.unkB1;
            numByte2.Value = bgsm.unkB2;

            numFloat4.Value = Convert.ToDecimal(bgsm.unkF4);
            numFloat5.Value = Convert.ToDecimal(bgsm.unkF5);

            numByte3.Value = bgsm.unkB3;
            numFloat6.Value = Convert.ToDecimal(bgsm.unkF6);

            cbUseWet.Checked = bgsm.useWet;

            btColor1.BackColor = Color.FromArgb(
                Convert.ToByte(bgsm.unkColor1.Red * 255.0f),
                Convert.ToByte(bgsm.unkColor1.Green * 255.0f),
                Convert.ToByte(bgsm.unkColor1.Blue * 255.0f));

            numSpecularStrength.Value = Convert.ToDecimal(bgsm.specularStrength);

            numFloat7_5.Value = Convert.ToDecimal(bgsm.unkF7_5);
            numFloat7_6.Value = Convert.ToDecimal(bgsm.unkF7_6);
            numFloat7_7.Value = Convert.ToDecimal(bgsm.unkF7_7);
            numFloat7_8.Value = Convert.ToDecimal(bgsm.unkF7_8);
            numFloat7_9.Value = Convert.ToDecimal(bgsm.unkF7_9);
            numFloat7_10.Value = Convert.ToDecimal(bgsm.unkF7_10);
            numFloat7_11.Value = Convert.ToDecimal(bgsm.unkF7_11);
            numFloat7_12.Value = Convert.ToDecimal(bgsm.unkF7_12);

            tbTemplate.Text = bgsm.template;

            numByte5.Value = bgsm.unkB5;
            numByte6.Value = bgsm.unkB6;
            numFloat8.Value = Convert.ToDecimal(bgsm.unkF8);

            numByte7.Value = bgsm.unkB7;
            numByte8.Value = bgsm.unkB8;
            numByte9.Value = bgsm.unkB9;
            numByte10.Value = bgsm.unkB10;
            numByte11.Value = bgsm.unkB11;
            numByte12.Value = bgsm.unkB12;
            numByte13.Value = bgsm.unkB13;
            numByte14.Value = bgsm.unkB14;
            numByte15.Value = bgsm.unkB15;
            numByte16.Value = bgsm.unkB16;
            numByte17.Value = bgsm.unkB17;
            numByte18.Value = bgsm.unkB18;

            btColor2.BackColor = Color.FromArgb(
                Convert.ToByte(bgsm.unkColor2.Red * 255.0f),
                Convert.ToByte(bgsm.unkColor2.Green * 255.0f),
                Convert.ToByte(bgsm.unkColor2.Blue * 255.0f));

            numByte19.Value = bgsm.unkB19;
            numByte20.Value = bgsm.unkB20;
            cbUseSkinColor.Checked = bgsm.useSkinColor;
            numByte21.Value = bgsm.unkB21;

            numFloat12.Value = Convert.ToDecimal(bgsm.unkF12);
            numFloat13.Value = Convert.ToDecimal(bgsm.unkF13);
            numFloat14.Value = Convert.ToDecimal(bgsm.unkF14);
            numFloat15.Value = Convert.ToDecimal(bgsm.unkF15);
            numFloat16.Value = Convert.ToDecimal(bgsm.unkF16);
            numFloat17.Value = Convert.ToDecimal(bgsm.unkF17);

            numByte22.Value = bgsm.unkB22;
        }

        private void SetMaterialFromUI(ref BGSM bgsm)
        {
            bgsm.unk1 = Convert.ToUInt32(numInt1.Value);
            bgsm.unk2 = Convert.ToUInt32(numInt2.Value);
            bgsm.unk3 = Convert.ToUInt32(numInt3.Value);
            bgsm.unk4 = Convert.ToUInt32(numInt4.Value);

            bgsm.unkF1 = Convert.ToSingle(numFloat1.Value);
            bgsm.unkF2 = Convert.ToSingle(numFloat2.Value);
            bgsm.unkF3 = Convert.ToSingle(numFloat3.Value);

            bgsm.flags1 = Convert.ToUInt32(numFlags1.Value);
            bgsm.flags2 = Convert.ToUInt32(numFlags2.Value);

            bgsm.mysteryB1 = Convert.ToByte(numMysteryByte1.Value);
            bgsm.mysteryB2 = Convert.ToByte(numMysteryByte2.Value);

            bgsm.useAlpha = cbUseAlpha.Checked;

            bgsm.mysteryB4 = Convert.ToByte(numMysteryByte4.Value);
            bgsm.mysteryB5 = Convert.ToByte(numMysteryByte5.Value);
            bgsm.mysteryB6 = Convert.ToByte(numMysteryByte6.Value);
            bgsm.mysteryB7 = Convert.ToByte(numMysteryByte7.Value);
            bgsm.mysteryB8 = Convert.ToByte(numMysteryByte8.Value);

            bgsm.useDoubleSided = cbUseDoubleSided.Checked;

            bgsm.mysteryB10 = Convert.ToByte(numMysteryByte10.Value);
            bgsm.mysteryB11 = Convert.ToByte(numMysteryByte11.Value);
            bgsm.mysteryB12 = Convert.ToByte(numMysteryByte12.Value);
            bgsm.mysteryB13 = Convert.ToByte(numMysteryByte13.Value);
            bgsm.mysteryB14 = Convert.ToByte(numMysteryByte14.Value);
            bgsm.mysteryB15 = Convert.ToByte(numMysteryByte15.Value);
            bgsm.mysteryB16 = Convert.ToByte(numMysteryByte16.Value);
            bgsm.mysteryB17 = Convert.ToByte(numMysteryByte17.Value);
            bgsm.mysteryB18 = Convert.ToByte(numMysteryByte18.Value);
            bgsm.mysteryB19 = Convert.ToByte(numMysteryByte19.Value);
            bgsm.mysteryB20 = Convert.ToByte(numMysteryByte20.Value);
            bgsm.mysteryB21 = Convert.ToByte(numMysteryByte21.Value);
            bgsm.mysteryB22 = Convert.ToByte(numMysteryByte22.Value);
            bgsm.mysteryB23 = Convert.ToByte(numMysteryByte23.Value);

            bgsm.textures[0] = tbTexture1.Text.Replace('\\', '/');
            bgsm.textures[1] = tbTexture2.Text.Replace('\\', '/');
            bgsm.textures[2] = tbTexture3.Text.Replace('\\', '/');
            bgsm.textures[3] = tbTexture4.Text.Replace('\\', '/');
            bgsm.textures[4] = tbTexture5.Text.Replace('\\', '/');
            bgsm.textures[5] = tbTexture6.Text.Replace('\\', '/');
            bgsm.textures[6] = tbTexture7.Text.Replace('\\', '/');
            bgsm.textures[7] = tbTexture8.Text.Replace('\\', '/');
            bgsm.textures[8] = tbTexture9.Text.Replace('\\', '/');

            bgsm.unkB1 = Convert.ToByte(numByte1.Value);
            bgsm.unkB2 = Convert.ToByte(numByte2.Value);

            bgsm.unkF4 = Convert.ToSingle(numFloat4.Value);
            bgsm.unkF5 = Convert.ToSingle(numFloat5.Value);

            bgsm.unkB3 = Convert.ToByte(numByte3.Value);
            bgsm.unkF6 = Convert.ToSingle(numFloat6.Value);

            bgsm.useWet = cbUseWet.Checked;

            bgsm.unkColor1.Red = btColor1.BackColor.R / 255.0f;
            bgsm.unkColor1.Green = btColor1.BackColor.G / 255.0f;
            bgsm.unkColor1.Blue = btColor1.BackColor.B / 255.0f;

            bgsm.specularStrength = Convert.ToSingle(numSpecularStrength.Value);

            bgsm.unkF7_5 = Convert.ToSingle(numFloat7_5.Value);
            bgsm.unkF7_6 = Convert.ToSingle(numFloat7_6.Value);
            bgsm.unkF7_7 = Convert.ToSingle(numFloat7_7.Value);
            bgsm.unkF7_8 = Convert.ToSingle(numFloat7_8.Value);
            bgsm.unkF7_9 = Convert.ToSingle(numFloat7_9.Value);
            bgsm.unkF7_10 = Convert.ToSingle(numFloat7_10.Value);
            bgsm.unkF7_11 = Convert.ToSingle(numFloat7_11.Value);
            bgsm.unkF7_12 = Convert.ToSingle(numFloat7_12.Value);

            bgsm.template = tbTemplate.Text;

            bgsm.unkB5 = Convert.ToByte(numByte5.Value);
            bgsm.unkB6 = Convert.ToByte(numByte6.Value);
            bgsm.unkF8 = Convert.ToSingle(numFloat8.Value);

            bgsm.unkB7 = Convert.ToByte(numByte7.Value);
            bgsm.unkB8 = Convert.ToByte(numByte8.Value);
            bgsm.unkB9 = Convert.ToByte(numByte9.Value);
            bgsm.unkB10 = Convert.ToByte(numByte10.Value);
            bgsm.unkB11 = Convert.ToByte(numByte11.Value);
            bgsm.unkB12 = Convert.ToByte(numByte12.Value);
            bgsm.unkB13 = Convert.ToByte(numByte13.Value);
            bgsm.unkB14 = Convert.ToByte(numByte14.Value);
            bgsm.unkB15 = Convert.ToByte(numByte15.Value);
            bgsm.unkB16 = Convert.ToByte(numByte16.Value);
            bgsm.unkB17 = Convert.ToByte(numByte17.Value);
            bgsm.unkB18 = Convert.ToByte(numByte18.Value);

            bgsm.unkColor2.Red = btColor2.BackColor.R / 255.0f;
            bgsm.unkColor2.Green = btColor2.BackColor.G / 255.0f;
            bgsm.unkColor2.Blue = btColor2.BackColor.B / 255.0f;

            bgsm.unkB19 = Convert.ToByte(numByte19.Value);
            bgsm.unkB20 = Convert.ToByte(numByte20.Value);
            bgsm.useSkinColor = cbUseSkinColor.Checked;
            bgsm.unkB21 = Convert.ToByte(numByte21.Value);

            bgsm.unkF12 = Convert.ToSingle(numFloat12.Value);
            bgsm.unkF13 = Convert.ToSingle(numFloat13.Value);
            bgsm.unkF14 = Convert.ToSingle(numFloat14.Value);
            bgsm.unkF15 = Convert.ToSingle(numFloat15.Value);
            bgsm.unkF16 = Convert.ToSingle(numFloat16.Value);
            bgsm.unkF17 = Convert.ToSingle(numFloat17.Value);

            bgsm.unkB22 = Convert.ToByte(numByte22.Value);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workMaterial = new BGSM();
            workFileName = string.Empty;

            saveAsToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            tableLayoutPanel.Enabled = true;

            SetUIFromMaterial(ref workMaterial);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                workMaterial = new BGSM(openFileDialog.FileName);
                workFileName = openFileDialog.FileName;

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                tableLayoutPanel.Enabled = true;
                this.Text = openFileDialog.SafeFileName;

                SetUIFromMaterial(ref workMaterial);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workMaterial != null)
            {
                SetMaterialFromUI(ref workMaterial);
                workMaterial.Save(workFileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (workMaterial != null)
                {
                    this.Text = workFileName.Remove(0, workFileName.LastIndexOf('\\') + 1);
                    saveToolStripMenuItem.Enabled = true;
                    SetMaterialFromUI(ref workMaterial);

                    workFileName = saveFileDialog.FileName;
                    workMaterial.Save(workFileName);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workMaterial = null;
            workFileName = string.Empty;

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            tableLayoutPanel.Enabled = false;
            this.Text = "Material Editor";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btColor1_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btColor1.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btColor1.BackColor = colorDialog.Color;
            }
        }

        private void btColor2_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btColor2.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btColor2.BackColor = colorDialog.Color;
            }
        }
    }
}
