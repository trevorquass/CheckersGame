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
        public enum State
        {
            invalidSpace = -1,
            empty = 0,
            red = 1,
            black = 2,
            kingRed = 3,
            kingBlack = 4,
        }
        public GameBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    board[row, column] = -1;

                }
            }
        }
        public int GetGameBoardState(int row, int column)
        {
            if ((row > 7) || (row < 0) || (column > 7) || (column < 0))
                return -1;
            return board[row, column];
        }
        public bool SetGameBoardState(int row, int column, int state)
        {
            if ((state > 4) || (state < -1))
                return false;
            board[row, column] = state;
            return true;
        }
        public List<GamePieceMovement> CheckJumps(string color)
        {
            List<GamePieceMovement> jumps = new List<GamePieceMovement>();
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (color == "Red")
                    {
                        if (GetGameBoardState(row, column) == 3)
                        {
                            if ((GetGameBoardState(row - 2, column - 2) == 0) && ((GetGameBoardState(row - 1, column - 1) == 2) || (GetGameBoardState(row - 1, column - 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row - 1, column - 2)));
                            }
                            if ((GetGameBoardState(row - 2, column + 2) == 0) && ((GetGameBoardState(row - 1, column + 1) == 2) || (GetGameBoardState(row - 1, column + 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row - 1, column + 2)));
                            }
                            if ((GetGameBoardState(row + 2, column - 2) == 0) && ((GetGameBoardState(row + 1, column - 1) == 2) || (GetGameBoardState(row + 1, column - 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row + 3, column - 2)));
                            }
                            if ((GetGameBoardState(row + 2, column + 2) == 0) && ((GetGameBoardState(row + 1, column + 1) == 2) || (GetGameBoardState(row + 1, column + 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row + 3, column + 2)));
                            }
                        }
                        if (GetGameBoardState(row, column) == 1)
                        {
                            if ((GetGameBoardState(row + 2, column - 2) == 0) && ((GetGameBoardState(row + 1, column - 1) == 2) || (GetGameBoardState(row + 1, column - 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row + 3, column - 2)));
                            }
                            if ((GetGameBoardState(row + 2, column + 2) == 0) && ((GetGameBoardState(row + 1, column + 1) == 2) || (GetGameBoardState(row + 1, column + 1) == 4)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row + 3, column + 2)));
                            }
                        }
                    }
                    if (color == "Black")
                    {
                        if (GetGameBoardState(row, column) == 4)
                        {
                            if ((GetGameBoardState(row - 2, column - 2) == 0) && ((GetGameBoardState(row - 1, column - 1) == 1) || (GetGameBoardState(row - 1, column - 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row - 1, column - 2)));
                            }
                            if ((GetGameBoardState(row - 2, column + 2) == 0) && ((GetGameBoardState(row - 1, column + 1) == 1) || (GetGameBoardState(row - 1, column + 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row - 1, column + 2)));
                            }
                            if ((GetGameBoardState(row + 2, column - 2) == 0) && ((GetGameBoardState(row + 1, column - 1) == 1) || (GetGameBoardState(row + 1, column - 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row + 3, column - 2)));
                            }
                            if ((GetGameBoardState(row + 2, column + 2) == 0) && ((GetGameBoardState(row + 1, column + 1) == 1) || (GetGameBoardState(row + 1, column + 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row + 3, column + 2)));
                            }
                        }
                        if (GetGameBoardState(row, column) == 2)
                        {
                            if ((GetGameBoardState(row - 2, column - 2) == 0) && ((GetGameBoardState(row - 1, column - 1) == 1) || (GetGameBoardState(row - 1, column - 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row - 1, column - 2)));
                            }
                            if ((GetGameBoardState(row - 2, column + 2) == 0) && ((GetGameBoardState(row - 1, column + 1) == 1) || (GetGameBoardState(row - 1, column + 1) == 3)))
                            {
                                jumps.Add(new GamePieceMovement(new GamePiece(row + 1, column), new GamePiece(row - 1, column + 2)));
                            }
                        }
                    }
                }
            }
            return jumps;
        }
    }
}