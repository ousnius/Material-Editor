using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Material_Editor
{
    internal sealed class OverwriteSummaryDialog : Form
    {
        private readonly ListView listView;
        private readonly Label summaryLabel;
        private readonly Button okButton;

        public OverwriteSummaryDialog(IReadOnlyList<FieldCopyResult> results, ThemePalette palette)
        {
            Text = "Overwrite Summary";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(660, 520);
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            var listView = new ListView
            {
                Bounds = new Rectangle(12, 12, 636, 420),
                View = View.Details,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };
            listView.Columns.Add("Status", 120);
            listView.Columns.Add("File", 360);
            listView.Columns.Add("Details", 140);
            listView.BorderStyle = BorderStyle.FixedSingle;

            foreach (var result in results)
            {
                var item = new ListViewItem(result.Status.ToString())
                {
                    ForeColor = result.Status switch
                    {
                        FieldCopyStatus.Success => Color.Green,
                        FieldCopyStatus.Skipped => Color.DarkOrange,
                        FieldCopyStatus.Failed => Color.Red,
                        _ => Color.Black,
                    }
                };
                item.SubItems.Add(result.TargetPath);
                item.SubItems.Add(result.Message);
                listView.Items.Add(item);
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Controls.Add(listView);

            summaryLabel = new Label
            {
                Bounds = new Rectangle(12, 440, 636, 28),
                Text = $"{results.Count(r => r.Status == FieldCopyStatus.Success)} succeeded, {results.Count(r => r.Status == FieldCopyStatus.Skipped)} skipped, {results.Count(r => r.Status == FieldCopyStatus.Failed)} failed."
            };
            Controls.Add(summaryLabel);

            var okButton = new Button
            {
                Text = "Close",
                Bounds = new Rectangle(558, 470, 90, 30),
                DialogResult = DialogResult.OK
            };
            Controls.Add(okButton);

            AcceptButton = okButton;

            this.listView = listView;
            this.okButton = okButton;

            ApplyPalette(palette);
        }

        private void ApplyPalette(ThemePalette palette)
        {
            BackColor = palette.FormBackground;
            ForeColor = palette.Foreground;

            listView.BackColor = palette.PanelBackground;
            listView.ForeColor = palette.Foreground;
            listView.GridLines = false;

            summaryLabel.BackColor = palette.FormBackground;
            summaryLabel.ForeColor = palette.Foreground;

            okButton.BackColor = palette.ControlBackground;
            okButton.ForeColor = palette.Foreground;
        }
    }
}
