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
            const string controlChars = "btrnfu/\"\\";
            const int UnicodeLength = 6;
            if (input.Length <= 1)
            {
                return input.Length == 1;
            }

            if (input[0] == '\\' && (!controlChars.Contains(input[1]) || input[1] == 'u' && !CheckElementsOfUnicode(1, input)))
            {
                return false;
            }
            else if (input[0] == '\\' && controlChars.Contains(input[1]))
            {
                return input[1] == 'u' ? ContainsValidEscapedControlCharacters(input[UnicodeLength..]) : ContainsValidEscapedControlCharacters(input[MinimumLength..]);
            }

            return ContainsValidEscapedControlCharacters(input[1..]);
        }

        static bool CheckElementsOfUnicode(int indexOfU, string input)
        {
            const int HexDigitsToCheck = 4;
            if (indexOfU + HexDigitsToCheck >= input.Length)
            {
                return false;
            }

            string unicodeToCheck = input[(indexOfU + 1) .. (indexOfU + 1 + HexDigitsToCheck)];
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
