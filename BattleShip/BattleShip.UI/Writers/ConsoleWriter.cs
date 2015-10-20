using System;
using System.Threading;
using BattleShip.BLL.GameLogic;
using BattleShip.UI.Graphics;

namespace BattleShip.UI.Writers
{
    public static class ConsoleWriter
    {

        #region General purpose write functions

        // Writes to the console at a user specified delay and in a user specified color
        static public void Write(string str, int timeDelay, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            foreach (char c in str)
            {
                Console.Write(c);
                Thread.Sleep(timeDelay);
            }
            Console.ResetColor();
        }

        // writers command to screen between both lines
        public static string WriteHeading(string command)
        {
            return $"{AsciiArt.Line}{command}\n{AsciiArt.Line}";
        }
        
        #endregion



        #region shot-taking related write functions
      
        // writes message message revealing the result of a fireshot call/displays board with resort
        public static void ShotMessage(Board playerBoard, string boardLabel, string message)
        {
            // build some suspense by writing * * * across screen before reporting shot status
            ProcessingAnimation();

            // deliver message
            Write($"\n{message}", 30, ConsoleColor.White);

            // refresh the board to show new shot placement
            Console.Clear();
            BoardImage.Present(playerBoard, boardLabel);

            Write($"{message}", 0, ConsoleColor.White);

            Write("\n\n\t\t\tPress any key to continue.", 10);
            Console.ReadKey();
        }
    
        // Writes '* * *...' across screen to simulate computer thinking
        private static void ProcessingAnimation()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 4);
            Write("\n\t\t\t      * * * * * * *", 0, ConsoleColor.White);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        #endregion



        #region Deletion methods
        // Deletes a line at the designated line above the current cursor position, then returns to original position
        public static void DeleteLine(params int[] linesAbove)
        {
            foreach (int n in linesAbove)
            {
                int returnLineCursor = Console.CursorTop;

                Console.SetCursorPosition(0, Console.CursorTop - n);
                Console.WriteLine(new string(' ', Console.WindowWidth));

                Console.SetCursorPosition(0, returnLineCursor);
            }

        }


        // Performs same operation as Delete line, except this deletes each character with a delay
        public static void DeleteLine(bool slowdown, params int[] linesAbove)
        {
            foreach (int n in linesAbove)
            {
                int returnLineCursor = Console.CursorTop;

                Console.SetCursorPosition(0, Console.CursorTop - n);
                Write(new string(' ', Console.WindowWidth), 2);

                Console.SetCursorPosition(0, returnLineCursor);
            }

        } 
        #endregion
    }
}
