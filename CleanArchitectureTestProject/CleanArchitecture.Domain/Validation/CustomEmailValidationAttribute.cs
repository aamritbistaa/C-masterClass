using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Validation
{
    public class CustomEmailValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult($"The {validationContext.DisplayName} is required field.");
            }
            if (!Regex.IsMatch(value.ToString(), @"^\w{5,30}@(gmail|facebook|technofex)\.(com|np|gov)$"))
            {
                return new ValidationResult($"The {validationContext.DisplayName} must have recipent's mailbox length between 5 and 30, be in domain gmail, facebook or technofex with com, np or gov.");
            }

            return ValidationResult.Success;
        }
    }
}
