using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinAccentHold
{
    public partial class SelectorWindow : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const int SW_SHOWNOACTIVATE = 4;

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr window, IntPtr insertAfter, int x, int y, int width, int height, uint flags);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr window);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr window, int command);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        FlowLayoutPanel buttonPanel;
        private readonly IntPtr targetWindow;

        public SelectorWindow(int x, int y)
        {
            InitializeComponent();
            targetWindow = GetForegroundWindow();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(y, 64);
            this.KeyPreview = true;
            this.BackColor = Color.White;
            this.ControlBox = false;

            buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.AutoScroll = false;
            buttonPanel.WrapContents = false;
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.Padding = new Padding(0);
            buttonPanel.BackColor = Color.White;
            buttonPanel.Visible = true;

            this.Controls.Add(buttonPanel);
            buttonPanel.BringToFront();
            this.KeyDown += SelectorWindow_KeyDown;
            this.Deactivate += delegate { Close(); };
        }

        private void SelectorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            int index = -1;
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
                index = e.KeyCode - Keys.D1;
            else if (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9)
                index = e.KeyCode - Keys.NumPad1;

            if (index >= 0 && index < buttonPanel.Controls.Count)
            {
                Button button = buttonPanel.Controls[index] as Button;
                if (button != null) button.PerformClick();
                else Close();
            }
            else
            {
                // Zero, Escape, and every non-selection key dismiss the picker.
                Close();
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            ShowWindow(Handle, SW_SHOWNOACTIVATE);
            SetForegroundWindow(Handle);
            Activate();
            PerformLayout();
            Refresh();
        }

        public void AddCharButton(int index, String character){
            Button button = new Button();

            button.Text = index + " " + character;
            button.Size = new Size(80, 40);
            button.Margin = new Padding(4);
            button.Font = new Font("Segoe UI", 10);
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
            button.Visible = true;

            button.Click += delegate(object sender, EventArgs e)
            {
                string selected = character;

                this.Close();
                if (targetWindow != IntPtr.Zero) SetForegroundWindow(targetWindow);
                SendKeys.SendWait("{BACKSPACE}");
                SendKeys.SendWait(selected);
            };

            this.buttonPanel.Controls.Add(button);
        }

        public void PopulateCharButtons(Dictionary<int, String> characters){
            foreach (KeyValuePair<int, String> entry in characters)
            {
                int key = entry.Key;
                String character = entry.Value;

                this.AddCharButton(key, character);
            }

            int width = this.Padding.Horizontal + buttonPanel.Padding.Horizontal;
            foreach (Control control in buttonPanel.Controls)
                width += control.Width + control.Margin.Horizontal;
            this.ClientSize = new Size(Math.Max(200, width), 64);
            buttonPanel.PerformLayout();
        }
    }
}
