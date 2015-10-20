using System;
using BattleShip.UI.Writers;

namespace BattleShip.UI.Graphics
{
    class Display
    {
        // Displays the title screen to user
        public static void TitleScreen()
        {
            ConsoleWriter.Write(AsciiArt.Title, 2, ConsoleColor.Green);

            ConsoleWriter.Write(
                ConsoleWriter.WriteHeading("\n\t\t\tPLEASE ENTER PLAYER NAMES"), 1, ConsoleColor.Green);

            Console.WriteLine();
        }
        
        // prompts the user to begin game via keypress
        public static void BeginGameScreen()
        {
            Console.Clear();
            ConsoleWriter.Write(AsciiArt.Title, 0, ConsoleColor.Green);

            ConsoleWriter.Write(ConsoleWriter.WriteHeading("\n\t\t\tPRESS ANY KEY TO BEGIN GAME"), 1, ConsoleColor.Green);
            Console.ReadKey();
        }

        // prompts the next player to take the screen
        public static void NextPlayerScreen(string player)
        {
            ConsoleWriter.Write($"\n\n\n\n\n{AsciiArt.Line}\n\n\t\t\tPlease pass the screen to " +
                                 $"{player}\n\n\t\t\t   Press any key to continue\n\n{AsciiArt.Line}", 3);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n\n\n{AsciiArt.Ship}"); // show ship on screen

            Console.ReadKey();

            // Delete each line of the nextplayer screen with a delay
            ConsoleWriter.DeleteLine(true, 17, 20, 22, 25);

            Console.Clear();
        }
    }
}
