using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public class ConfigurationSettings
    {
        private static string _mode;

        public static string GetMode()
        {
            if (string.IsNullOrEmpty(_mode))
            {
                _mode = ConfigurationManager.AppSettings["mode"];
            }

            //return "Prod";
            return _mode;
        }

    }
}
