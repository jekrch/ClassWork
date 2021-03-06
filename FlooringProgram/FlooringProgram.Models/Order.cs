﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
       
        public TaxRate StateTaxRate { get; set; }
        public Product ProductInfo { get; set; }
        public double Area { get; set; }

        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }

        public decimal Tax { get; set; }
        public decimal Total { get; set; }

       
    }
}
