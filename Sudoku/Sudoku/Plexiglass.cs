using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sudoku
{
    class Plexiglass : Form
    {
        public Plexiglass(Form tocover)
        {
            this.BackColor = Color.DarkGray;
            this.Opacity = 0.30;      // Tweak as desired
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
            //this.Location = tocover.PointToScreen(Point.Empty);
            this.Location = new Point(0,0);
            //this.ClientSize = new Size(tocover.ClientSize.Width - 1, tocover.ClientSize.Height - 1);
            this.ClientSize = tocover.ClientSize;
            //tocover.LocationChanged += new EventHandler(Cover_LocationChanged);
            
            //tocover.LocationChanged += Cover_LocationChanged;
            //tocover.ClientSizeChanged += Cover_ClientSizeChanged;
            //this.Show(tocover);
            //tocover.Focus();
            // Disable Aero transitions, the plexiglass gets too visible
        }
        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass follows the owner
            this.Location = this.Owner.PointToScreen(Point.Empty);
        }
        private void Cover_ClientSizeChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass keeps the owner covered
            this.ClientSize = this.Owner.ClientSize;
        }

        private void Cover_Move(object sender, EventArgs e)
        {
            // Ensure the plexiglass follows the owner
            this.Location = this.Owner.PointToScreen(Point.Empty);
        }

        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
    }
}