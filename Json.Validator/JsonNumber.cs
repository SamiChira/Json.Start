using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input) || (input.StartsWith('0') && input.Length > 1))
            {
                return false;
            }

            return int.TryParse(input, out int result);
        }
    }
}
