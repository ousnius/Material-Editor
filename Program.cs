using System;
using System.Windows.Forms;

namespace Material_Editor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                ApplicationConfiguration.Initialize();
                var config = Material_Editor.Main.LoadConfig();
                if (config.Font != null)
                    Application.SetDefaultFont(config.Font);
                Application.Run(new Material_Editor.Main(config));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unhandled startup exception:{Environment.NewLine}{ex}", "Startup Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
