﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
   public enum GridSpotStatus
    {
        Empty,
        Ship,
        Miss,
        Hit,
        Sunk
        /*
         * 0 - Empty
         * 1 - Ship
         * 2 - Miss
         * 3 - hit
         * 4 - sunk
         */
    }
}
