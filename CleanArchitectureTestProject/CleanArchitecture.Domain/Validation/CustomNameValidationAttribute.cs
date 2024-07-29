using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Validation
{
    public class CustomNameValidationAttribute : ValidationAttribute
    {
        public int MinimumStringLength { get; set; }
        public int MaximumStringLength { get; set; }

        public CustomNameValidationAttribute()
        {
            MinimumStringLength = 0;
            MaximumStringLength = 30;
        }
        public CustomNameValidationAttribute(int min, int max)
        {
            MinimumStringLength = min;
            MaximumStringLength = max;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is null)
            {
                return new ValidationResult($"The {validationContext.DisplayName} field is required.");
            }
            if (!Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field can contain only letters.");
            }
            if (value.ToString().Length < MinimumStringLength)
            {
                return new ValidationResult($"The {validationContext.DisplayName} field should be more than {MinimumStringLength}");
            }
            if (value.ToString().Length > MaximumStringLength)
            {
                return new ValidationResult($"The {validationContext.DisplayName} field should not be more than {MaximumStringLength}");
            }
            return ValidationResult.Success;
        }
    }
}
