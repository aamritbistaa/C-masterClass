using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApplication.Exceptions
{
    public class ValidationAppException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; set; }

        public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
            : base(FormatErrorMessage(errors))
        {
            Errors = errors;
        }

        private static string FormatErrorMessage(IReadOnlyDictionary<string, string[]> errors)
        {
            // Format the error messages into a single string
            var errorMessage = "Validation error:";
            foreach (var item in errors)
            {
                errorMessage += $"\nField: {item.Key}, Errors: {string.Join(", ", item.Value)}";
            }
            return errorMessage;
        }
    }

}