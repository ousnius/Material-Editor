using System;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class FileControl : CustomControl
    {
        private Label lbLabel;
        private TextBox tbFile;
        private Button btFile;
        private OpenFileDialog textureFileDialog;
        private OpenFileDialog materialFileDialog;

        public enum FileType
        {
            Texture,
            Material
        }

        public FileType CurrentFileType;

        public FileControl(string label, System.Drawing.Font font, Action<CustomControl> changedCallback, FileType fileType = FileType.Texture, string initialPath = "") : base(label)
        {
            lbLabel.Text = label;
            CurrentFileType = fileType;

            tbFile.Font = font;
            tbFile.Text = initialPath;
            tbFile.PlaceholderText = fileType switch
            {
                FileType.Texture => "<no texture>",
                FileType.Material => "<no material>",
                _ => "<no file>",
            };

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

            tbFile = new TextBox
            {
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                MaxLength = 260,
                Name = "tbFile",
                TabIndex = 0,
                Tag = this
            };
            tbFile.TextChanged += new EventHandler(TbFile_TextChanged);

            btFile = new Button
            {
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Name = "btFile",
                TabStop = false,
                Text = "...",
                Size = new System.Drawing.Size(35, 20),
                Tag = this
            };
            btFile.Click += new EventHandler(BtFile_Click);

            textureFileDialog = new OpenFileDialog
            {
                DefaultExt = "dds",
                Filter = "Texture File (*.dds;*.tga)|*.dds;*.tga",
                Title = "Choose a texture file..."
            };

            materialFileDialog = new OpenFileDialog
            {
                DefaultExt = "bgsm",
                Filter = "Material File (*.bgsm;*.bgem)|*.bgsm;*.bgem",
                Title = "Choose a material file..."
            };
        }

        private void TbFile_TextChanged(object sender, EventArgs e)
        {
            RunChangedCallback();
        }

        private void BtFile_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string filePrefix = "";

            switch (CurrentFileType)
            {
                case FileType.Texture:
                    if (textureFileDialog.ShowDialog() != DialogResult.OK)
                        return;

                    fileName = textureFileDialog.FileName;
                    filePrefix = @"\textures\";
                    break;

                case FileType.Material:
                    if (materialFileDialog.ShowDialog() != DialogResult.OK)
                        return;

                    fileName = materialFileDialog.FileName;
                    filePrefix = @"\materials\";
                    break;
            }

            int index = fileName.IndexOf(filePrefix, StringComparison.CurrentCultureIgnoreCase);
            if (index >= 0 && fileName.Length - 1 > index + 10)
            {
                // Found directory
                fileName = fileName[(index + 10)..];
            }
            else
            {
                // No directory found, using just the file name
                index = fileName.LastIndexOf('\\');
                if (index >= 0 && fileName.Length - 1 > index + 1)
                {
                    fileName = fileName[(index + 1)..];
                }
            }

            tbFile.Text = fileName.Trim().Replace('\\', '/');
            RunChangedCallback();
        }

        public override Label LabelControl
        {
            get { return lbLabel; }
        }

        public override Control Control
        {
            get { return tbFile; }
        }

        public override Control ExtraControl
        {
            get { return btFile; }
        }

        public override object GetProperty()
        {
            return tbFile.Text;
        }
    }
}
