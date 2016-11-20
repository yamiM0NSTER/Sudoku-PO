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

            mainmenuform = new MainMenuForm();
            mainmenuform.MdiParent = this;
            leveldifficultyform = new LevelDifficultyForm();
            leveldifficultyform.MdiParent = this;

            MainMenu();
        }

        public void LevelDifficulty()
        {
            leveldifficultyform.Show();
            mainmenuform.Hide();
        }

        public void MainMenu()
        {
            mainmenuform.Show();
            leveldifficultyform.Hide();
        }
    }
}
