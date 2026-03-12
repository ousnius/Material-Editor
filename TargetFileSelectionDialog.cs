using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Material_Editor
{
    internal sealed class TargetFileSelectionDialog : Form
    {
        private readonly ListView targetList;
        private readonly Button addFilesButton;
        private readonly Button addFolderButton;
        private readonly Button removeButton;
        private readonly Button okButton;
        private readonly CheckBox backupCheckBox;
        private readonly HashSet<string> filePaths = new(StringComparer.OrdinalIgnoreCase);
        private readonly Label introLabel;
        private readonly Button cancelButton;

        public IReadOnlyList<string> TargetFiles => targetList.Items
            .Cast<ListViewItem>()
            .Select(item => item.Tag as string)
            .ToList();

        public bool BackupBeforeWrite => backupCheckBox.Checked;

        public TargetFileSelectionDialog(ThemePalette palette)
        {
            Text = "Select Target Files";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(600, 520);
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            introLabel = new Label
            {
                Text = "Add material (.bgsm/.bgem) files or folders to apply the selected fields to.",
                Bounds = new Rectangle(12, 12, 576, 24),
                AutoSize = false
            };
            Controls.Add(introLabel);

            targetList = new ListView
            {
                Bounds = new Rectangle(12, 42, 576, 360),
                View = View.Details,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };
            targetList.Columns.Add("Target File", 560);
            targetList.SelectedIndexChanged += (s, e) => UpdateRemoveButton();
            Controls.Add(targetList);

            addFilesButton = new Button
            {
                Text = "Add Files...",
                Bounds = new Rectangle(12, 410, 100, 28)
            };
            addFilesButton.Click += (s, e) => AddFiles();
            Controls.Add(addFilesButton);

            addFolderButton = new Button
            {
                Text = "Add Folder...",
                Bounds = new Rectangle(122, 410, 100, 28)
            };
            addFolderButton.Click += (s, e) => AddFolder();
            Controls.Add(addFolderButton);

            removeButton = new Button
            {
                Text = "Remove",
                Bounds = new Rectangle(232, 410, 100, 28),
                Enabled = false
            };
            removeButton.Click += (s, e) => RemoveSelected();
            Controls.Add(removeButton);

            backupCheckBox = new CheckBox
            {
                Text = "Create .bak backup for each overwritten file",
                Bounds = new Rectangle(12, 450, 400, 24),
                Checked = true
            };
            Controls.Add(backupCheckBox);

            okButton = new Button
            {
                Text = "OK",
                Bounds = new Rectangle(422, 460, 80, 28),
                DialogResult = DialogResult.OK,
                Enabled = false
            };
            okButton.Click += (s, e) => UpdateOkState();
            Controls.Add(okButton);

            cancelButton = new Button
            {
                Text = "Cancel",
                Bounds = new Rectangle(514, 460, 74, 28),
                DialogResult = DialogResult.Cancel
            };
            Controls.Add(cancelButton);

            AcceptButton = okButton;
            CancelButton = cancelButton;

            ApplyPalette(palette);
        }

        private void AddFiles()
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Material Files (.bgsm;.bgem)|*.bgsm;*.bgem",
                Multiselect = true,
                Title = "Select material files..."
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            AddPaths(dialog.FileNames);
        }

        private void AddFolder()
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Select a folder to scan for materials..."
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var matches = Directory.EnumerateFiles(dialog.SelectedPath, "*.*", SearchOption.AllDirectories)
                    .Where(p => p.EndsWith(".bgsm", StringComparison.OrdinalIgnoreCase) || p.EndsWith(".bgem", StringComparison.OrdinalIgnoreCase));

                AddPaths(matches);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to scan the selected folder for material files.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddPaths(IEnumerable<string> paths)
        {
            foreach (var path in paths)
            {
                try
                {
                    var fullPath = Path.GetFullPath(path);
                    if (filePaths.Add(fullPath))
                    {
                        var item = new ListViewItem(fullPath) { Tag = fullPath };
                        targetList.Items.Add(item);
                    }
                }
                catch (Exception)
                {
                    // Ignore invalid paths.
                }
            }

            UpdateOkState();
        }

        private void RemoveSelected()
        {
            foreach (ListViewItem item in targetList.SelectedItems)
            {
                filePaths.Remove(item.Tag as string);
                targetList.Items.Remove(item);
            }

            UpdateOkState();
        }

        private void UpdateRemoveButton()
        {
            removeButton.Enabled = targetList.SelectedItems.Count > 0;
        }

        private void UpdateOkState()
        {
            okButton.Enabled = targetList.Items.Count > 0;
        }

        private void ApplyPalette(ThemePalette palette)
        {
            BackColor = palette.FormBackground;
            ForeColor = palette.Foreground;

            introLabel.BackColor = palette.FormBackground;
            introLabel.ForeColor = palette.Foreground;

            targetList.BackColor = palette.PanelBackground;
            targetList.ForeColor = palette.Foreground;

            addFilesButton.BackColor = palette.ControlBackground;
            addFolderButton.BackColor = palette.ControlBackground;
            removeButton.BackColor = palette.ControlBackground;
            okButton.BackColor = palette.ControlBackground;
            cancelButton.BackColor = palette.ControlBackground;
            backupCheckBox.BackColor = palette.FormBackground;
            backupCheckBox.ForeColor = palette.Foreground;
        }
    }
}
