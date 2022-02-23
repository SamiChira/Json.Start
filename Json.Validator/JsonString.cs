using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Trim('"').EndsWith('\\'))
            {
                return false;
            }

            return ContainsValidControlCharacters(input) &&
                   HasValidContent(input);
        }

        static bool HasValidContent(string input)
        {
            return input.Contains("\\u") ? ValidUnicode(input) : IsQuoted(input);
        }

        static bool IsQuoted(string input)
        {
            const int NumberTwo = 2;
            return input.StartsWith('"') &&
                   input.EndsWith('"') &&
                   input.Length >= NumberTwo;
        }

        static bool ContainsControlCharacters(string input)
        {
            foreach (var item in input)
            {
                if (item < ' ')
                {
                    return true;
                }
            }

            return input.Contains("\\");
        }

        static bool ContainsValidControlCharacters(string input)
        {
            string[] controlChars = { "\\b", "\\t", "\\r", "\\n", "\\f", "\\\\", "\\/", "\\\"", "\\u" };

            foreach (var escapeChar in controlChars)
            {
                if (input.Contains(escapeChar))
                {
                    return true;
                }
            }

            return !ContainsControlCharacters(input);
        }

        static bool ValidUnicode(string input)
        {
            const int ASCIILimit = 255;
            foreach (var item in input)
            {
                if (item > ASCIILimit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
