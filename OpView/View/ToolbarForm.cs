using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpView.View
{
    public class ToolbarForm : BaseForm
    {
        private IContainer components;
        protected Panel pnlTool;
        protected Panel pnlContent;
        public ToolbarForm()
        {
            this.InitializeComponent();
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
            this.pnlTool = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlTool);
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(429, 78);
            this.pnlTool.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 78);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(429, 204);
            this.pnlContent.TabIndex = 1;
            // 
            // ToolbarForm
            // 
            this.ClientSize = new System.Drawing.Size(429, 282);
            this.Name = "ToolbarForm";
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public virtual void FormShow()
        {
 
        }
    }
}
