using System;
using System.Text.RegularExpressions;

namespace BattleShip.UI.Writers
{
    public class Prompt
    {
        private static int _returnLineCursor;

        // prompts player to enter a name
        public static string PlayerName(string player, int errorMsgLinesUp)
        {
            ConsoleWriter.Write($"\n\n\t{player.ToUpper()}: ", 4);

            var input = Console.ReadLine();

            _returnLineCursor = Console.CursorTop - 1;

            while (string.IsNullOrWhiteSpace(input))
            {
                ForgotNameAlert(errorMsgLinesUp); // print error four lines up

                ConsoleWriter.Write($"\t{player.ToUpper()}: ", 4);

                input = Console.ReadLine();

            };

            // return name without whitespace
            return input.Replace(" ", "");
        }

        // error message if name input is empty or null
        public static void ForgotNameAlert(int linesUpToPrint)
        {
            Console.SetCursorPosition(0, Console.CursorTop - linesUpToPrint);

            ConsoleWriter.DeleteLine(-1);
            ConsoleWriter.Write("\n\t\tYou forgot to enter a name. Please Try Again.\n", 9, ConsoleColor.Red);
            Console.SetCursorPosition(0, _returnLineCursor);
        }

        // prompts user to enter a valid coordinate for a specified ship
        static public int[] Coord(string prompt)
        {
            while (true)
            {
                ConsoleWriter.Write($"\n\n\t{prompt.ToUpper()}  >>    ENTER COORDINATE: ", 0);
                var coordStr = Console.ReadLine();

                // remove any special characters or white space
                coordStr = Regex.Replace(coordStr, @"[^0-9a-zA-Z\._]", "").Replace(" ", ""); ;

                var yValid = false;
                var xValid = false;

                var x = 0;
                var y = 0;

                if (coordStr.Length >= 2 && char.IsLetter(coordStr[0]))
                {
                    xValid = true;
                    x = coordStr[0] - 96;
                }

                yValid = coordStr.Length >= 2 && int.TryParse(coordStr.Substring(1, coordStr.Length - 1), out y);

                // if both coords are valid return coordinate
                if (xValid && yValid && x < 11 && x > 0 && y < 11 && y > 0)
                {
                    // if there was an error message above the prompt, delete it. 
                    ConsoleWriter.DeleteLine(3);
                    return new[] { x, y }; // return coordinate
                }


                _returnLineCursor = Console.CursorTop - 3;

                ConsoleWriter.DeleteLine(1);

                Console.SetCursorPosition(0, _returnLineCursor);
                ConsoleWriter.Write($"\n\n\t{prompt.ToUpper()}  >>    ENTER COORDINATE: ", 0);

                // tell user the coord is invalid (above the prompt line)
                InvalidCoordAlert();
            }
        }

        // writes that the chord is invalid (above the prompt line).
        private static void InvalidCoordAlert()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 2);

            ConsoleWriter.DeleteLine(0);
            ConsoleWriter.Write("\t\t\t*** Invalid coord. Try again. ***", 10, ConsoleColor.Red);

            Console.SetCursorPosition(0, _returnLineCursor);
        }

        // asks user if they want to play again 
        public static bool PlayAgain()
        {
            Console.Clear();
            ConsoleWriter.Write(
                "\n\n\n\n\n\n\t\t\tWOULD YOU LIKE TO PLAY AGAIN?" +
                "\n\n\t\t    Enter 'yes' or enter to return to menu\n\n\t\t\t\t     ",
                20);
            string answer = Console.ReadLine();

            if (answer.ToLower().Replace(" ", "") == "yes")
            {
                return true;
            }
            // any answer other than yes is an implied no 
            // like consent. 
            return false;
        }
    }
}
