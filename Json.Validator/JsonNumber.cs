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
            if (string.IsNullOrEmpty(input) || input[0] == '0')
            {
                return false;
            }

            foreach (var item in input)
            {
                if (item > '9' || item < '0')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
