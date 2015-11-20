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
        }

        private void SetUIFromMaterial(ref BGSM bgsm)
        {
            btColor1.BackColor = Color.FromArgb(
                Convert.ToByte(bgsm.unkColor1.Red * 255.0f),
                Convert.ToByte(bgsm.unkColor1.Green * 255.0f),
                Convert.ToByte(bgsm.unkColor1.Blue * 255.0f));

            btColor2.BackColor = Color.FromArgb(
                Convert.ToByte(bgsm.unkColor2.Red * 255.0f),
                Convert.ToByte(bgsm.unkColor2.Green * 255.0f),
                Convert.ToByte(bgsm.unkColor2.Blue * 255.0f));

            numSpecularStrength.Value = Convert.ToDecimal(bgsm.specularStrength);
        }

        private void SetMaterialFromUI(ref BGSM bgsm)
        {
            bgsm.unkColor1.Red = btColor1.BackColor.R / 255.0f;
            bgsm.unkColor1.Green = btColor1.BackColor.G / 255.0f;
            bgsm.unkColor1.Blue = btColor1.BackColor.B / 255.0f;

            bgsm.unkColor2.Red = btColor2.BackColor.R / 255.0f;
            bgsm.unkColor2.Green = btColor2.BackColor.G / 255.0f;
            bgsm.unkColor2.Blue = btColor2.BackColor.B / 255.0f;

            bgsm.specularStrength = Convert.ToSingle(numSpecularStrength.Value);
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
