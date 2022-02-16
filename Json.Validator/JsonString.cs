using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return IsQuoted(input) &&
                   IsEmptyDoubleQuoted(input) &&
                   !ContainsControlCharacters(input);
        }

        static bool IsQuoted(string input)
        {
            return input.StartsWith("\"") &&
                   input.EndsWith("\"") &&
                   AlwaysStartsWithQuotes(input);
        }

        static bool AlwaysStartsWithQuotes(string input)
        {
            const int numberTwo = 2;
            int quotesCounter = 0;
            foreach (var item in input)
            {
                if (item == '"')
                {
                    quotesCounter++;
                }
            }

            return quotesCounter % numberTwo == 0;
        }

        static bool IsEmptyDoubleQuoted(string input)
        {
            return IsQuoted(input);
        }

        static bool ContainsControlCharacters(string input)
        {
            char[] controlChars = { '\b', '\t', '\r', '\n', '\f', '/' };

            foreach (var escapeChar in controlChars)
            {
                if (input.Contains(escapeChar))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
