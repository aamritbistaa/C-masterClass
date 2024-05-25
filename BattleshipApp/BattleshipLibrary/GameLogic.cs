using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary
{
    public class GameLogic
    {
        public static void InitializeGrid(PlayerInfoModel model)
        {
            List<String> letters = new List<String>
            {
                "A",
                "B",
                "C",
                "D",
                "E"
            };
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            foreach(string letter in letters)
            {
                foreach(int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }
            }

        }

        public static bool PlaceShip(PlayerInfoModel model, string location)
        {


            throw new NotImplementedException();
        }

        private  static void AddGridSpot(PlayerInfoModel model,string letter, int number) {
        
            GridSpotModel modelSpot = new GridSpotModel();
            modelSpot.SpotLetter = letter;
            modelSpot.SpotNumber = number;
            modelSpot.Status = GridSpotStatus.Empty;
            model.ShotGrid.Add(modelSpot);
        }
    }
}
