using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NiceHashBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PoolContainer.Initialize();
            SettingsContainer.Initialize();
            OrderContainer.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            OrderContainer.Deinitialize();
        }
    }
}
