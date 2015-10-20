using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Operations;

namespace FlooringProgram.UI
{
    class Program
    {
        static string orderDate;
        static int orderNumber;
        static bool isValidDate;
        static bool isValidOrderNumber;

        static void Main(string[] args)
        {
            Console.WindowWidth = 92;
            Console.WindowHeight = 50;

            TaxRate stateTax = StateTaxPrompt();

            // var a = "a";
            // CustomerPrompt();


            string input = Menu.MenuPrompt();

            switch (input)
            {
                case "1":
                    DisplayOrder();
                    break;
                case "2":
                    break; 

            }


            Console.WriteLine(input);
            Console.ReadLine(); 


             DisplayOrder();
         
            

            //Console.ReadLine();
        }

        static public void AddOrder()
        {
            Console.Clear(); 
            Order orderToAdd = new Order();

            orderToAdd.CustomerName = CustomerPrompt();



            ///Console.WriteLine($"\t\nOrder Number: {orderToDisplay.OrderNumber}");

            //Console.Write($"\tCustomer Name: ");



            //Console.WriteLine($"\tState: {orderToDisplay.StateTaxRate.State}");
            //    Console.WriteLine($"\tTax Rate: {orderToDisplay.StateTaxRate.TaxPercent}");

            //Console.WriteLine($"\tArea: {orderToDisplay.Area}");

            //Console.WriteLine($"\tProduct Type: {orderToDisplay.ProductInfo.ProductType}");
            //    Console.WriteLine($"\tLabor Cost Per Square Foot: {orderToDisplay.ProductInfo.LaborCostPerSquareFoot}");
            //    Console.WriteLine(
            //    $"\tMaterial Cost Per Square Foot: {orderToDisplay.ProductInfo.MaterialCostPerSquareFoot}");
            //    Console.WriteLine($"\tMaterial Cost: {orderToDisplay.MaterialCost}");

            //    Console.WriteLine($"\tLabor Cost: {orderToDisplay.LaborCost}");
            //    Console.WriteLine($"\tTax: {orderToDisplay.Tax}");
            //    Console.WriteLine($"\tTotal: {orderToDisplay.Total}");
        }

        public static TaxRate StateTaxPrompt()
        {

            Console.WriteLine("\n\t\t\tEnter Order Details");
            Console.Write($"\n\n\n\t\tState: ");

            while (true)
            {

                string state = Console.ReadLine();

                TaxRateOperations taxOps = new TaxRateOperations();

                if (taxOps.IsAllowedState(state))
                {
                    return taxOps.GetTaxRateFor(state);
                    
                }
              
     
                Console.Clear();
                Console.WriteLine("\n\t\t\tEnter Order Details");
                ErrorWriter("\n\t\tInvalid state. Please try again.");
                Console.Write($"\n\n\t\tState: ");

            }

            //Console.Write("Enter a state: ");
            ////string state = Console.ReadLine();

            //TaxRateOperations taxOps = new TaxRateOperations();
            //if (taxOps.IsAllowedState(state))
            //{
            //    Console.WriteLine("That is a valid state");
            //    TaxRate rate = taxOps.GetTaxRateFor(state);

            //    Console.WriteLine("The tax rate for {0} is {1:p}", rate.State, rate.TaxPercent);
            //}
            //else
            //{
            //    Console.WriteLine("That is not a valid state");
            //}

            
        }

        public static string CustomerPrompt()
        {
 
            Console.WriteLine("\n\t\t\tEnter Order Details");
            Console.Write($"\n\n\n\t\tCustomer Name: ");

            while (true)
            {

                string name = Console.ReadLine();

                if (!(name.Replace(" ", "") == ""))
                {
                    return name; 
                }
                Console.Clear();
                Console.WriteLine("\n\t\t\tEnter Order Details");
                ErrorWriter("\n\t\tInvalid entry. Please try again.");
                Console.Write($"\n\n\t\tCustomer Name: ");

            }
            
        }

        public static void AddOrderPrompt(string fieldName, string field)
        {
            Console.Write($"\t{fieldName}: ");

        }

        static public void DisplayOrder()
        {

            PromptOrderInfo();
            Order orderToDisplay = new Order();

            if (FileUsage.GetOrder(orderDate, orderNumber, ref orderToDisplay))
            {
                WriteOrder(orderToDisplay);
            }
            else
            {
                ErrorWriter("\n\tThe order does not exist.");
               
            }


            Console.ReadLine(); 

        }

        private static void WriteOrder(Order orderToDisplay)
        {
            Console.WriteLine($"\t\nOrder Number: {orderToDisplay.OrderNumber}");
            Console.WriteLine($"\tCustomer Name: {orderToDisplay.CustomerName}");
            Console.WriteLine($"\tState: {orderToDisplay.StateTaxRate.State}");
            Console.WriteLine($"\tTax Rate: {orderToDisplay.StateTaxRate.TaxPercent}");
            Console.WriteLine($"\tArea: {orderToDisplay.Area}");
            Console.WriteLine($"\tProduct Type: {orderToDisplay.ProductInfo.ProductType}");
            Console.WriteLine($"\tLabor Cost Per Square Foot: {orderToDisplay.ProductInfo.LaborCostPerSquareFoot}");
            Console.WriteLine(
                $"\tMaterial Cost Per Square Foot: {orderToDisplay.ProductInfo.MaterialCostPerSquareFoot}");
            Console.WriteLine($"\tMaterial Cost: {orderToDisplay.MaterialCost}");
            Console.WriteLine($"\tLabor Cost: {orderToDisplay.LaborCost}");
            Console.WriteLine($"\tTax: {orderToDisplay.Tax}");
            Console.WriteLine($"\tTotal: {orderToDisplay.Total}");

            Console.WriteLine("\n\tPress any key to continue.");
            Console.ReadKey();
        }

        public static void ErrorWriter(string str)
        {
            foreach (var c in str)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(c);
                Thread.Sleep(10);
                Console.ResetColor();
            }
        }


        public static void PromptOrderInfo()
        {
            do
            {
                Console.Write("\n\tEnter a date in the format of ddmmyyy. \n\tExample: January 13, 2015 is written: 01132015: ");
                orderDate = Console.ReadLine();

                isValidDate = Validation.ValidateDate(ref orderDate);
                if (isValidDate)
                {
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tInvalid Date. Please try again.\n");
                Console.ResetColor();

            } while (!isValidDate);

            do
            {
                Console.Write("\n\tEnter an order number: ");
                string orderNumberStr = Console.ReadLine();
                orderNumberStr = orderNumberStr.Replace(" ", "");

                isValidOrderNumber = int.TryParse(orderNumberStr, out orderNumber);
                if (isValidOrderNumber)
                {
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tInvalid order number. Please try again.");
                Console.ResetColor();

            } while (!isValidOrderNumber);
        }

    }
}
