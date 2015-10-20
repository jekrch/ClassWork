using System;
using System.Linq;
using BattleShip.BLL.GameLogic;
using BattleShip.UI.Writers;

namespace BattleShip.UI.Graphics
{
    class BoardImage
    {
        // writes board to the screen
        public static void Present(Board board, string label, int timeDelay = 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(AsciiArt.Line + "\n\n\n" + "\n" + AsciiArt.Line + "\n");

            WriteBoard(board.BoardImage);

            // save cursor location to return after text scroll
            int returnLineCursor = Console.CursorTop;

            // scroll/animate board label at the top of the board
            Console.SetCursorPosition(0, Console.CursorTop - 35);
            ConsoleWriter.Write($"\n\t\t\t    {label.ToUpper()}\n\n", timeDelay);

            // return to bottom/original cursor position
            Console.SetCursorPosition(0, returnLineCursor);
        }

        // Displays the board to the console.
        public static void WriteBoard(string[,] boardImage)
        {
            for (int y = 0; y < 11; y++)
            {
                Console.Write("\t");

                for (int x = 0; x < 11; x++)
                {
                    // color row or column labels cyan
                    ColorRowOrColLabel(x, y); 
                    
                    // During setup, this colors the ship positions gray 
                    // (to simulate the body of the ship)
                    if (boardImage[x, y] != null && x != 0
                        && (boardImage[x, y].Contains(':')))
                    {
                        WriteSetupShipsGray(boardImage, x, y);
                        continue; // continue on to next position 
                    }

                    // Set the color for Ms or Hs 
                    SetMarkColor(boardImage[x, y], "M", ConsoleColor.Yellow);
                    SetMarkColor(boardImage[x, y], "|H|", ConsoleColor.Red);

                    // Write position to the board the board
                    Console.Write(boardImage[x, y]);
                    Console.ResetColor();
                }

                Console.WriteLine();

                // make the first row empty
                if (y == 0) Console.WriteLine();

                // Write an empty blue wrote between each row with positions
                // to space out the screen a bit
                EmptyBlueRow();
            }

            // insert line at bottom of board
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n" + AsciiArt.Line);
        }

        // Writes an empty blue row
        private static void EmptyBlueRow()
        {
            Console.Write("\t     ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("\t\t\t\t\t\t       \n");
            Console.ResetColor();
        }

        // Write setup ship, marked with a ':', in gray
        private static void WriteSetupShipsGray(string[,] boardImage, int x, int y)
        {
            Console.Write(boardImage[x, y].Substring(0, 1));

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(boardImage[x, y].Substring(1, 3));

            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Write(boardImage[x, y].Substring(4, 1));

            Console.ResetColor();
        }

        // color the row and column labels
        private static void ColorRowOrColLabel(int x, int y)
        {
            if (y == 0 || x == 0) 
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            };
        }

        public static void SetMarkColor(string boardPosition, string mark, ConsoleColor color)
        {
            if (boardPosition != null && boardPosition.Contains(mark))
            {
                Console.ForegroundColor = color;
            }
        }
    }
}
