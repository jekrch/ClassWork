using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models; 

namespace FlooringProgram.Data
{
    public class DataExtractor
    {

        // Read file at designated filePath, set order object corresponding to order number, 
        // and return bool indicating whether order exists
        public static bool OrderReader(string filePath, int orderNumber, ref Order order)
        {
            try
            {

                string[] data = File.ReadAllLines(filePath);

                if (data.Length <= orderNumber)
                {
                    return false;
                }

                // If order exists set values to order fields 
                string[] row = data[orderNumber].Split(',');

                order.OrderNumber = Convert.ToInt16(row[0]);
                order.CustomerName = row[1];
                order.StateTaxRate = new TaxRate()
                {
                    State = row[2],
                    TaxPercent = Convert.ToDecimal(row[3])
                };
                order.Area = Convert.ToDouble(row[5]);
                order.ProductInfo = new Product()
                {
                    ProductType = row[4],
                    LaborCostPerSquareFoot = Convert.ToDecimal(row[6]),
                    MaterialCostPerSquareFoot = Convert.ToDecimal(row[7])
                };
                order.MaterialCost = Convert.ToDecimal(row[8]);
                order.LaborCost = Convert.ToDecimal(row[9]);
                order.Tax = Convert.ToDecimal(row[10]);
                order.Total = Convert.ToDecimal(row[11]);

                return true;
            }
            catch
            {
                return false; //TODO ? - save log file
            }

        }


        public static bool ProductReader(string productType, ref Product product)
        {
            try
            {

                string[] data = File.ReadAllLines(@"Data\Products.txt");

                for (int i = 1; i < data.Length; i++)
                {
                    string[] row = data[i].Split(',');
                    if (row[0] == productType)
                    {
                        product.ProductType = row[0];
                        product.MaterialCostPerSquareFoot = Convert.ToDecimal(row[1]);
                        product.LaborCostPerSquareFoot = Convert.ToDecimal(row[2]);
                        return true;
                    }
                }

                return false; 
            }
            catch
            {
                return false; //TODO ? - save log file
            }

        }

    

    }
}
