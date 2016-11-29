using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sudoku
{
    /// <summary>
    /// Class Designed to show user messages in nice way(instead of MessageBox)
    /// </summary>
    class DialogForm : Form
    {
        private Button button1;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private Form _tocover;

        public DialogForm(MainWindowForm parent)
        {
            InitializeComponent();
        }

        public void SetToCover(Form tocover)
        {
            _tocover = tocover;
            //this.Location = tocover.PointToScreen(new Point((tocover.ClientSize.Width - this.ClientSize.Width) / 2, (tocover.ClientSize.Height - this.ClientSize.Height) / 2));
            this.Location = tocover.PointToScreen(new Point((tocover.ClientSize.Width - this.ClientSize.Width)/2, (tocover.ClientSize.Height - this.ClientSize.Height)/2));
            //overlay = new Plexiglass(tocover);
            //overlay.MdiParent = this.MdiParent;

            //_tocover.MdiParent.LocationChanged += Cover_LocationChanged;
            if (linkLabel1.Text == "")
                linkLabel1.Visible = false;
        }
        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            this.Location = _tocover.PointToScreen(new Point((_tocover.ClientSize.Width - this.ClientSize.Width) / 2, (_tocover.ClientSize.Height - this.ClientSize.Height) / 2));
        }

        public void ShowIt()
        {
            //overlay.Show();
            this.Show();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Congratulations!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 110);
            this.label2.TabIndex = 2;
            this.label2.Text = "SmallText";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(17, 176);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(364, 18);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // DialogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.linkLabel1.Text = "";
            this.Hide();
        }

        internal void SetText1(string Text1)
        {
            this.label1.Text = Text1;
        }

        internal void SetText2(string Text2)
        {
            this.label2.Text = Text2;
        }

        public void AddButtonEvent(EventHandler Event)
        {
            this.button1.Click += Event;
        }

        internal void HideLink()
        {
            this.linkLabel1.Visible = false;
        }

        internal void AddLink(string text, string url)
        {
            this.linkLabel1.Text = text;
            this.linkLabel1.Links.Add(0, text.Length, url);
            this.linkLabel1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Determine which link was clicked within the LinkLabel.
            //this.linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;

            // Display the appropriate link based on the value of the 
            // LinkData property of the Link object.
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if (null != target && target.StartsWith("http"))
            {
                System.Diagnostics.Process.Start(target);
            }
        }
    }
}