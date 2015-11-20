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

        public Main()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                workMaterial = new BGSM();
                workMaterial.Open(openFileDialog.FileName);

                saveToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                this.Text = openFileDialog.SafeFileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (workMaterial != null)
                {
                    workMaterial.Save(saveFileDialog.FileName);
                }
                this.Text = openFileDialog.SafeFileName;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workMaterial = null;

            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            this.Text = "Material Editor";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
