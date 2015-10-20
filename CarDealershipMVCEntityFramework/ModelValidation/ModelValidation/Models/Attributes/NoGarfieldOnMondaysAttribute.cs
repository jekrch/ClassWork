using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Models.Attributes
{
    public class NoGarfieldOnMondaysAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;
            if (app == null || string.IsNullOrEmpty(app.ClientName))
            {
                // we don't have a model of the right type to validate, or we don't have
                // the values for the ClientName and Date properties we require
                return true;
            }
            else
            {
                return !(app.ClientName == "Garfield" &&
                    app.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}