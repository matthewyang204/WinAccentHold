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
        FlowLayoutPanel buttonPanel;

        public SelectorWindow(int x, int y)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(y, x);

            buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.AutoScroll = true;
            buttonPanel.WrapContents = true;
            buttonPanel.Padding = new Padding(5);

            this.Controls.Add(buttonPanel);
        }

        public void AddCharButton(int index, String character){
            Button button = new Button();

            button.Text = index + "\n" + character;
            button.Size = new Size(50, 40);
            button.Margin = new Padding(4);
            button.Font = new Font("Segoe UI", 14);

            button.Click += delegate(object sender, EventArgs e)
            {
                string selected = character;

                this.Close();

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
        }
    }
}
