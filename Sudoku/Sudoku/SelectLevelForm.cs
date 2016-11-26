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
    public partial class SelectLevelForm : Form
    {
        private MainWindowForm _mainForm;
        private int nDifficulty;
        private List<Button> buttons; 
        public SelectLevelForm()
        {
            InitializeComponent();
            buttons = new List<Button>();
        }

        public SelectLevelForm(MainWindowForm parent)
        {
            _mainForm = parent;
            this.MdiParent = parent;
            InitializeComponent();
            buttons = new List<Button>();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

            _mainForm = MdiParent as MainWindowForm;

            //int y = 175;
            //foreach (LevelInfo lvlInfo in _mainForm.loader._lstLevelInfos)
            //{
            //    Button btn = new Button();
            //    btn.Text = lvlInfo.name;
            //    btn.Size = new Size(300,80);
            //    btn.Location = new Point(190, y);
            //    btn.Parent = this;

            //    btn.BackColor = System.Drawing.Color.Transparent;
            //    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    btn.Location = new System.Drawing.Point(190, y);
            //    btn.Size = new System.Drawing.Size(300, 80);
            //    btn.TabIndex = 0;
            //    btn.UseVisualStyleBackColor = false;
            //    btn.Name = lvlInfo.LevelNumber.ToString();
            //    btn.Click += new System.EventHandler(this.NewGameBtn_Click);

            //    btn.Show();
            //    y += 130;
            //}

        }

        private void ChildForm_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            _mainForm.LevelSelect(int.Parse(btn.Name));
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            _mainForm.LevelDifficultyMenu();
        }

        public void PrepareLevels(int nDifficulty)
        {
            // Remove all buttons for previous difficulty choice
            foreach (Button butt in buttons)
                butt.Dispose();
            buttons.Clear();
            
            this.nDifficulty = nDifficulty;
            LevelInfo lvlInfo = null;
            foreach (LevelInfo info in _mainForm.loader._lstLevelInfos)
            {
                if (info.LevelNumber == nDifficulty)
                    lvlInfo = info;
            }

            int y = 175;
            int x = 150;
            for(int i=0;i<lvlInfo._lstLevels.Count;i++)
            {
                Button btn = new Button();
                btn.Text = (i+1).ToString();
                btn.Parent = this;
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new System.Drawing.Point(x, y);
                btn.Size = new System.Drawing.Size(80, 80);
                btn.TabIndex = 0;
                btn.UseVisualStyleBackColor = false;
                btn.Name = (i + 1).ToString();
                btn.Click += new System.EventHandler(this.StartGameBtn_Click);

                btn.Show();
                buttons.Add(btn);

                x += 100;
                if (x >= 550)
                {
                    x = 150;
                    y += 100;
                }
            }
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            _mainForm.StartGame(nDifficulty, int.Parse(btn.Name));
        }
    }
}
