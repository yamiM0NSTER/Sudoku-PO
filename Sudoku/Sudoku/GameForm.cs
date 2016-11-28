using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Stopwatch time;

        public GameForm()
        {
            InitializeComponent();
            buttons = new SudokuBtn[9][];
            for (int i = 0; i < 9; i++)
                buttons[i] = new SudokuBtn[9];
            time = new Stopwatch();
        }

        public GameForm(MainWindowForm parent)
        {
            _mainForm = parent;
            this.MdiParent = parent;
            InitializeComponent();
            buttons = new SudokuBtn[9][];
            for (int i = 0; i < 9; i++)
                buttons[i] = new SudokuBtn[9];
            time = new Stopwatch();
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
                    btn.Parent = this;
                    btn.BackColor = System.Drawing.Color.DarkGray;
                    btn.UseVisualStyleBackColor = false;
                    btn.FlatStyle = FlatStyle.Standard;
                    //btn.FlatAppearance.BorderColor = Color.Transparent;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Location = new System.Drawing.Point(x, y);
                    btn.Size = new System.Drawing.Size(35, 35);
                    btn.TabIndex = 0;
                    btn.UseVisualStyleBackColor = false;
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
            time.Reset();
            time.Start();
            timer1.Start();
            panel1.SendToBack();
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

        internal bool CheckCorrectRelative()
        {
            String str;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int nVal = buttons[i][j].GetVal();
                    if (nVal == 0)
                        nVal = -1;
                    for (int k = 0; k < 9; k++)
                    {
                        if ((buttons[i][k].GetVal()==nVal && k!=j) ||
                            (buttons[k][j].GetVal()==nVal && k!=i))
                        {
                            return false;
                        }
                    }
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

        public string GetTime()
        {
            return time.Elapsed.Hours.ToString("00") + ":" + time.Elapsed.Minutes.ToString("00") + ":" + time.Elapsed.Seconds.ToString("00");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = GetTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckCorrectRelative())
                _mainForm.ShowDialogForm(this, "Cool!", "Everything looks fine so far.");
            else
                _mainForm.ShowDialogForm(this, "OOPS!", "Something is wrong here.");
        }

        private void GameFinishedEvent(object sender, EventArgs e)
        {
            _mainForm.SelectLevelMenu();
        }

        internal void Finished()
        {
            time.Stop();
            _mainForm.ShowDialogForm(this, "Congratulations!", "Sudoku is filled correctly!\nYour time: " + GetTime(), GameFinishedEvent);
            //throw new NotImplementedException();
        }

        internal void Wrong()
        {
            _mainForm.ShowDialogForm(this, "OOPS!", "Some fields are filled incorrectly! :/");
        }
    }
}
