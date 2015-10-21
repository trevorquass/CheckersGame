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
        public int[,] board = new int[8, 8];
        public GameBoard()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    board[r, c] = -1;
                }
            }
        }
        public bool SetState(int r, int c, int state)
        {
            if ((state > 4) || (state < -1))
                return false;
            board[r, c] = state;
            return true;
        }
        public int GetState(int r, int c)
        {
            if ((r > 7) || (r < 0) || (c > 7) || (c < 0))
                return -1;
            return board[r, c];
        }
        public List<GamePieceMovement> CheckJumps(string color)
        {
            List<GamePieceMovement> jumps = new List<GamePieceMovement>();
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (color == "Red")
                    {
                        if (GetState(r, c) == 3)
                        {
                            if ((GetState(r - 2, c - 2) == 0) && ((GetState(r - 1, c - 1) == 2) || (GetState(r - 1, c - 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r - 1, c - 2)));
                            }
                            if ((GetState(r - 2, c + 2) == 0) && ((GetState(r - 1, c + 1) == 2) || (GetState(r - 1, c + 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r - 1, c + 2)));
                            }
                            if ((GetState(r + 2, c - 2) == 0) && ((GetState(r + 1, c - 1) == 2) || (GetState(r + 1, c - 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r + 3, c - 2)));
                            }
                            if ((GetState(r + 2, c + 2) == 0) && ((GetState(r + 1, c + 1) == 2) || (GetState(r + 1, c + 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r + 3, c + 2)));
                            }
                        }
                        if (GetState(r, c) == 1)
                        {
                            if ((GetState(r + 2, c - 2) == 0) && ((GetState(r + 1, c - 1) == 2) || (GetState(r + 1, c - 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r + 3, c - 2)));
                            }
                            if ((GetState(r + 2, c + 2) == 0) && ((GetState(r + 1, c + 1) == 2) || (GetState(r + 1, c + 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r + 3, c + 2)));
                            }
                        }
                    }
                    if (color == "Black")
                    {
                        if (GetState(r, c) == 4)
                        {
                            if ((GetState(r - 2, c - 2) == 0) && ((GetState(r - 1, c - 1) == 1) || (GetState(r - 1, c - 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r - 1, c - 2)));
                            }
                            if ((GetState(r - 2, c + 2) == 0) && ((GetState(r - 1, c + 1) == 1) || (GetState(r - 1, c + 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r - 1, c + 2)));
                            }
                            if ((GetState(r + 2, c - 2) == 0) && ((GetState(r + 1, c - 1) == 1) || (GetState(r + 1, c - 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r + 3, c - 2)));
                            }
                            if ((GetState(r + 2, c + 2) == 0) && ((GetState(r + 1, c + 1) == 1) || (GetState(r + 1, c + 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r + 3, c + 2)));
                            }
                        }
                        if (GetState(r, c) == 2)
                        {
                            if ((GetState(r - 2, c - 2) == 0) && ((GetState(r - 1, c - 1) == 1) || (GetState(r - 1, c - 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r - 1, c - 2)));
                            }
                            if ((GetState(r - 2, c + 2) == 0) && ((GetState(r - 1, c + 1) == 1) || (GetState(r - 1, c + 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(r + 1, c), new GamePiece(r - 1, c + 2)));
                            }
                        }
                    }
                }
            }
            return jumps;
        }
    }
}