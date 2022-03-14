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
            return IsInteger(input)
                   && IsValidFraction(input, dotIndex);
        }

        private static bool IsValidFraction(string input, int dotIndex)
        {
            return dotIndex > 0 ? IsInteger(input, dotIndex) && IsDigits(input[(dotIndex + 1) ..])
                : IsDigits(input);
        }

        private static bool IsInteger(string input, int dotIndex)
        {
            return dotIndex > 0 ? IsDigits(input[..dotIndex]) && !StartsWithZero(input[..dotIndex])
                    : IsDigits(input);
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
