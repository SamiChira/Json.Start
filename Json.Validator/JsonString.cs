using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasValidContent(input) &&
                   IsQuoted(input) &&
                   !ContainsControlCharacters(input);
        }

        static bool IsQuoted(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"');
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

        static bool HasValidContent(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.Contains("\\") ? ContainsValidEscapedControlCharacters(input) || ContainsValidUnicode(input) : input.Length > 1;
        }

        static bool ContainsValidEscapedControlCharacters(string input)
        {
            const string controlChars = "\\b \\t \\r \\n \\f \\/ \\\" ";
            const int ElementsToCheck = 3;
            for (int i = 0; i < input.Length - ElementsToCheck; i++)
            {
                if (controlChars.Contains(input.Substring(i, ElementsToCheck)))
                {
                    return true;
                }
            }

            return ContainsReverseSolidus(input);
        }

        static bool ContainsReverseSolidus(string input)
        {
            return input.Contains("\\\\") && !input.EndsWith("\\");
        }

        static bool ContainsValidUnicode(string input)
        {
            const int HexDigitsToCheck = 4;

            return input.Contains("\\u") && (input.Length - 1 - input.IndexOf('u') > HexDigitsToCheck) &&
                   CheckElementsOfUnicode(input.Substring(input.IndexOf('u') + 1, HexDigitsToCheck));
        }

        static bool CheckElementsOfUnicode(string unicodeToCheck)
        {
            foreach (var item in unicodeToCheck.ToLower())
            {
                if (item < '0' || item > '9' && item < 'a' || item > 'f')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
