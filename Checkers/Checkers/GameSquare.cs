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
        public enum e_GameSquareOccupation
        {
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
        public void SetGameSquareImageSource()
        {
            string gameSquareImageSource = string.Empty;
            switch (gameSquareOccupation)
            {
                case e_GameSquareOccupation.notOccupied:
                    gameSquareImageSource = string.Empty;
                    break;
                case e_GameSquareOccupation.topPlayerRedPiece:
                    gameSquareImageSource = "/Checkers;component/Images/Red.png";
                    break;
                case e_GameSquareOccupation.bottomPlayerBlackPiece:
                    gameSquareImageSource = "/Checkers;component/Images/Black.png";
                    break;
                case e_GameSquareOccupation.topPlayerKingRedPiece:
                    gameSquareImageSource = "/Checkers;component/Images/KingRed.png";
                    break;
                case e_GameSquareOccupation.bottomPlayerKingBlackPiece:
                    gameSquareImageSource = "/Checkers;component/Images/KingBlack.png";
                    break;
            }
        }
    }
}
