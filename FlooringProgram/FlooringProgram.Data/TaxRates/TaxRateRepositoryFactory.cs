using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.TaxRates
{
    public class TaxRateRepositoryFactory
    {
        public static ITaxRateRepository GetTaxRateRepository()
        {
            switch (ConfigurationSettings.GetMode())
            {
                case "Prod":
                    return new TaxRateFileRepository();
                case "Test":
                    return new TaxRateTestRepository();
            }

            return null;
        }
    }
}
