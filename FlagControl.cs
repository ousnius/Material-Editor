using System;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class FlagControl : CustomControl
    {
        private Label lbLabel;
        private CheckedListBox checkedList;

        public FlagControl(string label, Func<CustomControl, bool> visibilityCallback, Action<CustomControl> changedCallback, object[] entries, int flagValue) : base(label)
        {
            lbLabel.Text = label;
            checkedList.Items.AddRange(entries);

            for (int i = 0; i < checkedList.Items.Count; i++)
            {
                if ((flagValue & (1 << i)) != 0)
                {
                    checkedList.SetItemChecked(i, true);
                }
            }

            VisibilityCallback = visibilityCallback;
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

            checkedList = new CheckedListBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                ColumnWidth = 150,
                FormattingEnabled = true,
                MultiColumn = true,
                Name = "checkedList",
                TabIndex = 1,
                Tag = this
            };
            checkedList.SelectedIndexChanged += new EventHandler(CheckedList_SelectedIndexChanged);
        }

        public override Label LabelControl
        {
            get { return lbLabel; }
        }

        public override Control Control
        {
            get { return checkedList; }
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

        private void CheckedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeChangedCallback();
        }
    }
}
