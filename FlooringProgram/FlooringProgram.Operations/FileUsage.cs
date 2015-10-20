using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.Operations
{
    public class FileUsage
    {


        public static bool GetOrder(string date, int orderNumber, ref Order orderOutput)
        {
            string filePath = $@"Data\Orders_{date}.txt"; 

            if (!FileTracker.CheckForFile(filePath)) // if file doesn't exist return false
            {
                return false; 
            }

            DataExtractor.OrderReader(filePath, orderNumber, ref orderOutput);
            return true;


            //Console.WriteLine(FileUsage.);
        }

        


    }
}
