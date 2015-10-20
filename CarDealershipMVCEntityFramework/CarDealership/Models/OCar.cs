using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace CarDealership.Models
{

    public class OCar : IValidatableObject
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();


            if (string.IsNullOrWhiteSpace(Make))
            {
                errors.Add(new ValidationResult("Enter a make.", new[] { "Make" }));
            }

            if (string.IsNullOrWhiteSpace(Model))
            {
                errors.Add(new ValidationResult("Enter a model.", new[] { "Model" }));
            }

            if (string.IsNullOrWhiteSpace(Year))
            {
                errors.Add(new ValidationResult("Enter a year.", new[] { "Year" }));
            }


            if (!string.IsNullOrWhiteSpace(Year) && (Year.Any(char.IsLetter) || Year.Replace(" ", "").Length > 4)) // try to parse year
            {
                errors.Add(new ValidationResult("Invalid year.", new[] { "Year" }));
            }

            if (Price == 0)
            {
                errors.Add(new ValidationResult("Price can't be $0.", new[] { "Price" }));
            }

            if (Price > 1000000)
            {
                errors.Add(new ValidationResult("Price can't be greater than $1 MIL.", new[] { "Price" }));
            }

            if (string.IsNullOrWhiteSpace(Title))
            {
                errors.Add(new ValidationResult("Enter a title.", new[] { "Title" }));
            }

          

            // make sure the URL is a valid URl
            Uri uri;
            if (!string.IsNullOrWhiteSpace(ImageUrl) && !(ImageUrl.Length > 3) &&
                (ImageUrl.Substring(0,2) != "~/" || ImageUrl[0] != '/' ||
                !Uri.TryCreate(ImageUrl.Substring(0,4) == "http" ? ImageUrl : "http://" + ImageUrl, 
                               UriKind.Absolute, out uri)))
            {
                errors.Add(new ValidationResult("Invalid url.", new[] { "ImageUrl" }));
            }

     


            return errors;
        }
    }


}