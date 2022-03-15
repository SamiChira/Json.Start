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

        private static bool IsValidFraction(string input, int dotIndex, int exponentIndex)
        {
            return dotIndex > 0 ? IsInteger(input, dotIndex) && IsDigits(input[(dotIndex + 1) ..])
                : IsDigits(input);
        }

        private static bool IsInteger(string input, int dotIndex, int exponentIndex)
        {
            return dotIndex > 0 ? IsDigits(input[..dotIndex]) && !StartsWithZero(input[..dotIndex])
                    : IsDigits(input) && !StartsWithZero(input);
        }

        static bool IsDigits(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (var item in input)
            {
                if (item != '-' && (item < '0' || item > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0';
        }
    }
}
