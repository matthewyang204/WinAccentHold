namespace WinAccentHold
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WinAccentHold = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AboutMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WinAccentHold
            // 
            this.WinAccentHold.ContextMenuStrip = this.contextMenuStrip1;
            this.WinAccentHold.Icon = ((System.Drawing.Icon)(resources.GetObject("WinAccentHold.Icon")));
            this.WinAccentHold.Text = "trayIcon";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuButton,
            this.ExitMenuButton});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 72);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // AboutMenuButton
            // 
            this.AboutMenuButton.Name = "AboutMenuButton";
            this.AboutMenuButton.Size = new System.Drawing.Size(143, 34);
            this.AboutMenuButton.Text = "About";
            this.AboutMenuButton.Click += new System.EventHandler(this.AboutMenuButton_Click);
            // 
            // ExitMenuButton
            // 
            this.ExitMenuButton.Name = "ExitMenuButton";
            this.ExitMenuButton.Size = new System.Drawing.Size(143, 34);
            this.ExitMenuButton.Text = "Exit";
            this.ExitMenuButton.Click += new System.EventHandler(this.ExitMenuButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 220);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon WinAccentHold;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuButton;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuButton;
    }
}

