using System;
using System.Linq;
using System.Text;

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
                   ContainsValidControlCharacters(input) &&
                   ValidUnicodeFormat(input);
        }

        static bool IsQuoted(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"') && input.Length > 1;
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

        static bool ContainsValidEscapedControlCharacters(string input)
        {
            const string controlChars = "\\b \\t \\r \\n \\f \\/ \\\" \\u \\\\";
            const int HexDigitsToCheck = 4;
            const int ElementsToCheck = 3;
            for (int i = 0; i < input.Length - ElementsToCheck; i++)
            {
                string elementsToCheck = input.Substring(i, ElementsToCheck);
                if (elementsToCheck.Contains("\\u") && (input.Length - 1 - input.IndexOf('u') > HexDigitsToCheck))
                {
                    return CheckElementsOfUnicode(input.Substring(input.IndexOf('u') + 1, HexDigitsToCheck));
                }
                else if (controlChars.Contains(input.Substring(i, ElementsToCheck)))
                {
                    return true;
                }
            }

            return false;
        }

        static bool ValidUnicodeFormat(string input)
        {
            const int NumberOne = 1;
            const int HexNumberLength = 6;
            bool[] validUnicodes = { };
            int unicodeCounter = 0;
            for (int i = 1; i < input.Length; i++)
            {
                StringBuilder unicodeToCheck = new StringBuilder();
                if (input[i - NumberOne] == '\\' && input[i] == 'u')
                {
                    try
                    {
                        unicodeToCheck.Append(input.Substring(i - NumberOne, HexNumberLength));
                        Array.Resize(ref validUnicodes, validUnicodes.Length + NumberOne);
                        validUnicodes[unicodeCounter++] = CheckElementsOfUnicode(unicodeToCheck.ToString());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Array.Resize(ref validUnicodes, validUnicodes.Length + NumberOne);
                        validUnicodes[unicodeCounter++] = false;
                    }
                }
            }

            return !validUnicodes.Contains(false);
        }

        static bool CheckElementsOfUnicode(string unicodeToCheck)
        {
            const int DigitStartPoint = 2;
            const int DigitEndPoint = 4;
            foreach (var item in unicodeToCheck.Substring(DigitStartPoint, DigitEndPoint))
            {
                if (item == '"' || item == '\\' || item == ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
