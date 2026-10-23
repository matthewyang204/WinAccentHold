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
        private SelectorWindow selector;
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
            if (!pressed) return;
            Dictionary<int, String> db = new AccentDB().mainDB[letter];
            if (selector != null) selector.Close();
            selector = new SelectorWindow(32, 200);
            System.Drawing.Point caret;

            CaretHelper.TryGetCaretPosition(out caret);
            System.Diagnostics.Debug.WriteLine("Caret: " + caret.ToString());
            selector.StartPosition = FormStartPosition.Manual;
            selector.ShowInTaskbar = false;
            selector.TopMost = true;
            selector.PopulateCharButtons(db);
            selector.Location = new System.Drawing.Point(caret.X, Math.Max(0, caret.Y - selector.Height));
            selector.CreateControl();
            selector.Show();
            selector.Update();
            selector.BringToFront();
            selector.Activate();
        }
    }
}
