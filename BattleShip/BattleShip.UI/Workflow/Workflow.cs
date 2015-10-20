using System;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.Audio;
using BattleShip.UI.Graphics;
using BattleShip.UI.Writers;

namespace BattleShip.UI.Workflow
{
    class Workflows
    {
        static bool _playerHasWon = false;

        private static bool _playAgain = false;

        private static Board _board1;
        private static Board _board2;

        static string _player1;
        static string _player2;


        // Master workflow
        public static void Game()
        {

            Console.Clear();

            // setup game and get player names
            TitleScreenNameEntry();

            Console.Clear();

            // increase window height for gameplay phase
            Console.WindowHeight = 45;

            do
            {
                // Have each player place ships on the board
                SetupGame();

                // loop through player turns until a player wins
                while (!_playerHasWon)
                {
                    PlayerTurn(_board1, _board2, _player1, _player2);

                    if (_playerHasWon) break;

                    PlayerTurn(_board2, _board1, _player2, _player1);
                }

                // ask if player wants to play again. 
                // If yes, loop back. If no, go back to title screen.
                _playAgain = Prompt.PlayAgain();

            } while (_playAgain);

        }


        // Show title screen and get player names
        static public void TitleScreenNameEntry()
        {
            Display.TitleScreen();

            // get player one name
            _player1 = Prompt.PlayerName("player one", 4);

            // delete any previous error message
            ConsoleWriter.DeleteLine(3);

            // get player two name
            _player2 = Prompt.PlayerName("player two", 7);

            // prompt player to begin the game
            Display.BeginGameScreen();
        }

        // Workflow for setting up a new game
        public static void SetupGame()
        {
            _board1 = new Board();
            _board2 = new Board();

            ShipPlacementProcedure(_board1, _player1);
            ShipPlacementProcedure(_board2, _player2);

            // refresh the displays so that the ship placements don't show
            _board1.CreateBoardImg();
            _board2.CreateBoardImg();
        }

        // Prompts a player to place ships on his/her board
        public static void ShipPlacementProcedure(Board board, string playerName)
        {
            Display.NextPlayerScreen(playerName);

            // Loop through each ship type, prompting player to place them.
            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
                PlaceShips.Place(board, playerName, ship);
                Console.Clear();
            }

            BoardImage.Present(board, playerName + "'s setup turn");

            ConsoleWriter.Write("\t\t\t  Your ships are all set!\n\n", 10);
            ConsoleWriter.Write("\t\t\t Press any key to continue", 10, ConsoleColor.White);

            Console.ReadKey();
            Console.Clear();
        }

        // prompts user to fire a shot and records results
        public static void PlayerTurn(Board playerBoard, Board opponentBoard, string playerName, string opponentName)
        {
            var validShot = false; 

            do
            {
                // Label board with player's name
                string boardLabel = $"   {playerName}'s turn";

                BoardImage.Present(playerBoard, boardLabel, 20);

                // prompt for shot
                int[] coords = Prompt.Coord($"    FIRE AT {opponentName}'S BOARD   ");

                // fire shot
                FireShotResponse response = opponentBoard.FireShot(new Coordinate(coords[0], coords[1]));

                // report what happened to user
                validShot = ReportShotResult(playerBoard, playerName, opponentName, response, coords, boardLabel);

            } while (!validShot);
        }

        // reports the results of the shot
        private static bool ReportShotResult(Board playerBoard, string playerName, string opponentName, 
            FireShotResponse response, int[] coords, string boardLabel)
        {
            switch (response.ShotStatus)
            {
                case ShotStatus.Invalid:
                    ConsoleWriter.Write("Invalid coord", 0);
                    return false;

                case ShotStatus.Duplicate:
                    Console.SetCursorPosition(0, Console.CursorTop - 3);
                    ConsoleWriter.Write("\t\t\t*** You already shot there. ***", 10, ConsoleColor.Red);
                    ConsoleWriter.Write("\n\n\t\t\t  Press any key to try again.              \n", 10, ConsoleColor.White);
                    Console.ReadKey();

                    return false;

                case ShotStatus.Miss:
                    playerBoard.BoardImage[coords[0], coords[1]] = " |M| "; // Record miss on player's board  
                    ConsoleWriter.ShotMessage(playerBoard, boardLabel, "\t\t    YOU MISSED! BETTER LUCK NEXT TIME");
                    return true;

                case ShotStatus.Hit:
                    playerBoard.BoardImage[coords[0], coords[1]] = " |H| "; // Record hit on player's board
                    ConsoleWriter.ShotMessage(playerBoard, boardLabel,
                        $"\t\t\t   YOU HIT SOMETHING!");
                    return true;

                case ShotStatus.HitAndSunk:
                    playerBoard.BoardImage[coords[0], coords[1]] = " |H| "; // Record hit on player's board
                    ConsoleWriter.ShotMessage(playerBoard, boardLabel,
                        $"\t\t\t  YOU SUNK {opponentName.ToUpper()}'s {response.ShipImpacted.ToUpper()}!");
                    return true;

                case ShotStatus.Victory:
                    playerBoard.BoardImage[coords[0], coords[1]] = " |H| "; // Record hit on player's board
                    ConsoleWriter.ShotMessage(playerBoard, boardLabel,
                        $"\t\t\t  YOU SUNK {opponentName.ToUpper()}'s {response.ShipImpacted}!\n\t\t\t  YOU ARE THE WINNER!");
                    Synth.WinnerAnnouncement(playerName);
                    _playerHasWon = true;
                    return true;
            }
            return false;
        }

    }
}
