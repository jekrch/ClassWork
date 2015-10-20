using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    class Validation
    {
        public static bool ValidateDate(ref string input)
        {
            bool isValidDate = false;

            input = input.Replace(" ", "");

            if (input.Length == 8)
            {
                int date;
                isValidDate = int.TryParse(input, out date);
            }

            return isValidDate;
       
        }
    }
}
