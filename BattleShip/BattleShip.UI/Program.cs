using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using BattleShip.BLL.GameLogic;
using BattleShip.UI.Audio;
using BattleShip.UI.Workflow;

namespace BattleShip.UI
{
    class Program
    {

        // I make the console window longer, so I want it to sit higher on the screen by default. 
        // someone on stack suggested this
        static class Imports
        {
            public static uint SwpNosize = 1;
            public static uint SwpNozorder = 4;

            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint wFlags);
        }
        
        static void Main(string[] args)
        {
       
            // Move the board towards the top of the screen so that it doesn't run off screen
            var consoleWnd = Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 100, 10, 10, 10, Imports.SwpNosize | Imports.SwpNozorder);

            // play the jingle while title screen animates
            Synth.PlayJingle();

            // Read this line to user in creepy AI tone (asynchronous with jingle)
            Synth.Speak("Man your Battleship. This is not a test.", 150);

            //Start Game
            Workflows.Game(); 
        }

        
    }

}
