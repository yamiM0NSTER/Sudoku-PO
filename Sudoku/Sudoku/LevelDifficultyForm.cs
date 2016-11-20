using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class LevelDifficultyForm : Form
    {
        public LevelDifficultyForm()
        {
            InitializeComponent();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

            MainWindowForm form = MdiParent as MainWindowForm;

            int y = 175;
            foreach (LevelInfo lvlInfo in form.loader._lstLevelInfos)
            {
                

                Button btn = new Button();
                btn.Text = lvlInfo.name;
                btn.Size = new Size(300,80);
                btn.Location = new Point(190, y);
                btn.Parent = this;

                btn.BackColor = System.Drawing.Color.Transparent;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new System.Drawing.Point(190, y);
                btn.Size = new System.Drawing.Size(300, 80);
                btn.TabIndex = 0;
                btn.UseVisualStyleBackColor = false;
                btn.Name = lvlInfo.LevelNumber.ToString();
                MessageBox.Show(btn.Name);
                btn.Click += new System.EventHandler(this.NewGameBtn_Click);

                btn.Show();
                y += 130;
            }

        }

        private void ChildForm_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            MainWindowForm form = MdiParent as MainWindowForm;
            form.MainMenu();
        }
    }
}
