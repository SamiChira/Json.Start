using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input) || ValidStartAndEndFormat(input))
            {
                return false;
            }

            return int.TryParse(input, out int result) || double.TryParse(input, out double resultFractional);
        }

        static bool ValidStartAndEndFormat(string input)
        {
            return input.StartsWith('0') && input.Length > 1 && !input.Contains('.') || input.EndsWith('.');
        }
    }
}
