using System;

namespace Json
{
    public static class JsonString
    {
        const int MinimumLength = 2;

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

            return EndsWithReverseSolidus(input);
        }

        static bool EndsWithReverseSolidus(string input)
        {
            return input.Length - input.LastIndexOf('\\') < MinimumLength;
        }

        static bool ContainsValidUnicode(string input)
        {
            const int HexDigitsToCheck = 4;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u' &&
                   (input.Length - i < HexDigitsToCheck || !CheckElementsOfUnicode(input.Substring(input.IndexOf('u', i) + 1, HexDigitsToCheck))))
                {
                    return false;
                }
            }

            return true;
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
