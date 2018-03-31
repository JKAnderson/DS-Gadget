using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings settings = Properties.Settings.Default;
            if (settings.UpgradeRequired)
            {
                settings.Upgrade();
                settings.UpgradeRequired = false;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            settings.Save();
        }
    }
}
