using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class FlagControl : CustomControl
    {
        public FlagControl(string label, Action<CustomControl> changedCallback, object[] entries, int flagValue)
        {
            InitializeComponent();

            lbLabel.Text = label;
            checkedList.Items.AddRange(entries);

            for (int i = 0; i < checkedList.Items.Count; i++)
            {
                if ((flagValue & (1 << i)) != 0)
                {
                    checkedList.SetItemChecked(i, true);
                }
            }

            ChangedCallback = changedCallback;
        }

        public override object GetProperty()
        {
            int flagValue = 0;

            for (int i = 0; i < checkedList.Items.Count; i++)
            {
                if (checkedList.GetItemChecked(i))
                {
                    flagValue |= 1 << i;
                }
            }

            return flagValue;
        }

        private void checkedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunChangedCallback();
        }
    }
}
