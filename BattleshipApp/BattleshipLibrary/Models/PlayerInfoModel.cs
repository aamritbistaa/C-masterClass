﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
    public class PlayerInfoModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShipLocation { get; set; } = new List<GridSpotModel>();
        public List<GridSpotModel>ShotGrid{ get; set; } = new List<GridSpotModel>();
    }
}
