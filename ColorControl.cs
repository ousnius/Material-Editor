using System;
using System.Drawing;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class ColorControl : CustomControl
    {
        public Color CurrentColor = Color.White;

        public ColorControl(string label, Action<CustomControl> changedCallback, Color initialColor)
        {
            InitializeComponent();

            lbLabel.Text = label;

            CurrentColor = initialColor;
            btColor.BackColor = CurrentColor;
            colorDialog.Color = CurrentColor;

            ChangedCallback = changedCallback;
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            var btColor = sender as Button;
            colorDialog.Color = CurrentColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentColor = colorDialog.Color;
                btColor.BackColor = CurrentColor;
                RunChangedCallback();
            }
        }

        public override object GetProperty()
        {
            return btColor.BackColor;
        }
    }
}
