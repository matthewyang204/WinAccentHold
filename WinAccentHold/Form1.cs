using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinAccentHold
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            WinAccentHold.Visible = true;
            WinAccentHold.Text = "WinAccentHold";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ExitMenuButton_Click(object sender, EventArgs e)
        {
            WinAccentHold.Visible = false;
            Application.Exit();
        }
    }
}
