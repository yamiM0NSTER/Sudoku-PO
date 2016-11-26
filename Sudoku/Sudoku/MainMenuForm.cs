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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        public MainMenuForm(MainWindowForm parent)
        {
            this.MdiParent = parent;
            InitializeComponent();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

        }

        private void ChildForm_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            MainWindowForm form = MdiParent as MainWindowForm;
            form.LevelDifficultyMenu();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
