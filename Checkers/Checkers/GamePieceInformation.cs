﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers
{
    public class GamePieceInformation
    {
        public Point gameSquarePosition;
        public GameSquare.e_GameSquareOccupation gamePieceType;
        //BFT TODO: Properties with default get/set are redundant
    }
}