using MaterialLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Material_Editor
{
    internal sealed class FieldSelectionDialog : Form
    {
        private readonly ListView listView;
        private readonly Button selectAllButton;
        private readonly Button selectNoneButton;
        private readonly Button okButton;
        private readonly Label descriptionLabel;
        private readonly Label headerLabel;
        private readonly Label descriptionHeaderLabel;
        private readonly string descriptionPlaceholder = "Select a field to see a short explanation of what it controls.";

        public IReadOnlyList<MaterialFieldDescriptor> SelectedFields { get; private set; }

        public FieldSelectionDialog(IReadOnlyList<MaterialFieldDescriptor> descriptors, BaseMaterialFile baseline, BaseMaterialFile current, ThemePalette palette)
        {
            Text = "Overwrite Fields";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(560, 480);
            MinimizeBox = false;
            MaximizeBox = false;
            ShowInTaskbar = false;

            headerLabel = new Label
            {
                Text = "Choose the fields you want to copy from the current material.",
                AutoSize = false,
                Bounds = new Rectangle(12, 12, 536, 32)
            };
            Controls.Add(headerLabel);

            listView = new ListView
            {
                Bounds = new Rectangle(12, 50, 536, 280),
                CheckBoxes = true,
                FullRowSelect = true,
                View = View.Details,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };
            listView.Columns.Add("Field", 320);
            listView.Columns.Add("Category", 160);
            listView.ItemChecked += (s, e) => UpdateOkState();
            listView.SelectedIndexChanged += (s, e) => UpdateDescription();
            Controls.Add(listView);

            selectAllButton = new Button
            {
                Text = "Select All",
                Bounds = new Rectangle(12, 420, 120, 28)
            };
            selectAllButton.Click += (s, e) => SetAllChecks(true);
            Controls.Add(selectAllButton);

            selectNoneButton = new Button
            {
                Text = "Select None",
                Bounds = new Rectangle(138, 420, 120, 28)
            };
            selectNoneButton.Click += (s, e) => SetAllChecks(false);
            Controls.Add(selectNoneButton);

            descriptionHeaderLabel = new Label
            {
                Text = "Field description",
                Bounds = new Rectangle(12, 340, 536, 18)
            };
            Controls.Add(descriptionHeaderLabel);

            descriptionLabel = new Label
            {
                Bounds = new Rectangle(12, 360, 536, 58),
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Text = descriptionPlaceholder
            };
            Controls.Add(descriptionLabel);

            okButton = new Button
            {
                Text = "OK",
                Bounds = new Rectangle(382, 420, 80, 28),
                DialogResult = DialogResult.OK
            };
            okButton.Click += (s, e) => SelectFields();
            Controls.Add(okButton);

            var cancelButton = new Button
            {
                Text = "Cancel",
                Bounds = new Rectangle(474, 420, 74, 28),
                DialogResult = DialogResult.Cancel
            };
            Controls.Add(cancelButton);

            AcceptButton = okButton;
            CancelButton = cancelButton;

            PopulateList(descriptors, baseline, current);
            ApplyPalette(palette);
        }

        private void PopulateList(IReadOnlyList<MaterialFieldDescriptor> descriptors, BaseMaterialFile baseline, BaseMaterialFile current)
        {
            foreach (var descriptor in descriptors)
            {
                var item = new ListViewItem(new[] { descriptor.Label, descriptor.Category.ToString() })
                {
                    Tag = descriptor,
                    Checked = descriptor.HasChanged(baseline, current)
                };

                listView.Items.Add(item);
            }

            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = -2;
            }

            UpdateOkState();
        }

        private void SetAllChecks(bool value)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = value;
            }

            UpdateOkState();
        }

        private void UpdateOkState()
        {
            okButton.Enabled = listView.CheckedItems.Count > 0;
        }

        private void UpdateDescription()
        {
            if (listView.SelectedItems.Count > 0)
            {
                var descriptor = listView.SelectedItems[0].Tag as MaterialFieldDescriptor;
                descriptionLabel.Text = ControlFactory.GetTooltip(descriptor.Label) ?? descriptionPlaceholder;
            }
            else
            {
                descriptionLabel.Text = descriptionPlaceholder;
            }
        }

        private void SelectFields()
        {
            SelectedFields = listView.CheckedItems
                .Cast<ListViewItem>()
                .Select(item => item.Tag as MaterialFieldDescriptor)
                .ToList();
        }

        private void ApplyPalette(ThemePalette palette)
        {
            BackColor = palette.FormBackground;
            ForeColor = palette.Foreground;

            headerLabel.BackColor = palette.FormBackground;
            headerLabel.ForeColor = palette.Foreground;

            descriptionHeaderLabel.BackColor = palette.FormBackground;
            descriptionHeaderLabel.ForeColor = palette.Foreground;

            descriptionLabel.BackColor = palette.PanelBackground;
            descriptionLabel.ForeColor = palette.Foreground;

            listView.BackColor = palette.PanelBackground;
            listView.ForeColor = palette.Foreground;
            listView.GridLines = false;
            listView.HideSelection = false;

            selectAllButton.BackColor = palette.ControlBackground;
            selectNoneButton.BackColor = palette.ControlBackground;
            okButton.BackColor = palette.ControlBackground;
            descriptionLabel.ForeColor = palette.Foreground;
        }
    }
}
