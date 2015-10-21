using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public class GamePiece
    {
        public int Row;
        public int Column;
        public GamePiece(int row, int col)
        {
            Row = row;
            Column = col;
        }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            GamePiece piece = obj as GamePiece;
            if ((System.Object)piece == null)
            {
                return false;
            }
            return Row == piece.Row && Column == piece.Column;
        }
    }
}