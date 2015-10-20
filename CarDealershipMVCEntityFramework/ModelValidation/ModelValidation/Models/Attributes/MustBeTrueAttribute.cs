using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.Attributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool valid = false;
            valid = (value is bool && (bool) value == true);
            return valid;
        }
    }
}