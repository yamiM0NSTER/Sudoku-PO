using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    public class LevelInfo
    {
        private List<Level> _lstLevels;
        private string name;
        private int LevelNumber;

        public LevelInfo()
        {
            _lstLevels = new List<Level>();
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetLevelNumber(int nNum)
        {
            this.LevelNumber = nNum;
        }

        public int GetLevelNumber()
        {
            return this.LevelNumber;
        }

        public void LoadLevel(string path)
        {
            if (!File.Exists(path))
                return;

            Level lvl = new Level();

            using (StreamReader sr = new StreamReader(path))
            {
                // Read the stream to a string, and add to level class.
                for (int i = 0; i < 9; i++)
                {
                    String line = sr.ReadLine();
                    for (int j = 0; j < 9; j++)
                        lvl.board[i][j] = line[j]-'0';
                }

                string board = "";
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                        board += lvl.board[i][j];
                    board += "\n";
                }
            }

            _lstLevels.Add(lvl);
        }

        public List<Level> GetLevels()
        {
            return this._lstLevels;
        }
    }
}
