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

            WKeyScore.TriggerKeyChanged += OnKeyTrigger;
            WKeyScore.Start(this);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ExitMenuButton_Click(object sender, EventArgs e)
        {
            WinAccentHold.Visible = false;
            Application.Exit();
        }

        public void OnKeyTrigger(String letter, bool pressed)
        {
            Dictionary<int, String> db = new AccentDB().mainDB[letter];
            SelectorWindow Selector = new SelectorWindow(32, 200);
            System.Drawing.Point caret;

            CaretHelper.TryGetCaretPosition(out caret);
            System.Diagnostics.Debug.WriteLine("Caret: " + caret.ToString());
            Selector.StartPosition = FormStartPosition.Manual;
            Selector.Location = new System.Drawing.Point(caret.X, caret.Y - Selector.Height);
            Selector.ShowInTaskbar = false;
            Selector.TopMost = true;
            Selector.Show();
            Selector.Activate();
        }
    }
}
