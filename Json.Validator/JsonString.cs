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
            return !string.IsNullOrEmpty(input) &&
                   input.Length >= MinimumLength &&
                   ContainsValidEscapedControlCharacters(input);
        }

        static bool ContainsValidEscapedControlCharacters(string input)
        {
            const string controlChars = "btrnf/\"u";
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && (!controlChars.Contains(input[i + 1].ToString()) || input[i + 1] == 'u' && !ContainsValidUnicode(input)))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ContainsValidUnicode(string input)
        {
            const int HexDigitsToCheck = 4;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u' &&
                   (input.Length - (input.IndexOf('u', i) + 1) < HexDigitsToCheck ||
                   !CheckElementsOfUnicode(input.Substring(input.IndexOf('u', i) + 1, HexDigitsToCheck))))
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
