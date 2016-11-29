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
    /// <summary>
    /// Class Designed to let user select difficulty of levels he/she wants to play
    /// </summary>
    public partial class LevelDifficultyForm : Form
    {
        private MainWindowForm _mainForm;
        public LevelDifficultyForm()
        {
            InitializeComponent();
        }

        public LevelDifficultyForm(MainWindowForm parent)
        {
            _mainForm = parent;
            this.MdiParent = parent;
            InitializeComponent();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

            _mainForm = MdiParent as MainWindowForm;

            int y = 175;
            foreach (LevelInfo lvlInfo in _mainForm.Getloader().GetLevelInfos())
            {
                Button btn = new Button();
                btn.Text = lvlInfo.GetName();
                btn.Parent = this;
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new System.Drawing.Point(190, y);
                btn.Size = new System.Drawing.Size(300, 80);
                btn.TabIndex = 0;
                btn.UseVisualStyleBackColor = false;
                btn.Name = lvlInfo.GetLevelNumber().ToString();
                btn.Click += new System.EventHandler(this.NewGameBtn_Click);

                btn.Show();
                y += 100;
            }

        }


        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            _mainForm.LevelSelect(int.Parse(btn.Name));
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            _mainForm.MainMenu();
        }
    }
}
