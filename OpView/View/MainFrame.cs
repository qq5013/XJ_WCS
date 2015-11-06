using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPanderControl;
using MCP;

namespace OpView.View
{
    public class MainFrame : Form
    {
        private IContainer components;
        private Panel pnlTop;
        private Panel pnlLeft;
        private XPanderList xPanderList;
        private Splitter splitter;
        private Panel pnlMain;
        private Panel pnlClient;
        private Panel pnlTitle;
        protected Label lblCaption;
        private FormCollection formCollection = new FormCollection();
        private BaseForm currentForm;
        private Context context;
        public Context Context
        {
            get
            {
                return this.context;
            }
            set
            {
                this.context = value;
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainFrame));
            this.pnlTop = new Panel();
            this.pnlLeft = new Panel();
            this.xPanderList = new XPanderList();
            this.splitter = new Splitter();
            this.pnlMain = new Panel();
            this.pnlClient = new Panel();
            this.pnlTitle = new Panel();
            this.lblCaption = new Label();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            base.SuspendLayout();
            this.pnlTop.BackgroundImageLayout = ImageLayout.Stretch;
            this.pnlTop.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(902, 73);
            this.pnlTop.TabIndex = 0;
            this.pnlLeft.Controls.Add(this.xPanderList);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 73);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new Size(200, 499);
            this.pnlLeft.TabIndex = 1;
            this.xPanderList.AutoScroll = true;
            this.xPanderList.BackColor = Color.FromArgb(99, 117, 222);
            this.xPanderList.Dock = DockStyle.Fill;
            this.xPanderList.Location = new Point(0, 0);
            this.xPanderList.Name = "xPanderList";
            this.xPanderList.Size = new Size(200, 499);
            this.xPanderList.TabIndex = 0;
            this.splitter.BackColor = SystemColors.Info;
            this.splitter.Location = new Point(200, 73);
            this.splitter.Name = "splitter";
            this.splitter.Size = new Size(3, 499);
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.pnlMain.Controls.Add(this.pnlClient);
            this.pnlMain.Controls.Add(this.pnlTitle);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(203, 73);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(699, 499);
            this.pnlMain.TabIndex = 3;
            this.pnlClient.BackColor = SystemColors.AppWorkspace;
            this.pnlClient.BackgroundImageLayout = ImageLayout.Stretch;
            this.pnlClient.Dock = DockStyle.Fill;
            this.pnlClient.Location = new Point(0, 25);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new Size(699, 474);
            this.pnlClient.TabIndex = 1;
            //this.pnlTitle.BackgroundImage = (Image)componentResourceManager.GetObject("pnlTitle.BackgroundImage");
            this.pnlTitle.Controls.Add(this.lblCaption);
            this.pnlTitle.Dock = DockStyle.Top;
            this.pnlTitle.Location = new Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new Size(699, 25);
            this.pnlTitle.TabIndex = 0;
            this.lblCaption.AutoSize = true;
            this.lblCaption.BackColor = Color.Transparent;
            this.lblCaption.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.lblCaption.Location = new Point(7, 7);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new Size(33, 12);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "    ";
            base.AutoScaleDimensions = new SizeF(6f, 12f);

            base.ClientSize = new Size(902, 572);
            base.Controls.Add(this.pnlMain);
            base.Controls.Add(this.splitter);
            base.Controls.Add(this.pnlLeft);
            base.Controls.Add(this.pnlTop);
            base.Name = "MainFrame";
            base.StartPosition = FormStartPosition.CenterScreen;
            
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            base.ResumeLayout(false);
        }
        public MainFrame(Config config)
        {
            this.InitializeComponent();
            this.pnlTop.BackgroundImage = this.LoadImage("Image\\banner.jpg");
            this.InitializeMenu(config);
        }
        private void InitializeMenu(Config config)
        {
            this.pnlTop.Visible = config.TitleVisible;
            base.MinimizeBox = config.MinBox;
            base.MaximizeBox = config.MaxBox;
            this.pnlLeft.Width = config.MenuWidth;
            Image image = this.LoadImage("image\\indicator.png");
            this.Text = config.Title;
            foreach (MenuList current in config.MenuList)
            {
                XPander xPander = new XPander();
                xPander.BackColor = Color.Transparent;
                xPander.CaptionText = current.Name;
                xPander.Dock = DockStyle.Top;
                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.Dock = DockStyle.Top;
                tableLayoutPanel.ColumnCount = 1;
                tableLayoutPanel.RowCount = current.Menus.Count;
                tableLayoutPanel.Height = tableLayoutPanel.RowCount * config.ItemHeight;
                if (config.ItemHeight > 30)
                {
                    tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                }
                xPander.Height = tableLayoutPanel.Height + 26;
                xPander.Controls.Add(tableLayoutPanel);
                for (int i = 0; i < current.Menus.Count; i++)
                {
                    Menu menu = current.Menus[i];
                    Control control = this.GeneratelinkLabel(menu.Name, image);
                    control.Name = current.Name + ">>" + menu.Name;
                    control.Click += new EventHandler(this.menu_Click);
                    control.Dock = DockStyle.Fill;
                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)config.ItemHeight));
                    tableLayoutPanel.Controls.Add(control, 0, i);
                    this.formCollection.Add(control.Name, menu);
                }
                this.xPanderList.Controls.Add(xPander);
            }
        }
        private Control GeneratelinkLabel(string menuName, Image image)
        {
            return new LinkLabel
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Text = menuName,
                ImageAlign = ContentAlignment.MiddleLeft,
                Image = image,
                Dock = DockStyle.Top,
                Padding = new Padding(23, 0, 0, 0),
                LinkBehavior = LinkBehavior.HoverUnderline
            };
        }
        private void menu_Click(object sender, EventArgs e)
        {
            string name = ((Control)sender).Name;
            if (this.lblCaption.Text != name)
            {
                if (this.currentForm != null)
                {
                    if (this.currentForm.InTask)
                    {
                        MessageBox.Show("正在进行操作，请先取消当前模块所有操作再切换到其他功能模块。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    this.currentForm.pnlMain.Parent = null;
                    this.currentForm.Close();
                    this.currentForm = null;
                }
                this.lblCaption.Text = name;
                this.currentForm = this.formCollection.GetForm(name);
                if (this.currentForm != null)
                {
                    this.currentForm.SetMainFrame(this);
                    this.currentForm.pnlMain.Parent = this.pnlClient;
                    ((ToolbarForm)this.currentForm).FormShow();
                }
            }
        }
        public void CloseCurrentForm()
        {
            if (this.currentForm != null)
            {
                if (this.currentForm.InTask)
                {
                    MessageBox.Show("正在进行操作，请先取消当前模块所有操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.currentForm.pnlMain.Parent = null;
                this.currentForm.Close();
                this.currentForm = null;
                this.lblCaption.Text = "";
            }
        }
        private Image LoadImage(string fileName)
        {
            Image result = null;
            try
            {
                result = new Bitmap(fileName);
            }
            catch
            {
                MessageBox.Show("程序出错，原因：无法找到" + fileName + "文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return result;
        }
    }
}
