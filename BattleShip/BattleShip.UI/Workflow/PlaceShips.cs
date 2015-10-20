using System;
using System.Collections.Generic;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.Graphics;
using BattleShip.UI.Writers;

namespace BattleShip.UI.Workflow
{
    class PlaceShips
    {
        // dictionary that stores ship sizes
        static Dictionary<ShipType, int> _shipDict = new Dictionary<ShipType, int>()
        {
            { ShipType.Destroyer, 2 },
            { ShipType.Submarine, 3 },
            { ShipType.Battleship, 4 },
            { ShipType.Carrier, 5 },
            { ShipType.Cruiser, 3 },
        };


        // Prompt user to place a ship on their board. 
        public static void Place(Board board, string playerName, ShipType ship)
        {
            BoardImage.Present(board, playerName + "'s setup turn");
            ShipPlacement placementResult;

            do
            {
                // prompt for coord and direction while listing ship and ship size
                int[] coords = Prompt.Coord($"{ship} ({_shipDict[ship]})\t");

                ShipDirection direction = DirectionPrompt();

                // create ship request
                var request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(coords[0], coords[1]),
                    Direction = direction,
                    ShipType = ship,
                };

                // request a ship placement
                placementResult = board.PlaceShip(request);
                Console.Clear();

                if (placementResult == ShipPlacement.NotEnoughSpace)
                {                  
                    BoardImage.Present(board, playerName + "'s setup turn");
                    ConsoleWriter.Write("\t\t\t*** Not enough space. Try again. ***", 
                                        10, ConsoleColor.Red);
                }
                else if (placementResult == ShipPlacement.Overlap)
                {   
                    BoardImage.Present(board, playerName + "'s setup turn");
                    ConsoleWriter.Write("\t\t*** Another ship is already there. Try again. ***",
                                         10, ConsoleColor.Red);
                }

            } while (placementResult != ShipPlacement.Ok); // loop until ship placement is valid

            board.UpdateBoardImg();    // update board image to reflect placed ships
        }

        // User is prompted for the direction in which he/she wants the ship to placed
        static public ShipDirection DirectionPrompt()
        {
            bool isValid = false; 
            string directionString;

            do
            {
                ConsoleWriter.Write("\n\t\t\t\tENTER DIRECTION (u,d,l,r): ", 0);
                directionString = Console.ReadLine().ToLower();

                int returnLineCursor = Console.CursorTop - 2;

                // deletes old prompt, puts error message on earlier line, and then reprompts at original line. 
                ConsoleWriter.DeleteLine(1, 5);

                Console.SetCursorPosition(0, Console.CursorTop - 5);

                if (
                    !(directionString == "u" || directionString == "d" ||
                      directionString == "l" || directionString == "r"))
                {
                    ConsoleWriter.Write("\t\t\t*** Invalid direction. Try again. *** ", 10, ConsoleColor.Red);
                }
                else
                {
                    isValid = true;
                }
               
                Console.SetCursorPosition(0, returnLineCursor);   
                       
            } while (!isValid);

            switch (directionString)  // Translates user input into a direction enum
            {
                case "u":
                    return ShipDirection.Up;
                case "d":
                    return ShipDirection.Down;
                case "r":
                    return ShipDirection.Right;
                default:
                    return ShipDirection.Left;
            }


        }



        // this was used for testing purposes
        public static void AutoPlaceShips(Board board)
        {
            int i = 1;

            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
                PlaceShipRequest request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(1, i),
                    Direction = ShipDirection.Right,
                    ShipType = ship,
                };

                i++;

                board.PlaceShip(request);
                board.UpdateBoardImg();
            }


        }
    }

}
