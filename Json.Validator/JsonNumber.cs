using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            return IsInteger(input, dotIndex, exponentIndex)
                   && IsValidFraction(input, dotIndex, exponentIndex)
                   && IsValidExponent(input, exponentIndex);
        }

        private static bool IsValidExponent(string input, int exponentIndex)
        {
            return exponentIndex <= 1 || IsDigits(input[(exponentIndex + 1) ..]);
        }

        private static bool IsValidFraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > 0 && exponentIndex > 0 && dotIndex < exponentIndex)
            {
                return IsDigits(input[(dotIndex + 1) ..exponentIndex]);
            }
            else if (dotIndex > 0 && exponentIndex < 0)
            {
                return IsDigits(input[(dotIndex + 1) ..]);
            }
            else
            {
                return true;
            }
        }

        private static bool IsInteger(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > 0 && exponentIndex > 0)
            {
                return IsDigits(input[..dotIndex]);
            }
            else if (dotIndex > 0 && exponentIndex < 0)
            {
                return IsDigits(input[..dotIndex]) && !StartsWithZero(input[..dotIndex]);
            }
            else if (exponentIndex > 0 && dotIndex < 0)
            {
                return IsDigits(input[..exponentIndex]) && !StartsWithZero(input[..exponentIndex]);
            }

            return IsDigits(input) && !StartsWithZero(input);
        }

        static bool IsDigits(string input)
        {
            int counter = 0;
            string stringToCheck = StartWithPlusOrMinus(input) ? input[1..] : input;
            int plusOrMinusCounter = 0;
            while (stringToCheck.Length - counter > 0)
            {
                if (stringToCheck[counter] == '-' || stringToCheck[counter] == '+')
                {
                    plusOrMinusCounter++;
                    counter++;
                    continue;
                }
                else if (stringToCheck[counter] < '0'
                        || stringToCheck[counter] > '9')
                {
                    return false;
                }

                counter++;
            }

            return stringToCheck.Length > 0 && plusOrMinusCounter <= 0;
        }

        private static bool StartWithPlusOrMinus(string input)
        {
            return input.StartsWith('+') || input.StartsWith('-');
        }

        private static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0';
        }
    }
}
