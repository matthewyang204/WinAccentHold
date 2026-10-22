using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinAccentHold
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 MainForm = new Form1();
            MainForm.Load += (sender, e) =>
            {
                MainForm.Hide();
                MainForm.ShowInTaskbar = false;
            };
            Application.Run(MainForm);
        }
    }
}
