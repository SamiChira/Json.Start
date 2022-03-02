using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return HasContent(input) &&
                   !ValidStartAndEndFormat(input) &&
                   HasValidContent(input);
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool HasValidContent(string input)
        {
            return double.TryParse(input, out double resultFractional);
        }

        static bool ValidStartAndEndFormat(string input)
        {
            return input.StartsWith('0') && input.Length > 1 && !input.Contains('.') || input.EndsWith('.');
        }
    }
}
