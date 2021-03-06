﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    /// <summary>
    /// Class Designed for Loading Difficulty modes together with levels
    /// </summary>
    public class LevelLoader
    {
        private List<LevelInfo> _lstLevelInfos;
        private int _LevelInfos;
        private MainWindowForm mainWindowForm;

        public LevelLoader(MainWindowForm mainForm)
        {
            _lstLevelInfos = new List<LevelInfo>();
            _LevelInfos = 0;
            mainWindowForm = mainForm;
        }

        public void LoadLevelInfo()
        {
            if (Directory.Exists(".\\Levels"))
            {
                string[] strDirectories = Directory.GetDirectories(".\\Levels");
                //string[] strfileEntries = Directory.GetFiles(".\\Levels");
                string Klappa = "";
                foreach (string DirPath in strDirectories)
                {
                    Klappa += DirPath + "\n";

                    LevelInfo lvlInfo = new LevelInfo();
                    lvlInfo.SetLevelNumber(_LevelInfos);
                    _LevelInfos++;
                    if (File.Exists(DirPath + "\\info.txt"))
                    {
                        // Open the text file using a stream reader.
                        using (StreamReader sr = new StreamReader(DirPath + "\\info.txt"))
                        {
                            // Read the stream to a string, and add to level info class.
                            String line = sr.ReadLine();
                            lvlInfo.SetName(line);
                            Klappa += "\n" + line + "\n";
                        }

                        Klappa += DirPath + "\\info.txt" + "\n"; 
                    }

                    string[] strFiles = Directory.GetFiles(DirPath+"\\");
                    foreach (string FilePath in strFiles)
                    {
                        if (FilePath.Contains("info.txt") || !FilePath.Contains(".txt"))
                            continue;

                        lvlInfo.LoadLevel(FilePath);
                        Klappa += FilePath + "\n";
                    }

                    _lstLevelInfos.Add(lvlInfo);
                }
                    

                //MessageBox.Show(Klappa, "1");
            }
            else
            {
                mainWindowForm.DialogAddLink("Click", "https://github.com/yamiM0NSTER/Sudoku-PO/blob/master/Levels_Help");
                mainWindowForm.ShowDialogForm(mainWindowForm, "OOPS!", "Levels Folder is missing.\n Click the link below to see how to fix that.");
                
                //MessageBox.Show("Kappa", "0");
            }

        }

        public List<LevelInfo> GetLevelInfos()
        {
            return this._lstLevelInfos;
        }
    }
}
