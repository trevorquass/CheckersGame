using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public class GamePieceMovement
    {
        public GamePiece piece1;
        public GamePiece piece2;
        public GamePieceMovement()
        {
            piece1 = null;
            piece2 = null;
        }
        public GamePieceMovement(GamePiece piece1, GamePiece piece2)
        {
            this.piece1 = piece1;
            this.piece2 = piece2;
        }
        public bool IsAdjacent(string color)
        {
            if (color == "Black")
            {
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
            }
            if (color == "Red")
            {
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
            }
            if (color == "King")
            {
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
            }
            return false;
        }
        public GamePiece CheckJump(string color)
        {
            if (color == "Black")
            {
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new GamePiece(piece1.Row - 1, piece1.Column - 1);
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new GamePiece(piece1.Row - 1, piece1.Column + 1);
            }
            if (color == "Red")
            {
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new GamePiece(piece1.Row + 1, piece1.Column - 1);
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new GamePiece(piece1.Row + 1, piece1.Column + 1);
            }
            if (color == "King")
            {
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new GamePiece(piece1.Row - 1, piece1.Column - 1);
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new GamePiece(piece1.Row - 1, piece1.Column + 1);
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new GamePiece(piece1.Row + 1, piece1.Column - 1);
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new GamePiece(piece1.Row + 1, piece1.Column + 1);
            }

            return null;
        }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            GamePieceMovement move = obj as GamePieceMovement;
            if ((System.Object)move == null)
            {
                return false;
            }

            return ((piece1.Equals(move.piece1)) && (piece2.Equals(move.piece2)));
        }
    }
}