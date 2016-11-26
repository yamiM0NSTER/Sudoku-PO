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
    public partial class GameForm : Form
    {
        private MainWindowForm _mainForm;
        private int nDifficulty;
        private SudokuBtn[][] buttons;
        
        public GameForm()
        {
            InitializeComponent();
            buttons = new SudokuBtn[9][];
            for (int i = 0; i < 9; i++)
                buttons[i] = new SudokuBtn[9];
        }

        public GameForm(MainWindowForm parent)
        {
            _mainForm = parent;
            this.MdiParent = parent;
            InitializeComponent();
            buttons = new SudokuBtn[9][];
            for (int i = 0; i < 9; i++)
                buttons[i] = new SudokuBtn[9];
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            _mainForm = MdiParent as MainWindowForm;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            _mainForm.SelectLevelMenu();
        }

        public void PrepareLevel(Level lvl)
        {
            int y = 20;
            int x = 160;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Remove all buttons for previous level choice
                    if(buttons[i][j] != null)
                        buttons[i][j].Dispose();
                    SudokuBtn btn = new SudokuBtn();
                    if(lvl.board[i][j] != 0)
                        btn.Text = lvl.board[i][j].ToString();
                    btn.Parent = this;
                    btn.BackColor = System.Drawing.Color.Transparent;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Location = new System.Drawing.Point(x, y);
                    btn.Size = new System.Drawing.Size(35, 35);
                    btn.TabIndex = 0;
                    btn.UseVisualStyleBackColor = false;
                    btn.Name = (i + 1).ToString();
                    btn.Click += new System.EventHandler(this.StartGameBtn_Click);
                    //btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sudoku_UpdateValue);
                    btn.SetValue(lvl.board[i][j], true);

                    btn.Show();
                    buttons[i][j] = btn;

                    if ((j + 1)%3 == 0)
                        x += 5;
                    x += 37;
                }
                x = 160;
                if ((i + 1) % 3 == 0)
                    y += 5;
                y += 37;
            }
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //_mainForm.StartGame(nDifficulty, int.Parse(btn.Name));
        }

        internal bool CheckFinished()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttons[i][j].GetVal() == 0)
                        return false;
                }
            }
            return true;
        }

        internal bool CheckCorrect()
        {
            // Horizontal Rows
            for (int nRow = 0; nRow < 9; nRow++)
            {
                for (int nVal = 1; nVal <= 9; nVal++)
                {
                    if (CheckRowHorizontal(nRow, nVal) == false)
                        return false;
                }
            }

            // Vertical Rows
            for (int nRow = 0; nRow < 9; nRow++)
            {
                for (int nVal = 1; nVal <= 9; nVal++)
                {
                    if (CheckRowVertical(nRow, nVal) == false)
                        return false;
                }
            }

            // 3x3 Squares
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int nVal = 1; nVal <= 9; nVal++)
                    {
                        if (CheckSquare(i, j, nVal) == false)
                            return false;
                    }
                }
            }

            return true;
        }

        private bool CheckRowHorizontal(int nRow, int nVal)
        {
            for (int i = 0; i < 9; i++)
            {
                if (buttons[nRow][i].GetVal() == nVal)
                    return true;
            }
            return false;
        }

        private bool CheckRowVertical(int nRow, int nVal)
        {
            for (int i = 0; i < 9; i++)
            {
                if (buttons[i][nRow].GetVal() == nVal)
                    return true;
            }
            return false;
        }

        private bool CheckSquare(int nRow, int nColumn, int nVal)
        {
            for (int i = nRow*3; i < nRow*3 + 3; i++)
            {
                for (int j = nColumn*3; j < nColumn*3 + 3; j++)
                {
                    if (buttons[i][j].GetVal() == nVal)
                        return true;
                }
            }

            return false;
        }
    }
}
