using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class LevelLoader
    {
        private List<LevelInfo> _lstLevelInfos; 
        public LevelLoader()
        {
            
        }

        public void LoadLevelInfo()
        {
            if (Directory.Exists(".\\Levels"))
            {
                string[] strDirectories = Directory.GetDirectories(".\\Levels");
                //string[] strfileEntries = Directory.GetFiles(".\\Levels");
                string Klappa = "";
                foreach (string fileName in strDirectories)
                {
                    Klappa += fileName + "\n";

                    
                }
                    


                MessageBox.Show(Klappa, "1");
            }
            else
            {
                MessageBox.Show("Kappa", "0");
            }

        }
    }
}
