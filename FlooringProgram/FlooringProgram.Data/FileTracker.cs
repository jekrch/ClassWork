using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public class FileTracker
    {
        public static bool CheckForFile(string date)
        {
            return File.Exists(date);
        }


    }
}
