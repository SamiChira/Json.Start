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

            return IsQuoted(input) &&
                   ContainsValidControlCharacters(input) ||
                   ContainsValidUnicode(input);
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

            return false;
        }

        static bool ContainsValidControlCharacters(string input)
        {
            string[] controlChars = { "\\b", "\\t", "\\r", "\\n", "\\f", "\\\\", "\\/", "\\\"" };

            foreach (var escapeChar in controlChars)
            {
                if (input.Contains(escapeChar))
                {
                    return true;
                }
            }

            return !ContainsControlCharacters(input);
        }

        static bool ContainsValidUnicode(string input)
        {
            const int UnicodeCharsAfterU = 4;

            return input.Contains("\\u") ?
                   input.Length - 1 - input.LastIndexOf("u") - 1 >= UnicodeCharsAfterU :
                   ValidUnicode(input);
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
