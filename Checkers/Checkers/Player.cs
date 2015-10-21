using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public class Player
    {
        public enum e_PlayerPosition
        {
            Top = 0,
            Bottom = 1,
        }
        public e_PlayerPosition playerPosition;
        private string playerName;
        public int playerPoints;
        public Player(string inputName)
        {
            playerName = inputName;
            playerPoints = 0;
        }
        public string Name
        {
            get
            {
                return playerName;
            }
        }
    }
}