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
            return IsValidInteger(Integer(input, dotIndex, exponentIndex))
                   && IsValidFraction(Fraction(input, dotIndex, exponentIndex))
                   && IsValidExponent(Exponent(input, exponentIndex));
        }

        private static bool IsValidExponent(string exponent)
        {
            if (exponent.Length > 1 && StartWithPlusOrMinus(exponent[1..]))
            {
                exponent = exponent[1..];
            }

            return exponent.Length == 0 || IsDigits(exponent[1..]);
        }

        private static bool IsValidFraction(string fraction)
        {
            return fraction.Length == 0 || IsDigits(fraction[1..]);
        }

        private static bool IsValidInteger(string integer)
        {
            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
            }

            return IsDigits(integer) && !StartsWithZero(integer);
        }

        private static string Exponent(string input, int exponentIndex)
        {
            return exponentIndex > 0 ? input[exponentIndex ..] : "";
        }

        private static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > 0 && exponentIndex > 0)
            {
                return input[dotIndex..exponentIndex];
            }

            return dotIndex > 0 ? input[dotIndex..] : "";
        }

        private static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > 0)
            {
                return input[..dotIndex];
            }

            return exponentIndex > 0 ? input[..exponentIndex] : input;
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

            return input.Length > 0;
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
