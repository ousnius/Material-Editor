using System;
using System.Drawing;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class ColorControl : CustomControl
    {
        private Label lbLabel;
        private Button btColor;
        private ColorDialog colorDialog;

        public Color CurrentColor = Color.White;

        public override Label LabelControl
        {
            get { return lbLabel; }
        }

        public override Control Control
        {
            get { return btColor; }
        }

        public ColorControl(string label, Action<CustomControl> changedCallback, Color initialColor) : base(label)
        {
            lbLabel.Text = label;

            CurrentColor = initialColor;
            btColor.BackColor = CurrentColor;
            colorDialog.Color = CurrentColor;

            ChangedCallback = changedCallback;
        }

        public override void CreateControls()
        {
            lbLabel = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                AutoSize = true,
                Name = "lbLabel",
                Text = "Label",
                Tag = this
            };

            btColor = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Standard,
                Name = "btColor",
                TabIndex = 1,
                UseVisualStyleBackColor = false,
                Tag = this
            };
            btColor.Click += new EventHandler(btColor_Click);

            colorDialog = new ColorDialog
            {
                FullOpen = true
            };
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
