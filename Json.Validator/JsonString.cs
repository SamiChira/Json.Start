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
                   ContainsEscapedControlCharacters(input) &&
                   EndsWithReverseSolidus(input) &&
                   ValidUnicode(input);
        }

        static bool IsQuoted(string input)
        {
            return input.StartsWith("\"") &&
                   input.EndsWith("\"");
        }

        static bool ContainsControlCharacters(string input)
        {
            char[] controlChars = { '\b', '\t', '\r', '\n', '\f', '\\', '/' };

            foreach (var escapeChar in controlChars)
            {
                if (input.Contains(escapeChar))
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainsEscapedControlCharacters(string input)
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

        static bool EndsWithReverseSolidus(string input)
        {
            return !input.Trim('"').EndsWith('\\');
        }

        static bool ValidUnicode(string input)
        {
            const int UnicodeCharsAfterU = 4;
            return input.Contains('u') ?
                   input.Length - 1 - input.LastIndexOf("u") - 1 >= UnicodeCharsAfterU :
                   IsQuoted(input);
        }
    }
}
