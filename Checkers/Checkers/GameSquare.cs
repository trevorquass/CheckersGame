using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public class GameSquare
    {
        //BFT TODO: Add System.?.Point member variable here to track position (instead of having position on the GameBoard class)
        //BFT TODO: Don't prefix member names with class name
        public enum e_GameSquareOccupation
        {
            invalidSpace = -1,
            notOccupied = 0,
            topPlayerRedPiece = 1,
            bottomPlayerBlackPiece = 2,
            topPlayerKingRedPiece = 3,
            bottomPlayerKingBlackPiece = 4,
        }
        public Point position;
        public e_GameSquareOccupation gameSquareOccupation;
        public GameSquare()
        {
            position = new Point();
            gameSquareOccupation = e_GameSquareOccupation.notOccupied;
        }
    }
}
