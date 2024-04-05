using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class InputConverter
    {
        public double ConvertInputToNumber(string argTextInput)
        {
            double convertedNumber;
            bool isSuccess = double.TryParse(argTextInput, out convertedNumber);
            if (!isSuccess)
            {
                throw new ArgumentException("Expected a numeric value.");
            }
            return convertedNumber;
        }
    }
}
