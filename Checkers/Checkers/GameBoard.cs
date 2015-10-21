using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public class GameBoard
    {
        public GameBoard[,] board;
        public Point square;
        int numberOfRows = 8;
        int numberOfColumns = 8;

        public void MakeBoard()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    square.X = i;
                    square.Y = j;
                }
            }
        }
    }
}