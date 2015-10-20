using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.ModelBinding;

namespace CarDealership.Models
{
    public class ContactForm : IValidatableObject
    {

        public string Name { get; set; }
        public int PurchaseTimeFrameInMonths { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? Income { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();


            //   3.Add validation to the contact form.The rules are:
            //   - Name is required
            //   - Phone number must be in format XXX-XXX-XXXX
            //   - Email is required and must contain an @ symbol(if you like, you can research and use regex instead)
            //   - Income is required...it must be greater than 20,000 and be in the format XXX,XXX

            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                errors.Add(new ValidationResult("Enter a phone number.", new string[] { "PhoneNumber" }));
            }


            if (Income != null && Income <= 20000)
            {
                errors.Add(new ValidationResult("We're sorry, but your income must be higher than $20,000"));
            }


            long number; 

            if (!string.IsNullOrEmpty(PhoneNumber) &&
                (
                !long.TryParse(PhoneNumber.Replace(" ", "").Replace("-",""), out number) ||
                PhoneNumber.Replace(" ", "").Length != 12 ||
                PhoneNumber.Replace(" ", "")[3] != '-' || 
                PhoneNumber.Replace(" ", "")[7] != '-')
                )
            {
                errors.Add(new ValidationResult("Number must be XXX-XXX-XXXX.", new string[] { "PhoneNumber" }));
            }
            
            string emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult("Enter a name.", new string[] { "Name" }));
            }

            if (!string.IsNullOrWhiteSpace(Email) && !Regex.IsMatch(Email, emailRegex, RegexOptions.IgnoreCase))
            {
                errors.Add(new ValidationResult("Invalid email address", new string[] { "Email" }));
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                errors.Add(new ValidationResult("Enter an email address.", new string[] { "Email" }));
            }

            if (Income == null)
            {
                errors.Add(new ValidationResult("Enter an income", new string[] { "Income" }));
            }


            return errors;
        }
    }
}