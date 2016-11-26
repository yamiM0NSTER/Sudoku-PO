using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sudoku
{
    class DialogForm : Form
    {
        private Plexiglass overlay;
        public DialogForm(Form tocover)
        {
            overlay = new Plexiglass(tocover);

            int nWidth  = 400;
            int nHeight = 300;

            

            this.BackColor = Color.DarkGray;
            //this.Opacity = 0.30;      // Tweak as desired
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Location = tocover.PointToScreen(new Point((tocover.ClientSize.Width - nWidth) / 2, (tocover.ClientSize.Height - nHeight) / 2));
            this.ClientSize = new Size(nWidth,nHeight);
            tocover.LocationChanged += Cover_LocationChanged;
            this.Show(tocover);
            tocover.Focus();
            // Disable Aero transitions, the plexiglass gets too visible
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
        }
        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass follows the owner
            this.Location = this.Owner.PointToScreen(Point.Empty);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore owner
            this.Owner.LocationChanged -= Cover_LocationChanged;
            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing(e);
        }
        protected override void OnActivated(EventArgs e)
        {
            // Always keep the owner activated instead
            this.BeginInvoke(new Action(() => this.Owner.Activate()));
        }
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
    }
}