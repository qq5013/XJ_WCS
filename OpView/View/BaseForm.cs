using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpView.View
{
    public class BaseForm : Form
    {
        private IContainer components;
        public Panel pnlMain;
        public MainFrame mainFrame;
        private bool inTask;
        public bool InTask
        {
            get
            {
                return this.inTask;
            }
            set
            {
                this.inTask = value;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            base.SuspendLayout();
            this.pnlMain.BackColor = SystemColors.Control;
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(429, 282);
            this.pnlMain.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);

            base.ClientSize = new Size(429, 282);
            base.Controls.Add(this.pnlMain);
            base.Name = "BaseForm";
            this.Text = "BaseForm";
            base.ResumeLayout(false);
        }
        public BaseForm()
        {
            this.InitializeComponent();
        }
        public void SetMainFrame(MainFrame mainFrame)
        {
            this.mainFrame = mainFrame;
        }
        protected void Exit()
        {
            if (this.mainFrame != null)
            {
                this.mainFrame.CloseCurrentForm();
            }
        }
    }
}
