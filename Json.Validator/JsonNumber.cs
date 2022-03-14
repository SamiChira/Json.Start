using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsInteger(input);
        }

        private static bool IsInteger(string input)
        {
            return IsDigits(input) && !StartsWithZero(input);
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
