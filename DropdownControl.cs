using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class DropdownControl : CustomControl
    {
        public DropdownControl(string label, Action<CustomControl> changedCallback, object[] entries, int selection)
        {
            InitializeComponent();

            lbLabel.Text = label;
            ChangedCallback = changedCallback;
            dropdown.Items.AddRange(entries);
            dropdown.SelectedIndex = selection;
        }

        private void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunChangedCallback();
        }

        public override object GetProperty()
        {
            return dropdown.SelectedIndex;
        }
    }
}
