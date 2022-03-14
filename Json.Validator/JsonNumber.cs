using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsDigit(input);
        }

        static bool IsDigit(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (var item in input)
            {
                if (StartsWithZero(input) || (item < 48 || item > 57))
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
