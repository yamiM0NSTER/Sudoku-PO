﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Level
    {
        public int[][] board;
        public Level()
        {
            board = new int[9][];
            for( int i = 0; i < 9;i++)
                board[i] = new int[9];
        }
    }
}
