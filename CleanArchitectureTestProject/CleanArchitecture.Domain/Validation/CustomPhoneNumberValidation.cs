using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Validation
{
    public class CustomPhoneNumberValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult($"The {validationContext.DisplayName} is required field.");
            }

            //if (!Regex.IsMatch(value.ToString(), @"^((\+977|\+1)?-?)?\d{4}-?\d{2}-?\d{4}$"))
            if (!Regex.IsMatch(value.ToString(), @"^((\+977|\+1)-)\d{4}-\d{2}-\d{4}$"))

            {
                return new ValidationResult($"The {validationContext.DisplayName} must be in +977-xxxx-xx-xxxx or +1-xxxx-xx-xxxx.");
            }

            return ValidationResult.Success;
        }
    }
}
