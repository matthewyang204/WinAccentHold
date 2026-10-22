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
    public partial class SelectorWindow : Form
    {
        public SelectorWindow(int x, int y)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(y, x);
        }
    }
}
