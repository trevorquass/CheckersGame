using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Checkers
{
    class Buttons
    {
        public void MakeRedButton(Button button, ImageBrush redBrush, StackPanel stackPanel, int row, int column)
        {
            button.Background = redBrush;
            button.Name = "buttonRed" + row + column;
            stackPanel.Children.Add(button);
        }
        public void MakeBlackButton(Button button, ImageBrush blackBrush, StackPanel stackPanel, int row, int column)
        {
            button.Background = blackBrush;
            button.Name = "buttonBlack" + row + column;
            stackPanel.Children.Add(button);
        }
        public void MakePlainButton(Button button, StackPanel stackPanel, int row, int column)
        {
            button.Background = Brushes.DimGray;
            button.Name = "button" + row + column;
            stackPanel.Children.Add(button);
        }
    }
}
