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
        private SelectLevelForm levelselectform;
        private GameForm gameform;
        private DialogForm dialog;
        public LevelLoader loader;

        public MainWindowForm()
        {
            InitializeComponent();

            loader = new LevelLoader();
            mainmenuform = new MainMenuForm();
            leveldifficultyform = new LevelDifficultyForm();
            levelselectform = new SelectLevelForm(this);
            gameform = new GameForm(this);
            dialog = new DialogForm(this);

            mainmenuform.MdiParent = this;
            leveldifficultyform.MdiParent = this;
            levelselectform.MdiParent = this;
            gameform.MdiParent = this;
            //dialog.MdiParent = this;

            loader.LoadLevelInfo();
            MainMenu();
        }

        
        public void MainMenu()
        {
            mainmenuform.Show();

            leveldifficultyform.Hide();
            levelselectform.Hide();
            gameform.Hide();
        }

        public void LevelDifficultyMenu()
        {
            leveldifficultyform.Show();

            mainmenuform.Hide();
            levelselectform.Hide();
            gameform.Hide();
        }

        public void SelectLevelMenu()
        {
            levelselectform.Show();

            leveldifficultyform.Hide();
            mainmenuform.Hide();
            gameform.Hide();
        }

        public void GameMenu()
        {
            gameform.Show();

            levelselectform.Hide();
            leveldifficultyform.Hide();
            mainmenuform.Hide();
        }

        public void ShowDialogForm(Form tocover, String Text1 = null, String Text2 = null, EventHandler handle = null)
        {
            if (Text1 != null)
                dialog.SetText1(Text1);
            if (Text2 != null)
                dialog.SetText2(Text2);
            if (handle != null)
                dialog.button1.Click += handle;
            dialog.SetToCover(tocover);
            dialog.ShowDialog();
        }

        public void LevelSelect(int nDifficulty)
        {
            levelselectform.PrepareLevels(nDifficulty);
            SelectLevelMenu();
        }

        public void StartGame(int nDifficulty, int nLevel)
        {
            //MessageBox.Show(nDifficulty + " " + nLevel);
            // Level -1 cause list index starts from 0 not 1
            gameform.PrepareLevel(loader._lstLevelInfos[nDifficulty]._lstLevels[nLevel-1]);

            GameMenu();
        }
    }
}
