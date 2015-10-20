using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace FlooringProgram.UI
{
    class Menu
    {
        public static string MenuText =
@"
   **************************************************************************************
   *    /$$$$$$$$/$$                           /$$                                      *
   *   | $$_____| $$                          |__/                                      *
   *   | $$     | $$ /$$$$$$  /$$$$$$  /$$$$$$ /$$/$$$$$$$  /$$$$$$                     *
   *   | $$$$$  | $$/$$__  $$/$$__  $$/$$__  $| $| $$__  $$/$$__  $$                    *
   *   | $$__/  | $| $$  \ $| $$  \ $| $$  \__| $| $$  \ $| $$  \ $$                    *
   *   | $$     | $| $$  | $| $$  | $| $$     | $| $$  | $| $$  | $$                    *
   *   | $$     | $|  $$$$$$|  $$$$$$| $$     | $| $$  | $|  $$$$$$$                    *
   *   |__/     |__/\______/ \______/|__/     |__|__/  |__/\____  $$                    *
   *                                                       /$$  \ $$                    *
   *               PROGRAM                                 |  $$$$$$/                   *
   *                                                        \______/                    *
   *                                                                                    *
   *   1. Display Orders                                                                *
   *   2. Add an Order                                                                  *
   *   3. Edit an Order                                                                 *
   *   4. Remove an Order                                                               *
   *   5. Quit                                                                          *
   *                                                                                    *
   **************************************************************************************
";

        public static string input;

        public static string MenuPrompt()
        {
            Console.Clear();
            Console.WriteLine(Menu.MenuText);

            while (true)
            {
                

                Console.Write("\n\n\t\tEnter an option: ");

                input = Console.ReadLine();


                input = input.Replace(" ", "");

                switch (input) // Ensure that input is 1-5
                {
                    case "1":
                        return input; 
                    case "2":
                        return input;
                    case "3":
                        return input;
                    case "4":
                        return input;
                    case "5":
                        return input;

                }

                Console.Clear();
                Console.WriteLine(Menu.MenuText);

                Program.ErrorWriter("\t\tYou entered invalid data. Please try again.");
            }


        }
    }
}
