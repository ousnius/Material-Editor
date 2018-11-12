using System;
using System.Drawing;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class ColorControl : CustomControl
    {
        public ColorControl(string label, Action<CustomControl> changedCallback, Color initialColor)
        {
            InitializeComponent();

            lbLabel.Text = label;
            ChangedCallback = changedCallback;
            btColor.BackColor = initialColor;
            colorDialog.Color = initialColor;
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            var btColor = sender as Button;
            colorDialog.Color = btColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btColor.BackColor = colorDialog.Color;
                RunChangedCallback();
            }
        }

        public override object GetProperty()
        {
            return btColor.BackColor;
        }
    }
}
