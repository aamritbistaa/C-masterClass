using EmployeeMS.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeMS.Validation
{
    public class CustomTimeValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult($"The {validationContext.DisplayName} field is required.");
            }
            if (!Regex.IsMatch(value.ToString(), @"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field must be in hh:mm format.");
            }
            return ValidationResult.Success;
        }
    }
}
