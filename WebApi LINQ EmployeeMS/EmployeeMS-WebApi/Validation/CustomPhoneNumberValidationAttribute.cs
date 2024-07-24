using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace EmployeeMS.Validation
{
    public class CustomPhoneNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return new ValidationResult($"The {validationContext.DisplayName} is required field.");
            }
            
            if (!Regex.IsMatch(value.ToString(), @"^((\+977|\+1)?-?)?\d{4}-?\d{2}-?\d{4}$"))
            {
                return new ValidationResult($"The {validationContext.DisplayName} must be in +977-xxxx-xx-xxxx or +1-xxxx-xx-xxxx or +977xxxxxxxxxx or +1xxxxxxxxxx.");
            }

            return ValidationResult.Success;
        }
    }
}
