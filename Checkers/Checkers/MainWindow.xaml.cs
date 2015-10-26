using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace Checkers
{
    public partial class MainWindow : Window
    {
        private GamePieceMovement currentMove;
        private string winner;
        private string turn;

        public MainWindow()
        {
            InitializeComponent();
            currentMove = null;
            winner = null;
            turn = "Black";
            this.Title = "Checkers: Blacks turn";
            MakeBoard();
        }
        public void MakeBoard()
        {
            for (int r = 1; r < 9; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    StackPanel stackPanel = new StackPanel();
                    if (r % 2 != 0)
                    {
                        if (c % 2 == 0)
                            stackPanel.Background = Brushes.White;
                        else
                            stackPanel.Background = Brushes.DimGray;
                    }
                    else
                    {
                        if (c % 2 == 0)
                            stackPanel.Background = Brushes.DimGray;
                        else
                            stackPanel.Background = Brushes.White;
                    }
                    Grid.SetRow(stackPanel, r);
                    Grid.SetColumn(stackPanel, c);
                    CheckersGrid.Children.Add(stackPanel);
                }
            }
            MakeButtons();
        }
        public void ClearBoard()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int colulmn = 0; colulmn < 8; colulmn++)
                {
                    StackPanel stackPanel = (StackPanel)GetGridElement(CheckersGrid, row, colulmn);
                    CheckersGrid.Children.Remove(stackPanel);
                }
            }
        }
        public void MakeButtons()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    StackPanel stackPanel = (StackPanel)GetGridElement(CheckersGrid, row, column);
                    Button button = new Button();
                    button.Click += new RoutedEventHandler(button_Click);
                    button.Height = 30;
                    button.Width = 30;
                    button.HorizontalAlignment = HorizontalAlignment.Center;
                    button.VerticalAlignment = VerticalAlignment.Center;
                    Buttons gameStartButton = new Buttons();
                    var redBrush = new ImageBrush();
                    redBrush.ImageSource = new BitmapImage(new Uri("Images/Red.png", UriKind.Relative));
                    var blackBrush = new ImageBrush();
                    blackBrush.ImageSource = new BitmapImage(new Uri("Images/Black.png", UriKind.Relative));
                    switch (row)
                    {
                        case 1:
                            if (column % 2 != 0)
                            {
                                gameStartButton.MakeRedButton(button, redBrush, stackPanel, row, column);
                            }
                            break;
                        case 2:
                            if (column % 2 == 0)
                            {
                                gameStartButton.MakeRedButton(button, redBrush, stackPanel, row, column);
                            }
                            break;
                        case 3:
                            if (column % 2 != 0)
                            {
                                gameStartButton.MakeRedButton(button, redBrush, stackPanel, row, column);
                            }
                            break;
                        case 4:
                            if (column % 2 == 0)
                            {
                                gameStartButton.MakePlainButton(button, stackPanel, row, column);
                            }
                            break;
                        case 5:
                            if (column % 2 != 0)
                            {
                                gameStartButton.MakePlainButton(button, stackPanel, row, column);
                            }
                            break;
                        case 6:
                            if (column % 2 == 0)
                            {
                                gameStartButton.MakeBlackButton(button, blackBrush, stackPanel, row, column);
                            }
                            break;
                        case 7:
                            if (column % 2 != 0)
                            {
                                gameStartButton.MakeBlackButton(button, blackBrush, stackPanel, row, column);
                            }
                            break;
                        case 8:
                            if (column % 2 == 0)
                            {
                                gameStartButton.MakeBlackButton(button, blackBrush, stackPanel, row, column);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        UIElement GetGridElement(Grid grid, int row, int column)
        {
            for (int i = 0; i < grid.Children.Count; i++)
            {
                UIElement e = grid.Children[i];
                if (Grid.GetRow(e) == row && Grid.GetColumn(e) == column)
                    return e;
            }
            return null;
        }
        public void button_Click(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel stackPanel = (StackPanel)button.Parent;
            int row = Grid.GetRow(stackPanel);
            int col = Grid.GetColumn(stackPanel);
            if (currentMove == null)
                currentMove = new GamePieceMovement();
            if (currentMove.piece1 == null)
            {
                currentMove.piece1 = new GamePiece(row, col);
                stackPanel.Background = Brushes.Green;
            }
            else
            {
                currentMove.piece2 = new GamePiece(row, col);
                stackPanel.Background = Brushes.Green;
            }
            if ((currentMove.piece1 != null) && (currentMove.piece2 != null))
            {
                if (CheckMove())
                {
                    MakeMove();
                }
            }
        }
        public bool CheckMove()
        {
            StackPanel stackPanel1 = (StackPanel)GetGridElement(CheckersGrid, currentMove.piece1.Row, currentMove.piece1.Column);
            StackPanel stackPanel2 = (StackPanel)GetGridElement(CheckersGrid, currentMove.piece2.Row, currentMove.piece2.Column);
            Button button1 = (Button)stackPanel1.Children[0];
            Button button2 = (Button)stackPanel2.Children[0];
            stackPanel1.Background = Brushes.DimGray;
            stackPanel2.Background = Brushes.DimGray;

            if ((turn == "Black") && (button1.Name.Contains("Red")))
            {
                currentMove.piece1 = null;
                currentMove.piece2 = null;
                DisplayError("It is blacks turn.");
                return false;
            }
            if ((turn == "Red") && (button1.Name.Contains("Black")))
            {
                currentMove.piece1 = null;
                currentMove.piece2 = null;
                DisplayError("It is reds turn.");
                return false;
            }
            if (button1.Equals(button2))
            {
                currentMove.piece1 = null;
                currentMove.piece2 = null;
                return false;
            }
            if (button1.Name.Contains("Black"))
            {
                return AllowMove(button1, button2, "Black", "Red");
            }
            else if (button1.Name.Contains("Red"))
            {
                return AllowMove(button1, button2, "Red", "Black");
            }
            else
            {
                currentMove.piece1 = null;
                currentMove.piece2 = null;
                return false;
            }
        }
        public bool AllowMove(Button button1, Button button2, string colorCheckingMoveFor, string oppositeColor)
        {
            GameBoard currentBoard = GetCurrentBoard();
            List<GamePieceMovement> jumpMoves = currentBoard.CheckJumps(colorCheckingMoveFor);

            if (jumpMoves.Count > 0)
            {
                bool invalid = true;
                foreach (GamePieceMovement move in jumpMoves)
                {
                    if (currentMove.Equals(move))
                        invalid = false;
                }
                if (invalid)
                {
                    DisplayError("Jump must be taken");
                    currentMove.piece1 = null;
                    currentMove.piece2 = null;
                    return false;
                }
            }
            if (button1.Name.Contains(colorCheckingMoveFor))
            {
                if (button1.Name.Contains("King"))
                {
                    if ((currentMove.IsAdjacent("King")) && (!button2.Name.Contains("Black")) && (!button2.Name.Contains("Red")))
                        return true;
                    GamePiece middlePiece = currentMove.CheckJump("King");
                    if ((middlePiece != null) && (!button2.Name.Contains("Black")) && (!button2.Name.Contains("Red")))
                    {
                        StackPanel middleStackPanel = (StackPanel)GetGridElement(CheckersGrid, middlePiece.Row, middlePiece.Column);
                        Button middleButton = (Button)middleStackPanel.Children[0];
                        if (middleButton.Name.Contains(oppositeColor))
                        {
                            CheckersGrid.Children.Remove(middleStackPanel);
                            RemoveJumpedPiece(middlePiece);
                            return true;
                        }
                    }
                }
                else
                {
                    if ((currentMove.IsAdjacent(colorCheckingMoveFor)) && (!button2.Name.Contains("Black")) && (!button2.Name.Contains("Red")))
                        return true;
                    GamePiece middlePiece = currentMove.CheckJump(colorCheckingMoveFor);
                    if ((middlePiece != null) && (!button2.Name.Contains("Black")) && (!button2.Name.Contains("Red")))
                    {
                        StackPanel middleStackPanel = (StackPanel)GetGridElement(CheckersGrid, middlePiece.Row, middlePiece.Column);
                        Button middleButton = (Button)middleStackPanel.Children[0];
                        if (middleButton.Name.Contains(oppositeColor))
                        {
                            CheckersGrid.Children.Remove(middleStackPanel);
                            RemoveJumpedPiece(middlePiece);
                            return true;
                        }
                    }
                }
            }
            currentMove = null;
            DisplayError("Invalid Move. Try Again.");
            return false;
        }
        public void MakeMove()
        {
            if ((currentMove.piece1 != null) && (currentMove.piece2 != null))
            {
                StackPanel stackPanel1 = (StackPanel)GetGridElement(CheckersGrid, currentMove.piece1.Row, currentMove.piece1.Column);
                StackPanel stackPanel2 = (StackPanel)GetGridElement(CheckersGrid, currentMove.piece2.Row, currentMove.piece2.Column);
                CheckersGrid.Children.Remove(stackPanel1);
                CheckersGrid.Children.Remove(stackPanel2);
                Grid.SetRow(stackPanel1, currentMove.piece2.Row);
                Grid.SetColumn(stackPanel1, currentMove.piece2.Column);
                CheckersGrid.Children.Add(stackPanel1);
                Grid.SetRow(stackPanel2, currentMove.piece1.Row);
                Grid.SetColumn(stackPanel2, currentMove.piece1.Column);
                CheckersGrid.Children.Add(stackPanel2);
                MakePieceKing(currentMove.piece2);
                currentMove = null;
                if (turn == "Black")
                {
                    this.Title = "Checkers: Reds turn";
                    turn = "Red";
                }
                else if (turn == "Red")
                {
                    this.Title = "Checkers: Blacks turn";
                    turn = "Black";
                }
                CheckWin();
            }
        }
        public GameBoard GetCurrentBoard()
        {
            GameBoard board = new GameBoard();
            for (int row = 1; row < 9; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    StackPanel stackPanel = (StackPanel)GetGridElement(CheckersGrid, row, column);
                    if (stackPanel.Children.Count > 0)
                    {
                        Button button = (Button)stackPanel.Children[0];
                        if (button.Name.Contains("Red"))
                        {
                            if (button.Name.Contains("King"))
                                board.SetGameBoardState(row - 1, column, 3);
                            else
                                board.SetGameBoardState(row - 1, column, 1);
                        }
                        else if (button.Name.Contains("Black"))
                        {
                            if (button.Name.Contains("King"))
                                board.SetGameBoardState(row - 1, column, 4);
                            else
                                board.SetGameBoardState(row - 1, column, 2);
                        }
                        else
                            board.SetGameBoardState(row - 1, column, 0);
                    }
                    else
                    {
                        board.SetGameBoardState(row - 1, column, -1);
                    }
                }
            }
            return board;
        }
        public void MakePieceKing(GamePiece tempPiece)
        {
            StackPanel stackPanel = (StackPanel)GetGridElement(CheckersGrid, tempPiece.Row, tempPiece.Column);
            if (stackPanel.Children.Count > 0)
            {
                Button button = (Button)stackPanel.Children[0];
                var redBrush = new ImageBrush();
                redBrush.ImageSource = new BitmapImage(new Uri("Images/KingRed.png", UriKind.Relative));
                var blackBrush = new ImageBrush();
                blackBrush.ImageSource = new BitmapImage(new Uri("Images/KingBlack.png", UriKind.Relative));
                if ((button.Name.Contains("Black")) && (!button.Name.Contains("King")))
                {
                    if (tempPiece.Row == 1)
                    {
                        button.Name = "button" + "Black" + "King" + tempPiece.Row + tempPiece.Column;
                        button.Background = blackBrush;
                    }
                }
                else if ((button.Name.Contains("Red")) && (!button.Name.Contains("King")))
                {
                    if (tempPiece.Row == 8)
                    {
                        button.Name = "button" + "Red" + "King" + tempPiece.Row + tempPiece.Column;
                        button.Background = redBrush;
                    }
                }
            }
        }
        public void RemoveJumpedPiece(GamePiece middleMove)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Background = Brushes.DimGray;
            Button button = new Button();
            button.Click += new RoutedEventHandler(button_Click);
            button.Height = 30;
            button.Width = 30;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.Background = Brushes.DimGray;
            button.Name = "button" + middleMove.Row + middleMove.Column;
            stackPanel.Children.Add(button);
            Grid.SetColumn(stackPanel, middleMove.Column);
            Grid.SetRow(stackPanel, middleMove.Row);
            CheckersGrid.Children.Add(stackPanel);
        }
        public void CheckWin()
        {
            int totalBlack = 0, totalRed = 0;
            for (int row = 1; row < 9; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    StackPanel stackPanel = (StackPanel)GetGridElement(CheckersGrid, row, column);
                    if (stackPanel.Children.Count > 0)
                    {
                        Button button = (Button)stackPanel.Children[0];
                        if (button.Name.Contains("Red"))
                            totalRed++;
                        if (button.Name.Contains("Black"))
                            totalBlack++;
                    }
                }
            }
            if (totalBlack == 0)
            {
                winner = "Red";
                CheckersGameClient client = new CheckersGameClient();
                client.SendAndReceiveGameInfo(winner);
            }
            if (totalRed == 0)
            {
                winner = "Black";
                CheckersGameClient client = new CheckersGameClient();
                client.SendAndReceiveGameInfo(winner);
            }
            if (winner != null)
            {
                for (int row = 1; row < 9; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        StackPanel stackPanel = (StackPanel)GetGridElement(CheckersGrid, row, column);
                        if (stackPanel.Children.Count > 0)
                        {
                            Button button = (Button)stackPanel.Children[0];
                            button.Click -= new RoutedEventHandler(button_Click);
                        }
                    }
                }
                MessageBoxResult result = MessageBox.Show(winner + " is the winner. Would you like to play again?", "Winner", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    NewGame();
            }
        }
        public void NewGame()
        {
            currentMove = null;
            winner = null;
            turn = "Black";
            this.Title = "Checkers: Blacks turn";
            ClearBoard();
            MakeBoard();
        }
        public void DisplayError(string error)
        {
            MessageBox.Show(error, "Invalid Move", MessageBoxButton.OK);
        }
        public void Connect_Click(object sender, RoutedEventArgs e)
        {
            CheckersGameClient client = new CheckersGameClient();
            client.SendAndReceiveUserInfo();
        }
        public void StartGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}