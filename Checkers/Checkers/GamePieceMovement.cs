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
        public static bool CheckForEqualGameSquarePosition(Point firstGameSquarePosition, Point secondGameSquarePosition)
        {
            return ((firstGameSquarePosition.X == secondGameSquarePosition.X) && (firstGameSquarePosition.Y == secondGameSquarePosition.Y));
        }
    }
}