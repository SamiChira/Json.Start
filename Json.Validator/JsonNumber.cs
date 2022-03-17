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
            int plusOrMinusIndex = exponent.IndexOfAny(new[] { '+', '-' });
            if (exponent != "-1" && plusOrMinusIndex > 0)
            {
                return IsDigits(exponent[(plusOrMinusIndex + 1) ..]) && exponent[plusOrMinusIndex..].Length > 1;
            }
            else if (exponent != "-1")
            {
                return IsDigits(exponent[1..]) && exponent.Length > 1;
            }

            return exponent == "-1";
        }

        private static bool IsValidFraction(string fraction)
        {
            return fraction.Length > 1 ? IsDigits(fraction[1..]) : IsDigits(fraction);
        }

        private static bool IsValidInteger(string integer)
        {
            if (StartWithPlusOrMinus(integer))
            {
                return IsDigits(integer[1..]) && !StartsWithZero(integer);
            }

            return IsDigits(integer) && !StartsWithZero(integer);
        }

        private static string Exponent(string input, int exponentIndex)
        {
            return exponentIndex > 0 ? input[exponentIndex ..]
                    : exponentIndex.ToString();
        }

        private static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > 0 && exponentIndex < 0)
            {
                return input[dotIndex..];
            }
            else if (dotIndex > 0 && exponentIndex > 0)
            {
                return input[dotIndex..exponentIndex];
            }
            else
            {
                return "";
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
