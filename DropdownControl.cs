using System;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class DropdownControl : CustomControl
    {
        private Label lbLabel;
        private ComboBox dropdown;

        public DropdownControl(string label, Action<CustomControl> changedCallback, object[] entries, int selection) : base(label)
        {
            lbLabel.Text = label;
            dropdown.Items.AddRange(entries);
            dropdown.SelectedIndex = selection;
            ChangedCallback = changedCallback;
        }

        public override void CreateControls()
        {
            lbLabel = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                AutoSize = true,
                Name = "lbLabel",
                TabIndex = 0,
                Text = "Label",
                Tag = this
            };

            dropdown = new ComboBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FormattingEnabled = true,
                Name = "dropdown",
                TabIndex = 1,
                Tag = this
            };
            dropdown.SelectedIndexChanged += new EventHandler(Dropdown_SelectedIndexChanged);
        }

        private void Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunChangedCallback();
        }

        public override Label LabelControl
        {
            get { return lbLabel; }
        }

        public override Control Control
        {
            get { return dropdown; }
        }

        public override object GetProperty()
        {
            return dropdown.SelectedIndex;
        }
    }
}
