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
            return Integer(input, dotIndex, exponentIndex)
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

        private static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > 0 && exponentIndex > 0 && dotIndex < exponentIndex)
            {
                return input[..dotIndex];
            }
            else if (dotIndex > 0 && exponentIndex < 0)
            {
                return input[..dotIndex];
            }
            else if (exponentIndex > 0 && dotIndex < 0)
            {
                return input[..exponentIndex];
            }

            return input;
        }

        static bool IsDigits(string input)
        {
            foreach (var item in input)
            {
                if (item < '0' || item > '9')
                    {
                        return false;
                    }
            }

            return true;
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
