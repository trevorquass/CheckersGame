using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public struct GamePieceMovement
    {
        public Point startPosition;
        public Point endPosition;
        //BFT TODO: Properties with default get/set are redundant
        public static bool CheckForEqualGameSquarePosition(Point firstGameSquarePosition, Point secondGameSquarePosition)
        {
            //BFT TODO: Make this function a one-liner (put condition in return statement)
            return ((firstGameSquarePosition.X == secondGameSquarePosition.X) && (firstGameSquarePosition.Y == secondGameSquarePosition.Y));
        }
    }
}