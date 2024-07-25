using EmployeeMS.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeMS.Validation
{
    public class CustomFutureDateValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult($"The {validationContext.DisplayName} field is required.");
            }
            if (!Regex.IsMatch(value.ToString(), @"^20\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-2])$"))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field must be in 20xx-12-01 format.");
            }
            DateOnly requestDate = DateOnly.Parse(value.ToString());
            if (requestDate is DateOnly)
            {
                if (requestDate <= DateTimeHelpers.ReturnTodayDate)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult($"The {validationContext.DisplayName} field cannot have future date.");
        }
    }
}
