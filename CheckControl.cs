using System;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class CheckControl : CustomControl
    {
        private Label lbLabel;
        private CheckBox check;

        public override Label LabelControl
        {
            get { return lbLabel; }
        }

        public override Control Control
        {
            get { return check; }
        }

        public CheckControl(string label, Action<CustomControl> changedCallback, bool initialChecked = false) : base(label)
        {
            lbLabel.Text = label;
            check.Checked = initialChecked;
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

            check = new CheckBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                CheckAlign = System.Drawing.ContentAlignment.TopLeft,
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
                Name = "check",
                TabIndex = 0,
                ForeColor = System.Drawing.Color.FromName("red"),
                Text = "Off",
                Tag = this
            };
            check.CheckedChanged += new EventHandler(Check_CheckedChanged);
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            if (check.Checked)
            {
                check.ForeColor = System.Drawing.Color.FromName("green");
                check.Text = "On";
            }
            else
            {
                check.ForeColor = System.Drawing.Color.FromName("red");
                check.Text = "Off";
            }

            RunChangedCallback();
        }

        public override object GetProperty()
        {
            return check.Checked;
        }
    }
}
