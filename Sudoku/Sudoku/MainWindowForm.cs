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
    public partial class MainWindowForm : Form
    {
        private MainMenuForm mainmenuform;
        private LevelDifficultyForm leveldifficultyform;

        public MainWindowForm()
        {
            InitializeComponent();

            MainMenuForm formB = new MainMenuForm();
            formB.MdiParent = this;
            formB.Show();

            //ChildForm formC = new ChildForm();
            //formC.MdiParent = this;
            //formC.Show();
        }

        public void LevelDifficulty()
        {
            LevelDifficultyForm formB = new LevelDifficultyForm();
            formB.MdiParent = this;
            formB.Show();
        }
    }
}
