using BattleshipLibrary;
using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            
            PlayerInfoModel player1 = CreatePlayer("Player 1");
            PlayerInfoModel player2 = CreatePlayer("Player 2");
            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome To BattleShip");
            Console.WriteLine();
        }
        private static PlayerInfoModel CreatePlayer( string player)
        {
            PlayerInfoModel output = new PlayerInfoModel();
            Console.WriteLine($"Player Information for {player}");
            //Ask User for name
            output.Name= AskForUsersName();
            
            //Load up the shot grid
            GameLogic.InitializeGrid(output);

            //Ask user for their 5 ship placements
            PlaceShips(output);

            //clear
            Console.Clear();
            return output;
        }
        private static string AskForUsersName()
        {
            Console.WriteLine("Enter your name");
            string output = Console.ReadLine();
            return output;
        }
        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.WriteLine($"Enter the location to place your ship {model.ShipLocation.Count+1}");
                string location = Console.ReadLine();
                bool isValidLocation = GameLogic.PlaceShip(model,location);
                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please Try again");
                }

            } while (model.ShipLocation.Count < 5);
        }
    }
}
