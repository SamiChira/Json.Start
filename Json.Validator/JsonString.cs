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
            const int NumberTwo = 2;
            string[] controlChars = { "\\b", "\\t", "\\r", "\\n", "\\f", "\\\\", "\\/", "\\\"", "\\u" };

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '\\' && !controlChars.Contains(input.Substring(i, NumberTwo)) && input[i + 1] != ' ')
                {
                    return false;
                }
            }

            return !ContainsControlCharacters(input);
        }

        static bool ContainsValidUnicode(string input)
        {
            const int UnicodeCharsAfterU = 4;

            return input.Contains("u") ?
                   input.Length - 1 - input.LastIndexOf("u") - 1 >= UnicodeCharsAfterU :
                   ValidUnicode(input);
        }

        static bool ValidEscapedUnicodeFormat(string input)
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
                if (item == '"' || item == '\\')
                {
                    return false;
                }
            }

            return true;
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
