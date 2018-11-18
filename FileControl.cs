using System;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class FileControl : CustomControl
    {
        public enum FileType
        {
            Texture,
            Material
        }

        public FileType CurrentFileType;

        public FileControl(string label, Action<CustomControl> changedCallback, FileType fileType = FileType.Texture, string initialPath = "")
        {
            InitializeComponent();

            lbLabel.Text = label;
            ChangedCallback = changedCallback;
            CurrentFileType = fileType;
            tbFile.Text = initialPath;
        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {
            RunChangedCallback();
        }

        private void btFile_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string filePrefix = "";

            switch (CurrentFileType)
            {
                case FileType.Texture:
                    if (textureFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = textureFileDialog.FileName;
                        filePrefix = @"\textures\";
                    }
                    break;

                case FileType.Material:
                    if (materialFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = materialFileDialog.FileName;
                        filePrefix = @"\materials\";
                    }
                    break;
            }

            int index = fileName.ToLower().IndexOf(filePrefix);
            if (index >= 0 && fileName.Length - 1 > index + 10)
            {
                // Found directory
                fileName = fileName.Substring(index + 10);
            }
            else
            {
                // No directory found, using just the file name
                index = fileName.LastIndexOf('\\');
                if (index >= 0 && fileName.Length - 1 > index + 1)
                {
                    fileName = fileName.Substring(index + 1);
                }
            }

            tbFile.Text = fileName.Trim().Replace('\\', '/');
            RunChangedCallback();
        }

        public override object GetProperty()
        {
            return tbFile.Text;
        }
    }
}
