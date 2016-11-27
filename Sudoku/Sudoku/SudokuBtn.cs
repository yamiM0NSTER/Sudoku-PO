using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class SudokuBtn : Button
    {
        private int nBaseValue;
        private int nValue;
        private bool bBaseValue;

        public SudokuBtn()
        {
            nBaseValue = 0;
            nValue = 0;
            bBaseValue = false;
            //base.Button();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sudoku_UpdateValue);
        }

        public void SetValue(int nVal, bool bBase)
        {
            nValue = nVal;
            if (bBase)
            {
                nBaseValue = nVal;
                if (nVal != 0)
                {
                    bBaseValue = true;
                    this.BackColor = Color.LightSlateGray;
                }
            }

            if (nVal != 0)
                Text = nVal.ToString();
            else
                Text = "";

            if (bBase == false)
            {
                GameForm parent = Parent as GameForm;
                if (parent.CheckFinished() == true)
                {
                    if (parent.CheckCorrect())
                        parent.Finished();
                    else
                        parent.Wrong();
                }
            }
        }

        public int GetVal()
        {
            return nValue;
        }


        private void Sudoku_UpdateValue(object sender, KeyEventArgs e)
        {
            if (bBaseValue == true)
                return;
            SudokuBtn btn = sender as SudokuBtn;
            int num = -1;
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)   
                num = e.KeyCode - Keys.D0;

            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                num = e.KeyCode - Keys.NumPad0; 

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                num = 0;

            if(num != -1)
                SetValue(num, false);
        }
    }
}
