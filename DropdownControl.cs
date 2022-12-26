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
            dropdown.Items.AddRange(entries);
            dropdown.SelectedIndex = selection;
            ChangedCallback = changedCallback;
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
